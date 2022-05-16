using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResinShop.Core.Interfaces.DAL;

namespace ResinShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerQuotesController : ControllerBase
    {
        private readonly IReportsRepository _reportsRepository;

        public CustomerQuotesController(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        [HttpGet("{id}", Name = "AllQuotes")]
        public IActionResult GetAllQuotes(int id)

        {
            var result = _reportsRepository.GetCustomerQuotes(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

    }
}
