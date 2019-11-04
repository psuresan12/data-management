using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManagement.Adapter;
using DataManagement.Models.ViewModel;
using DataManagement.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelReaderController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <response code="400">If the request content is Invalid.</response>
        /// <response code="404">If the request resource is not found.</response>
        /// <response code="406">If the client resource doesn't match server's content type and Header information.</response>
        /// <response code="500">If the server cannot process the request for an unknown reason.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Person), 200)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        [Route("GetCustomerBySheetName")]
        public ActionResult<IEnumerable<Person>> Get(ExcelReaderRequest request)
        {
           string fileurl= System.IO.Directory.GetCurrentDirectory()+"\\Excel Document\\"+request.fileName;
           var results =  new PersonAdaptor(fileurl, request.sheetName)
                                .Execute();
            return Ok(results);
           
        }

    }
}
