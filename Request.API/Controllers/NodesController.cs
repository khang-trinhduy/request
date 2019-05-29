using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Request.API.Infrastructure;
using Request.API.Models;

namespace Request.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        public RequestContext _context;
        public NodesController(RequestContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Node node) {
            // var options = new DbContextOptionsBuilder<MemoryContext>()
            //     .UseInMemoryDatabase(databaseName: "meorydb")
            //     .Options;
            // using (_context = new MemoryContext(options))
            // {
            //     _context.Nodes.Add(node);
            //     _context.SaveChanges();
            // }
            if (node is null)
            {
                return NotFound();
            }
            _context.Add(node);
            _context.SaveChanges();
            return Ok(node);
        }

        [HttpPost]
        public IActionResult CreateMultiple([FromBody] List<Node> nodes) {
            if (nodes is null)
            {
                return NotFound();
            }
            foreach (var node in nodes)
            {
                _context.Add(node);
            }
            _context.SaveChanges();
            return Ok(nodes.Count);
        }

        [HttpGet]
        public List<Node> Get() {
            var nodes = _context.Nodes.ToList();
            return nodes;
        }
        [HttpGet]
        [Route("{id:int}")]
        public Node Get(int id) {
            var node = _context.Nodes.Find(id);
            if (node is null) {
                return null;
            }
            return node;
        }

        [HttpGet]
        [Route("paths/{id:int}")]
        public IActionResult GetPaths(int id) {
            var node = _context.Nodes.Find(id);
            if (node is null) {
                return NotFound();
            }
            var paths = node.GetPossiblePath();
            return Ok(paths);
        }
        [HttpDelete]
        [Route("id:int")]
        public IActionResult Delete(int id)
        {
            var node = _context.Nodes.Find(id);
             if (node is null) {
                return NotFound();
            }
            int success = node.Remove();
            _context.SaveChanges();
            return Ok($"removed {success} nodes");
        }
        [HttpPut]
        [Route("id:int")]
        public IActionResult Edit(int id, [FromBody] Node node) {
            if (node is null) {
                return NotFound(node);
            }
            var tmp_node = _context.Nodes.Find(id);
            if (tmp_node is null) {
                return NotFound(tmp_node);
            }
            tmp_node = node;
            _context.Update(tmp_node);
            _context.SaveChanges();
            return Ok(tmp_node);
        }
        [HttpPut]
        public IActionResult AddChild(int id, [FromBody] Node child) {
            if (child is null) {
                return NotFound();
            }
            var node = _context.Nodes.FirstOrDefault(n => n.Id == id);
            if (node is null) {
                return NotFound();
            }
            var tmp = _context.Nodes.FirstOrDefault(n => n.Name.Equals(child.Name));
            if (tmp is null) {
                return NotFound();
            }
            node.AddChild(child);
            _context.Update(node);
            _context.SaveChanges();
            return Ok(node);
        }
        [HttpGet]
        [Route("/Move")]
        public IActionResult Move(string name) {
            if (name.Equals("")) {
                return NotFound();
            }
            var node = _context.Nodes.FirstOrDefault(n => n.Name.Equals(name));
            if (node is null) {
                return NotFound();
            }
            return Ok(node.Move(name));
        }
    }
}