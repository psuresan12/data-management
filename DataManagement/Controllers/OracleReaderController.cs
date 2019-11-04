using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManagement.Adapter;
using DataManagement.Builder;
using DataManagement.Controllers.SampleController;
using DataManagement.Models.ViewModel;
using DataManagement.Request;
using DataManagement.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DataManagement.Controllers
{
    
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OracleReaderController : AbstractController
    {

        private CustomerAdapter adapter;
        private bool _isOracleDatabase = true;

        public OracleReaderController(IConfiguration configuration)
        {

            adapter = new CustomerAdapter(
                                configuration.GetConnectionString("OracleConnectionString"),
                                _isOracleDatabase);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <response code="400">If the item is null</response> 
        /// <response code="404">If the request resource is not found.</response>
        /// <response code="406">If the client resource doesn't match server's content type and Header information.</response>
        /// <response code="500">If the server cannot process the request for an unknown reason.</response>
        [ProducesResponseType(typeof(Dictionary<string, string>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [HttpPost]
        [Route("GetResultForQueryOrStoreProc")]
        public ActionResult<Dictionary<string, string>> PostAnyQuery(QueryType queryType,string queryString)
        {
            if (IsQueryInjected(queryString))
                return BadRequest();

            var request = new GetResultForQueryOrStoreProc
            {
                QueryType = queryType,
                QueryString = queryString
            };

            var result = adapter.GetDictionary(request);
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <response code="400">If the item is null</response> 
        /// <response code="404">If the request resource is not found.</response>
        /// <response code="406">If the client resource doesn't match server's content type and Header information.</response>
        /// <response code="500">If the server cannot process the request for an unknown reason.</response>
        [ProducesResponseType(typeof(CustomerViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [HttpPost]
        [Route("GetCustomer")]
        public ActionResult<CustomerViewModel> GetCustomerByParamOnly(CustomerViewModel customerViewModel)
        {
            var customers = adapter.GetViewModel(customerViewModel);
            return Ok(customers);
        }


        [ProducesResponseType(typeof(Dictionary<string, string>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [HttpPost]
        [Route("GetResultsFromQueryBank")]
        public ActionResult<Dictionary<string, string>> PostParam(QueryBank queryBank, Dictionary<string, string> parameters)
        {
            parameters.Remove("queryBank");
            var request = new GetResultFromQueryBankRequest
            {
                QueryBank = queryBank,
                Parameters = parameters
            };

            var results = adapter.GetDictionary(request);
            return Ok(results);
        }


    }
}
