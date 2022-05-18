using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResinShop.Core.Interfaces.DAL;

namespace ResinShop.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ReportsController : ControllerBase
        {
            private readonly IReportsRepository _reportsRepository;

            public ReportsController(IReportsRepository reportsRepository)
            {
                _reportsRepository = reportsRepository;
            }

            [HttpGet]
            public IActionResult GetLargeOrders()
            {
                var result = _reportsRepository.GetOrdersOver5000();

                if (result.Success)
                {
                    return Ok(result.Data);
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }

            [HttpGet]
            [Route("/api/[controller]/large-art", Name = "LargeArt")]
            public IActionResult GetLargeArtPiece()
            {
                var result = _reportsRepository.GetLargeArtPieces();

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
