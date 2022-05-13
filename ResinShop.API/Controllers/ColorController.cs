using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResinShop.API.Models;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;

namespace ResinShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorRepository _colorRepository;

        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        [HttpGet]
        public IActionResult GetAllColor()
        {
            var result = _colorRepository.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        [HttpGet("{id}", Name = "GetColor")]
        public IActionResult GetColor(int id)
        {
            var result = _colorRepository.Get(id);

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
        public IActionResult AddColor(Color color)
        {
            if (ModelState.IsValid)
            {
                Color a = new Color
                {
                    ColorName = color.ColorName
                };

                var result = _colorRepository.Insert(a);

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetColor), new { id = a.ColorId }, a);
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
        public IActionResult EditColor(ColorModel colorModel)
        {
            if (ModelState.IsValid && colorModel.ColorId > 0)
            {
                Color color = new Color
                {
                    ColorId = colorModel.ColorId,
                    ColorName = colorModel.ColorName,
                };

                if (!_colorRepository.Get(color.ColorId).Success)
                {
                    return NotFound($"Color {color.ColorId} not found");
                }

                var result = _colorRepository.Update(color);

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
                if (colorModel.ColorId < 1)
                {
                    ModelState.AddModelError("colorId", "Invalid Color ID");
                }
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteColor(int id)
        {
            if (!_colorRepository.Get(id).Success)
            {
                return NotFound($"Color {id} not found");
            }

            var result = _colorRepository.Delete(id);

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
