using Microsoft.AspNetCore.Mvc;
using Rest.Dal;

namespace Rest.Web {

    [ApiController]
    public class HelloWorldController : ControllerBase {

        private readonly IDocumentRepository _documentRepository;

        public HelloWorldController(IDocumentRepository documentRepository) {
            Console.WriteLine("HelloWorldController");
            _documentRepository = documentRepository;
        }

        [HttpGet]
        [Route("/")]
        public virtual string ApiGet() {
            return "Hello World!";
        }

        [HttpGet]
        [Route("/api/ui_settings")]
        public virtual string UiSettings() {
            return "{}";
        }
    }
}
