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
using Request.API.Infrastructure;
using Request.API.Models;
using SharedKernel.Abstractions;
using SharedKernel.Enums;

namespace Request.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WorkFlowsController : ControllerBase
    {
        private RequestContext _context;
        private IMapper _mapper;
        private readonly ILogger _logger;

        public WorkFlowsController(RequestContext context,
            IMapper mapper,
            ILogger<RequestsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        //public async Task<IActionResult> Get([FromQuery]string filter, [FromQuery]int pageSize = 10, [FromQuery] int pageIndex = 0)
        //{
        //    var result = _context.Flows.Where(c => true);

        //    var totalItems = await result.LongCountAsync();

        //    var itemsOnPage = await result
        //            .OrderBy(c => c.Id)
        //            .Skip(pageIndex * pageSize)
        //            .Take(pageSize)
        //            .ToListAsync();

        //    var model = new PaginatedItems<WorkFlowViewModel>(pageIndex, pageSize, totalItems, itemsOnPage.Select(o => new WorkFlowViewModel
        //    {
        //        Start = o.Start,
        //        End = o.End,
        //        Stage1 = o.Stage1,
        //        Assignee1 = o.Assignee1,
        //        Assignee2 = o.Assignee2,
        //        Assignee3 = o.Assignee3,
        //        Assignee4 = o.Assignee4,
        //        Assignee5 = o.Assignee5,
        //        Owner1 = o.Owner1,
        //        Owner2 = o.Owner2,
        //        Owner3 = o.Owner3,
        //        Owner4 = o.Owner4,
        //        Owner5 = o.Owner5,
        //        File1 = o.File1,
        //        File2 = o.File2,
        //        File3 = o.File3,
        //        File4 = o.File4,
        //        File5 = o.File5,
        //        Name1 = o.Name1,
        //        Task1 = o.Task1,
        //        Name2 = o.Name1,
        //        Task2 = o.Task1,
        //        Name3 = o.Name1,
        //        Task3 = o.Task1,
        //        Name4 = o.Name1,
        //        Task4 = o.Task1,
        //        Name5 = o.Name1,
        //        Task5 = o.Task1
        //    }));

        //    return Ok(model);
        //}

        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetItemById(int id)
        //{
        //    var item = await _context.Flows.SingleOrDefaultAsync(l => l.Id == id);

        //    if (item is null)
        //        return NotFound();

        //    return Ok(_mapper.Map<WorkFlowViewModel>(item));
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateFlow(WorkFlowEditModel model)
        //{
        //    if (model is null)
        //        return BadRequest();

        //    var entity = WorkFlow.Create
        //        (
        //            model.RequestId, model.Start, model.End, model.CurrentStage,
        //            model.Stage1, model.Name1, model.Task1, model.Assignee1, model.Owner1, model.File1,
        //            model.Stage2, model.Name2, model.Task2, model.Assignee2, model.Owner2, model.File2,
        //            model.Stage3, model.Name3, model.Task3, model.Assignee3, model.Owner3, model.File3,
        //            model.Stage4, model.Name4, model.Task4, model.Assignee4, model.Owner4, model.File4,
        //            model.Stage5, model.Name5, model.Task5, model.Assignee5, model.Owner5, model.File5
        //        );

        //    _context.Flows.Add(entity);
        //    await _context.SaveChangesAsync();

        //    return Ok(entity);
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id < 0)
        //    {
        //        return BadRequest();
        //    }

        //    var flow = await _context.Flows.FirstOrDefaultAsync(p => p.Id == id);

        //    if (flow is null)
        //        return NotFound();

        //    _context.Remove(flow);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[Route("{id:int}")]
        //[HttpPut]
        //public async Task<IActionResult> Put(int id, WorkFlowEditModel model)
        //{
        //    if (model is null || id < 0)
        //    {
        //        return BadRequest();
        //    }

        //    var existed = await _context.Flows.FirstOrDefaultAsync(e => e.Id == id);


        //    if (existed != null)
        //    {
        //        existed.Start = model.Start;
        //        existed.End = model.End;
        //        existed.Stage1 = model.Stage1;
        //        existed.Assignee1 = model.Assignee1;
        //        existed.Assignee2 = model.Assignee2;
        //        existed.Assignee3 = model.Assignee3;
        //        existed.Assignee4 = model.Assignee4;
        //        existed.Assignee5 = model.Assignee5;
        //        existed.Owner1 = model.Owner1;
        //        existed.Owner2 = model.Owner2;
        //        existed.Owner3 = model.Owner3;
        //        existed.Owner4 = model.Owner4;
        //        existed.Owner5 = model.Owner5;
        //        existed.File1 = model.File1;
        //        existed.File2 = model.File2;
        //        existed.File3 = model.File3;
        //        existed.File4 = model.File4;
        //        existed.File5 = model.File5;
        //        existed.Name1 = model.Name1;
        //        existed.Task1 = model.Task1;
        //        existed.Name2 = model.Name1;
        //        existed.Task2 = model.Task1;
        //        existed.Name3 = model.Name1;
        //        existed.Task3 = model.Task1;
        //        existed.Name4 = model.Name1;
        //        existed.Task4 = model.Task1;
        //        existed.Name5 = model.Name1;
        //        existed.Task5 = model.Task1;
        //    }
        //    else
        //    {
        //        return NotFound();
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
        //                    var record = WorkFlow.Create(
        //                        csv.GetField<int>("RequestId"),
        //                        csv.GetField<StageStatus>("Start"),
        //                        csv.GetField<StageStatus>("End"),
        //                        csv.GetField("CurrentStage"),
        //                        csv.GetField<StageStatus>("Stage1"),
        //                        csv.GetField("Name1"),
        //                        csv.GetField("Task1"),
        //                        csv.GetField("Assignee1"),
        //                        csv.GetField("Owner1"),
        //                        csv.GetField("File1"),
        //                        csv.GetField<StageStatus>("Stage2"),
        //                        csv.GetField("Name2"),
        //                        csv.GetField("Task2"),
        //                        csv.GetField("Assignee2"),
        //                        csv.GetField("Owner2"),
        //                        csv.GetField("File2"),
        //                        csv.GetField<StageStatus>("Stage3"),
        //                        csv.GetField("Name3"),
        //                        csv.GetField("Task3"),
        //                        csv.GetField("Assignee3"),
        //                        csv.GetField("Owner3"),
        //                        csv.GetField("File3"),
        //                        csv.GetField<StageStatus>("Stage4"),
        //                        csv.GetField("Name4"),
        //                        csv.GetField("Task4"),
        //                        csv.GetField("Assignee4"),
        //                        csv.GetField("Owner4"),
        //                        csv.GetField("File4"),
        //                        csv.GetField<StageStatus>("Stage5"),
        //                        csv.GetField("Name5"),
        //                        csv.GetField("Task5"),
        //                        csv.GetField("Assignee5"),
        //                        csv.GetField("Owner5"),
        //                        csv.GetField("File5")
        //                    );

        //                    results.Successed += 1;
        //                    _context.Flows.Add(record);
        //                    await _context.SaveChangesAsync();

        //                }

        //            }

        //            return Ok(results);
        //        }
        //    }
        //    results.Errors.Add($"cannot read file {file.FileName}");
        //    return NotFound(results);
        //}

        //[HttpGet]
        //[Route("export")]
        //[Produces("text/csv")]
        //public async Task<IActionResult> ExportRequestAsCsv([FromQuery]string filter)
        //{
        //    var result = _context.Flows.Where(c => true);

        //    var filePath = Path.GetTempFileName();
        //    using (var writer = new StreamWriter(filePath))
        //    using (var csv = new CsvWriter(writer))
        //    {
        //        csv.WriteHeader<WorkFlowExportModel>();
        //        csv.NextRecord();
        //        foreach (var r in result)
        //        {
        //            csv.WriteRecord(_mapper.Map<WorkFlowExportModel>(r));
        //            csv.NextRecord();
        //        }

        //    }

        //    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

        //    return File(fileBytes, "text/csv", "export.csv");
        //}
    }
}