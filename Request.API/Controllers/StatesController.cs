﻿using System;
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
    public class StatesController : ControllerBase
    {
        private RequestContext _context;
        private IMapper _mapper;
        private readonly ILogger _logger;

        public StatesController(RequestContext context,
            IMapper mapper,
            ILogger<RequestsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        //public async Task<IActionResult> Get([FromQuery]string filter, [FromQuery]int pageSize = 10, [FromQuery] int pageIndex = 0)
        //{
        //    var result = _context.States.Where(c => true);

        //    if (!string.IsNullOrEmpty(filter))
        //        result = result.Where(c => c.Name.Contains(filter, StringComparison.InvariantCultureIgnoreCase)
        //                                || c.Name.Contains(filter, StringComparison.InvariantCultureIgnoreCase));


        //    var totalItems = await result.LongCountAsync();

        //    var itemsOnPage = await result
        //            .OrderBy(c => c.Name)
        //            .Skip(pageIndex * pageSize)
        //            .Take(pageSize)
        //            .ToListAsync();

        //    var model = new PaginatedItems<StateViewModel>(pageIndex, pageSize, totalItems, itemsOnPage.Select(o => new StateViewModel
        //    {
        //        Id = o.Id,
        //        Name = o.Name,
        //        Description = o.Description,
        //        StateTypeID = o.StateTypeID,
        //        ProcessID = o.ProcessID

        //    }));

        //    return Ok(model);
        //}

        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetItemById(int id)
        //{
        //    var item = await _context.States.SingleOrDefaultAsync(l => l.Id == id);

        //    if (item is null)
        //        return NotFound();

        //    return Ok(_mapper.Map<StateViewModel>(item));
        //}

        ////[HttpPost]
        ////public async Task<IActionResult> CreateGenericRequest(StateEditModel model)
        ////{
        ////    if (model is null)
        ////        return BadRequest();

        ////    var entity = State.Create( model.StateTypeID, model.ProcessID, model.Name, model.Description);

        ////    _context.States.Add(entity);
        ////    await _context.SaveChangesAsync();

        ////    return Ok(entity);
        ////}

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

        //    var state = await _context.States.FirstOrDefaultAsync(p => p.Id == id);

        //    if (state is null)
        //        return NotFound();

        //    _context.Remove(state);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[Route("{id:int}")]
        //[HttpPut]
        //public async Task<IActionResult> Put(int id, StateEditModel model)
        //{
        //    if (model is null || id < 0)
        //    {
        //        return BadRequest();
        //    }

        //    var existed = await _context.States.FirstOrDefaultAsync(e => e.Id == id);


        //    if (existed != null)
        //    {
        //        existed.StateTypeID = model.StateTypeID;    
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
        //                    var record = State.Create(
        //                        csv.GetField<int>("StateTypeID"),
        //                        csv.GetField<int>("ProcessID"),
        //                        csv.GetField<string>("Name"),
        //                        csv.GetField<string>("Description")
        //                        //
        //                    );

        //                    results.Successed += 1;
        //                    _context.States.Add(record);
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
            var result = _context.States.Where(c => true);

            if (!string.IsNullOrEmpty(filter))
                result = result.Where(c => c.Name.Contains(filter, StringComparison.InvariantCultureIgnoreCase)
                                        || c.Name.Contains(filter, StringComparison.InvariantCultureIgnoreCase));

            var filePath = Path.GetTempFileName();
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteHeader<StateExportModel>();
                csv.NextRecord();
                foreach (var r in result)
                {
                    csv.WriteRecord(_mapper.Map<StateExportModel>(r));
                    csv.NextRecord();
                }

            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "text/csv", "export.csv");
        }
    }

}

