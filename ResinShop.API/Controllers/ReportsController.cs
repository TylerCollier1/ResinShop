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
        [Route("/api/[controller]/orderdetail/{id}", Name = "OrderDetail")]
        public IActionResult GetOrderDetail(int id)
            {
                var result = _reportsRepository.GetOneOrderDetails(id);

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


        [HttpGet]
        [Route("/api/[controller]/large-order", Name = "LargeOrder")]
        public IActionResult GetLargeOrder()
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
        [Route("/api/[controller]/orderdisplay", Name = "OrdersInfo")]
        public IActionResult GetOrderDisplay()
        {
            var result = _reportsRepository.GetOrderDisplay();

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
