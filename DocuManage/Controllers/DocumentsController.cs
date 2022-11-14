using DocuManage.Common.Requests;
using DocuManage.Data.Interfaces;
using DocuManage.Data.Models;
using DocuManage.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DocuManage
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documents;

        public DocumentsController(IDocumentService documents)
        {
            _documents = documents;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var document = await _documents.GetDocumentInfo(id);

            if(document == null) return NotFound();

            return Ok(document);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDocumentRequest request)
        {
            var folder = await _documents.GetFolder(request.Folder);

            if (folder == null) return BadRequest();

            var document = new DocumentDto()
            {
                Folder = folder.Id ?? Guid.Empty,
                Name = request.Name
            };

            var newDocument = await _documents.CreateDocument(document);

            return Ok(newDocument);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
