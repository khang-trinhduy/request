using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Request.API.Infrastructure;
using Request.API.ViewModels;
using SharedKernel.Abstractions;

namespace Request.API.Controllers
{
    public class ProcessController : ControllerBase
    {
        public RequestContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public ProcessController(RequestContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string filter, [FromQuery]int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var processes = _context.Processes.Include(p => p.Nodes)
                .Include(p => p.States)
                .Include(p => p.Rules)
                .Include(p => p.Activities);
            
            var totalItems = await processes.LongCountAsync();

            var itemsOnPage = await processes.Skip(pageIndex * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
            var model = new PaginatedItems<ProcessViewModel>(pageIndex, pageSize, totalItems, itemsOnPage.Select( p => new ProcessViewModel {
                Actions = _mapper.Map<List<ActionViewModel>>(p.Actions),
                Name = p.Name

            }));
            return Ok(model);
        }
    }
}