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
    public class ActivityController : ControllerBase
    {
        private RequestContext _context;
        private IMapper _mapper;
        private readonly ILogger _logger;

        public ActivityController(RequestContext context,
            IMapper mapper,
            ILogger<RequestsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        public async Task<IActionResult> Get([FromQuery]string filter, [FromQuery]int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
           var result = _context.Activities.Where(c => true);

           var totalItems = await result.LongCountAsync();

           var itemsOnPage = await result
                   .Skip(pageIndex * pageSize)
                   .Take(pageSize)
                   .ToListAsync();

           var model = new PaginatedItems<ActivityViewModel>(pageIndex, pageSize, totalItems, itemsOnPage.Select(o => new ActivityViewModel
           {
               Id = o.Id,
               Name = o.Name,
               Description = o .Description

           }));

           return Ok(model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetItemById(int id)
        {
           var item = await _context.Activities.SingleOrDefaultAsync(l => l.Id == id);

           if (item is null)
               return NotFound();

           return Ok(_mapper.Map<ActivityViewModel>(item));
        }

        // [HttpPost]
        // public async Task<IActionResult> Create(ActivityEditModel model)
        // {
        //    if (model is null)
        //        return BadRequest();

        //    var entity = Activity.Create( model.ActivityTypeID, model.ProcessID, model.Name, model.Description);

        //    _context.Activities.Add(entity);
        //    await _context.SaveChangesAsync();

        //    return Ok(entity);
        // }

        ////[Route("hire")]
        ////[HttpPost]
        ////public async Task<IActionResult> CreateRecruitRequest(RequestEditModel model)
        ////{
        ////    if (model is null)
        ////        return BadRequest();

        ////    var entity = Model.Request.CreateRecruitRequest(model.Name, model.Kind, 0, Guid.Empty, model.Contents, Applicant.Create(FullName.Create("Loi", "Le").Value, "receptionist", 39, Gender.Male, Address.Create("street", "", "HCM", "", "", "").Value));

        ////    _context.Requests.Add(entity);
        ////    await _context.SaveChangesAsync();

        ////    return Ok(entity);
        ////}

        ////    [Route("loan")]
        ////    [HttpPost]
        ////    public async Task<IActionResult> CreateLoanRequest(RequestEditModel model)
        ////    {
        ////        if (model is null)
        ////            return BadRequest();

        ////        var entity = Model.Request.CreateLoanAdviceRequest(model.Name, model.Kind, 0, Guid.Empty, model.Contents, model.CustomerName, model.Phone, model.Email, model.Product);

        ////        _context.Requests.Add(entity);
        ////        await _context.SaveChangesAsync();

        ////        return Ok(entity);
        ////    }

        ////    [HttpPost]
        ////    public async Task<IActionResult> Create(RequestEditModel model)
        ////    {
        ////        if (model is null)
        ////            return BadRequest();

        ////        var entity = Model.Request.Create(model.Name, model.Kind, 0, Guid.Empty, model.Contents, model.File0, model.File1, model.File2, model.File3, model.File4, model.StartDate, model.EndDate, model.ApplicantId, model.CustomerName, model.Phone, model.Email, model.Product );

        ////        _context.Requests.Add(entity);
        ////        await _context.SaveChangesAsync();

        ////        return Ok(entity);
        ////    }

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id < 0)
        //    {
        //        return BadRequest();
        //    }

        //    var activity = await _context.Activities.FirstOrDefaultAsync(p => p.Id == id);

        //    if (activity is null)
        //        return NotFound();

        //    _context.Remove(activity);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[Route("{id:int}")]
        //[HttpPut]
        //public async Task<IActionResult> Put(int id, ActivityEditModel model)
        //{
        //    if (model is null || id < 0)
        //    {
        //        return BadRequest();
        //    }

        //    var existed = await _context.Activities.FirstOrDefaultAsync(e => e.Id == id);


        //    if (existed != null)
        //    {
        //        existed.ActivityTypeID = model.ActivityTypeID;
        //        existed.ProcessID = model.ProcessID;
        //        existed.Name = model.Name;
        //        existed.Description = model.Description;
                
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
        //                    var record = Activity.Create(
        //                        csv.GetField<int>("ActivityTypeID"),
        //                        csv.GetField<int>("ProcessID"),
        //                        csv.GetField<string>("Name"),
        //                        csv.GetField<string>("Description")
        //                        //
        //                    );

        //                    results.Successed += 1;
        //                    _context.Activities.Add(record);
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
            var result = _context.Activities.Where(c => true);

            var filePath = Path.GetTempFileName();
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteHeader<ActivityExportModel>();
                csv.NextRecord();
                foreach (var r in result)
                {
                    csv.WriteRecord(_mapper.Map<ActivityExportModel>(r));
                    csv.NextRecord();
                }

            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "text/csv", "export.csv");
        }
    }

}

