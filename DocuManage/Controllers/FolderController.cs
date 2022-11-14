﻿using DocuManage.Common.Models;
using DocuManage.Common.Requests;
using DocuManage.Data.Models;
using DocuManage.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DocuManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public FolderController(IDocumentService documentService)
        {
            _documentService = documentService;
        }


        // GET: api/<FolderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FolderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var folder = await _documentService.GetFolder(new Guid(id));
            if (folder is null)
            {
                return NotFound();
            }
            return Ok(folder);
        }

        // POST api/<FolderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostFolderRequest request)
        {
            if(request.Parent == null)
                request.Parent = Guid.Empty;

            var folder = new FolderDto()
            {
                Name = request.Name,
                Parent = request.Parent,
            };

            var newFolder = await _documentService.CreateFolder(folder);

            if (newFolder is null)
            {
                return BadRequest();
            }

            return Ok(newFolder);
        }

        // PUT api/<FolderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FolderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}