using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.API.Controllers;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Request.API.Infrastructure;
using Request.API.Model;
using Request.API.Models;
using Request.API.ViewModel;
using Request.API.ViewModels;
using SharedKernel.Abstractions;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;

namespace Request.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private RequestContext _context;
        private IMapper _mapper;
        private readonly ILogger _logger;

        public RequestsController(RequestContext context,
            IMapper mapper,
            ILogger<RequestsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        public async Task<IActionResult> Get([FromQuery]string filter, [FromQuery]int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var requests = await _context.Requests.Include(r => r.Process)
                .ThenInclude(p => p.Actions).Include(r => r.Process)
                .ThenInclude(p => p.States).Include(r => r.Process)
                .ThenInclude(p => p.Activities).Include(r => r.Process)
                .ThenInclude(p => p.Rules)
                .Include(r => r.Process).ThenInclude(p => p.Rules).Include(r => r.Process)
                .ThenInclude(p => p.Roles).Include(r => r.Process)
                .ThenInclude(p => p.Nodes).ThenInclude(n => n.Childs)
                .Include(r => r.Process).ThenInclude(p => p.Nodes).ThenInclude(n => n.Actions)
                .Include(r => r.CurrentState).Include(r => r.CurrentNode)
                .Include(r => r.Data).Include(r => r.Tasks)
                .ToListAsync();
            return Ok(_mapper.Map<List<RequestViewModel>>(requests));
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var requests = await _context.Requests.Include(r => r.Process)
                .ThenInclude(p => p.Actions).Include(r => r.Process)
                .ThenInclude(p => p.States).Include(r => r.Process)
                .ThenInclude(p => p.Activities).Include(r => r.Process)
                .ThenInclude(p => p.Rules)
                .Include(r => r.Process).ThenInclude(p => p.Rules).Include(r => r.Process)
                .ThenInclude(p => p.Roles).Include(r => r.Process)
                .ThenInclude(p => p.Nodes).ThenInclude(n => n.Childs)
                .Include(r => r.Process).ThenInclude(p => p.Nodes).ThenInclude(n => n.Actions)
                .Include(r => r.CurrentState).Include(r => r.CurrentNode)
                .Include(r => r.Data).Include(r => r.Tasks)
                .ToListAsync();
            var request = requests.FirstOrDefault(r => r.Id == id);
            if (request is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RequestViewModel>(request));
        }

        // [HttpGet]
        // [Route("triggerconfig")]
        // public async Task<IActionResult> GetTriggerConfiguration()
        // {
        //     StreamReader rd = new StreamReader("trigger-configuration.json");
        //     var content = rd.ReadToEnd();
        //     if (content == null)
        //     {
        //         return NotFound("cannot read config file");
        //     }
        //     List<TriggerConf> configurations = JsonConvert.DeserializeObject<List<TriggerConf>>(content);
        //     return Ok(configurations);
        // }

        [HttpGet]
        [Route("tasks")]
        public async Task<IActionResult> GetTasks([FromQuery]string role)
        {
             var context = await _context.Requests.Include(r => r.Process)
                .ThenInclude(p => p.Actions).Include(r => r.Process)
                .ThenInclude(p => p.States).Include(r => r.Process)
                .ThenInclude(p => p.Activities).Include(r => r.Process)
                .ThenInclude(p => p.Rules).Include(r => r.Process)
                .ThenInclude(p => p.Roles).Include(r => r.Process)
                .ThenInclude(p => p.Nodes).ThenInclude(n => n.Childs)
                .Include(r => r.Process).ThenInclude(p => p.Nodes).ThenInclude(n => n.Actions)
                .Include(r => r.CurrentState)
                .Include(r => r.CurrentNode)
                .Include(r => r.Data)
                .Include(r => r.Tasks)
                .ToListAsync();
            var requests = context.Where(r => !r.IsCompleted()).ToList();
            var models = new List<Model.Request>();
            foreach (var request in requests)
            {
                if (request.CurrentState != null)
                {
                    foreach (var activity in request.CurrentState.Activities)
                    {
                        if (activity.Roles.FirstOrDefault(r => r.Name.Equals("other")) != null)
                        {
                            models.Add(request);
                        }
                        else if(activity.Roles.FirstOrDefault(r => r.Name.Equals(role)) != null)
                        {
                            models.Add(request);
                        }
                    }
                }
                if (request.CurrentNode != null)
                {
                    foreach (var activity in request.CurrentNode.Activities)
                    {
                        if (activity.Roles.FirstOrDefault(r => r.Name.Equals("other")) != null)
                        {
                            models.Add(request);
                        }
                        else if(activity.Roles.FirstOrDefault(r => r.Name.Equals(role)) != null)
                        {
                            models.Add(request);
                        }
                    }
                }
            }
            return Ok(_mapper.Map<List<RequestViewModel>>(models));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkFlow(RequestCreateModel model1)
        {
            Model.Request new_request = Model.Request.CreateFlow(model1);
            _context.Requests.Add(new_request);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<RequestViewModel>(new_request));
        }
        [HttpPost]
        [Route("tree")]
        public async Task<IActionResult> CreateTree(RequestCreateModel model1)
        {
            var process = new Process(model1.Process.Name);
            _context.Processes.Add(process);
            await _context.SaveChangesAsync();
            Model.Request new_request = Model.Request.NodeCreateFlow(model1, process);
            _context.Requests.Add(new_request);
            await _context.SaveChangesAsync();
            foreach (var rule in new_request.Process.Rules) 
            {
                var f = await _context.Nodes.FirstOrDefaultAsync(r => r.Id == rule.CurrentNode.Id);
                var s = await _context.Nodes.FirstOrDefaultAsync(r => r.Id == rule.NextNode.Id);
                if (f != null && s != null) {
                    f.AddChild(s);
                    _context.Update(f);
                }
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Route("{id:int}")]
        [HttpPut]
        public async Task<IActionResult> CompleteTask(int id, [FromBody]Model.Task task, [FromQuery]bool autoadvance)
        {
            if (id < 0)
            {
                return NotFound();
            }

             var requests = await _context.Requests.Include(r => r.Process)
                .ThenInclude(p => p.Actions).Include(r => r.Process)
                .ThenInclude(p => p.States).Include(r => r.Process)
                .ThenInclude(p => p.Activities).Include(r => r.Process)
                .ThenInclude(p => p.Rules).Include(r => r.Process)
                .ThenInclude(p => p.Roles).Include(r => r.Process)
                .ThenInclude(p => p.Nodes)
                .Include(r => r.CurrentState)
                .Include(r => r.CurrentNode)
                .Include(r => r.Data)
                .Include(r => r.Tasks)
                .Include(r => r.Histories)
                .ToListAsync();
            var request = requests.FirstOrDefault(r => r.Id == id);
            if (request is null)
            {
                return NotFound();
            }
            request.CompleteTask(task, autoadvance);
            _context.Update(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpGet]
        [Route("process")]
        public IActionResult GetProcess()
        {
            var process = _context.Activities.FromSql("SELECT * from activities");
            return Ok(process.ToList());
        }

        [HttpGet]
        [Route("actions")]
        public async Task<List<Models.Action>> GetAvailableActions(int id, string state)
        {
            var requests = await _context.Requests.Include(r => r.Process)
                .ThenInclude(p => p.Actions).Include(r => r.Process)
                .ThenInclude(p => p.States).Include(r => r.Process)
                .ThenInclude(p => p.Activities).Include(r => r.Process)
                .ThenInclude(p => p.Rules).Include(r => r.Process)
                .ThenInclude(p => p.Roles)
                .Include(r => r.CurrentState)
                .Include(r => r.Data)
                .Include(r => r.Tasks)
                .Include(r => r.Histories)
                .ToListAsync();
            var request = requests.FirstOrDefault(r => r.Id == id);
            if (request is null || state == "")
            {
                return null;
            }
            return(request.GetAvailableActions(state));
        }

        [HttpPut]
        [Route("SubmitAction/{id:int}")]
        public async Task<IActionResult> CompleteTask(int id, [FromQuery]bool trigger, SubmitActionViewModel model)
        {
            var requests = await _context.Requests.Include(r => r.Process)
                .ThenInclude(p => p.Actions).Include(r => r.Process)
                .ThenInclude(p => p.States).Include(r => r.Process)
                .ThenInclude(p => p.Activities).Include(r => r.Process)
                .ThenInclude(p => p.Rules)
                .Include(r => r.Process).ThenInclude(p => p.Rules).Include(r => r.Process)
                .ThenInclude(p => p.Roles).Include(r => r.Process)
                .ThenInclude(p => p.Nodes).ThenInclude(n => n.Childs)
                .Include(r => r.Process).ThenInclude(p => p.Nodes).ThenInclude(n => n.Actions)
                .Include(r => r.CurrentState).Include(r => r.CurrentNode)
                .Include(r => r.Data).Include(r => r.Tasks)
                .ToListAsync();
            if (id <= 0)
            {
                return NotFound();
            }
            var request = requests.FirstOrDefault(r => r.Id == id);
            if (request is null)
            {
                return NotFound();
            }
            if (model.data != null)
            {
                foreach (var data in model.data)
                {
                    request.InsertData(data, model.activity);
                }
                if (trigger) { //TODO check if current state/node is valid before do this
                    StreamReader rd = new StreamReader("customers.json");
                    string json = rd.ReadToEnd();
                    List<Contact> cs = JsonConvert.DeserializeObject<List<Contact>>(json);
                    foreach (var c in cs)
                    {
                        request.InsertData(new DataCreateModel {
                            FullName = c.FullName,
                            Age = c.Age,
                            Email = c.Email,
                            PhoneNumber = c.PhoneNumber,
                            DataType = DataType.Contact
                        }, model.activity);
                    }
                }
                _context.Update(request);
                await _context.SaveChangesAsync();
            }
            
            if (id <= 0)
            {
                return NotFound();
            }
            request.Data = await _context.Data.Where(d => d.RequestId == request.Id).ToListAsync();
            request.CurrentState = request.Transit(model.action, model.source, model.role, model.activity, model.approver, model.data, model.doactivity, trigger);
            try
            {
                _context.Update(request);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RequestViewModel>(request));
        }

        [HttpPut]
        [Route("SubmitNodeAction/{id:int}")]
         public async Task<IActionResult> NodeCompleteTask(int id, SubmitActionViewModel model)
         {
             var requests = await _context.Requests.Include(r => r.Process)
                .ThenInclude(p => p.Actions).Include(r => r.Process)
                .ThenInclude(p => p.Activities).Include(r => r.Process)
                .ThenInclude(p => p.Rules).Include(r => r.Process)
                .ThenInclude(p => p.Roles).Include(r => r.Process)
                .ThenInclude(p => p.Nodes)
                .Include(r => r.CurrentNode)
                .Include(r => r.Data)
                .Include(r => r.Tasks)
                .Include(r => r.Histories)
                .ToListAsync();
            if (id <= 0)
            {
                return NotFound();
            }
            var request = requests.FirstOrDefault(r => r.Id == id);
            if (request is null)
            {
                return NotFound();
            }
            if (model.data != null)
            {
                foreach (var data in model.data)
                {
                    request.InsertData(data, model.activity);
                }
            }
            request.CurrentNode = request.MoveNode(model.action, model.source, model.role, model.activity, model.approver, model.data, model.doactivity);
            try
            {
                _context.Update(request);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RequestViewModel>(request));
        }

        private static void Sumbit(RequestAction requestaction)
        {
            requestaction.IsActive = false;
            requestaction.IsComplete = true;
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var request = await _context.Requests.FirstOrDefaultAsync(p => p.Id == id);

            if (request is null)
                return NotFound();

            _context.Remove(request);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //[Route("{id:int}")]
        //[HttpPut]
        //public async Task<IActionResult> Put(int id, RequestEditModel model)
        //{
        //    if (model is null || id < 0)
        //    {
        //        return BadRequest();
        //    }

        //    var existed = await _context.Requests.FirstOrDefaultAsync(e => e.Id == id);


        //    if (existed != null)
        //    {
        //        existed.ProcessID = model.ProcessID;
        //        existed.Title = model.Title;    
        //        existed.UserId = model.UserId;
        //        existed.UserName = model.UserName;
        //        existed.DateRequested = model.DateRequested;
        //        existed.CurrentStateID = model.CurrentStateID;
        //    }

        //    _context.Update(existed);
        //    await _context.SaveChangesAsync();

        //    return NoContent();

        //}

        //[HttpPost]
        //[Route("import")]
        //public async Task<IActionResult> ImportProjectFromCsv([FromForm(Name = "file")]IFormFile file)
        //{
        //    var results = new ImportResult();
        //    if (file.Length > 0)
        //    {
        //        using (var stream = file.OpenReadStream())
        //        {

        //            using (var reader = new StreamReader(stream))
        //            using (var csv = new CsvReader(reader))
        //            {
        //                csv.Read();
        //                csv.ReadHeader();
        //                while (csv.Read())
        //                {
        //                    results.Total += 1;
        //                    var record = Model.Request.Create(
        //                        csv.GetField<int>("ProcessID"),
        //                        csv.GetField("Title"),
        //                        csv.GetField<int>("UserID"),
        //                        csv.GetField<string>("UserName"),
        //                        csv.GetField<int>("CurrentStateID"),
        //                        csv.GetField<DateTime>("DateRequested")
        //                        //
        //                    );

        //                    results.Successed += 1;
        //                    _context.Requests.Add(record);
        //                    await _context.SaveChangesAsync();
        //                }

        //            }

        //            return Ok(results);
        //        }
        //    }
        //    results.Errors.Add($"cannot read file {file.FileName}");
        //    return NotFound(results);
        //}

        [HttpGet]
        [Route("export")]
        [Produces("text/csv")]
        public async Task<IActionResult> ExportRequestAsCsv([FromQuery]string filter)
        {
            var result = _context.Requests.Where(c => true);

            if (!string.IsNullOrEmpty(filter))
                result = result.Where(c => c.Title.Contains(filter, StringComparison.InvariantCultureIgnoreCase)
                                        || c.Title.Contains(filter, StringComparison.InvariantCultureIgnoreCase));

            var filePath = Path.GetTempFileName();
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteHeader<RequestExportModel>();
                csv.NextRecord();
                foreach (var r in result)
                {
                    csv.WriteRecord(_mapper.Map<RequestExportModel>(r));
                    csv.NextRecord();
                }

            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "text/csv", "export.csv");
        }
    }

}

