﻿using DocuManage.Common.Models;
using DocuManage.Common.Requests;
using DocuManage.Data.Interfaces;
using DocuManage.Data.Models;
using DocuManage.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DocuManage
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documents;
        private readonly ILogger _log;

        public DocumentsController(IDocumentService documents, ILoggerFactory loggerFactory)
        {
            _documents = documents;
            _log = loggerFactory.CreateLogger<DocumentsController>();
        }

        // GET api/<DocumentsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DocumentDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDocument(Guid id)
        {
            var document = await _documents.GetDocumentInfo(id);

            if (document == null) return NotFound();

            return Ok(document);
        }

        [HttpGet("{id}/file")]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDocumentFile(Guid id)
        {
            var document = await _documents.GetDocumentInfo(id);

            if (document == null) return NotFound();

            var file = await _documents.GetFileStream(id);

            return new FileStreamResult(file, "application/pdf");
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(DocumentDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] UpdateDocumentRequest request)
        {
            var result = await _documents.UpdateDocument(id, request);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<DocumentsController>
        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        [ProducesResponseType(typeof(DocumentDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromForm] PostDocumentRequest request)
        {
            var folder = await _documents.GetFolder(request.Folder);

            if (folder == null && request.Folder != Guid.Empty) return BadRequest();

            var document = new Document()
            {
                Folder = folder?.Id ?? Guid.Empty,
                Name = request.Name
            };

            var newDocument = await _documents.CreateDocument(document, request.File.Single());

            return Ok(newDocument);
        }
    }
}