using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WikiLibsDiscordBot.Controllers
{
    [Route("webhooks")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ServiceQueue _service;

        public ValuesController(ServiceQueue service)
        {
            _service = service;
        }

        [HttpGet]
        public string Test()
        {
            return ("The server is running");
        }

        [HttpPost("{hook}")]
        public async Task<IActionResult> Post([FromRoute] string hook)
        {
            using (var reader = new StreamReader(HttpContext.Request.Body))
            {
                var str = await reader.ReadToEndAsync();
                var msg = AzureParser.ParseAzure(str);

                msg.HookName = hook;
                _service.Messages.Enqueue(msg);
            }   
            return (Ok());
        }
    }
}
