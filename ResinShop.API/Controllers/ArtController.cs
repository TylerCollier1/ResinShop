using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResinShop.API.Models;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;

namespace ResinShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly IArtRepository _artRepository;

        public ArtController(IArtRepository artRepository)
        {
            _artRepository = artRepository;
        }

        [HttpGet]
        public IActionResult GetAllArt()
        {
            var result = _artRepository.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        [HttpGet("{id}", Name = "GetArt")]
        public IActionResult GetArt(int id)
        {
            var result = _artRepository.Get(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        public IActionResult AddArt(Art art)
        {
            if (ModelState.IsValid)
            {
                Art a = new Art
                {
                    Height = art.Height,
                    Width = art.Width,
                    MaterialQuantity = art.MaterialQuantity,
                    ColorQuantity = art.ColorQuantity,
                    AdvancedFeatureId = art.AdvancedFeatureId, //THIS MAY CAUSE SOME LOGISTICAL COMPLICATIONS
                    Cost = art.Cost
                };

                var result = _artRepository.Insert(a); //ISSUE BECAUSE CORE ERROR

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetArt), new { id = a.ArtId }, a);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult EditArt(ArtModel artModel)
        {
            if (ModelState.IsValid && artModel.ArtId > 0)
            {
                Art art = new Art
                {
                    ArtId = artModel.ArtId,
                    Height = artModel.Height,
                    Width = artModel.Width,
                    MaterialQuantity = artModel.MaterialQuantity,
                    ColorQuantity=artModel.ColorQuantity,
                    AdvancedFeatureId = artModel.AdvancedFeatureId,
                    Cost = artModel.Cost
                };

                if (!_artRepository.Get(art.ArtId).Success)
                {
                    return NotFound($"Art {art.ArtId} not found");
                }

                var result = _artRepository.Update(art);

                if (result.Success)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                if (artModel.ArtId < 1)
                    ModelState.AddModelError("artId", "Invalid Art ID");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArt(int id)
        {
            if (!_artRepository.Get(id).Success)
            {
                return NotFound($"Art {id} not found");
            }

            var result = _artRepository.Delete(id);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
