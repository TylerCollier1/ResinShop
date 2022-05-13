using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResinShop.API.Models;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;

namespace ResinShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        [HttpGet]
        public IActionResult GetAllMaterial()
        {
            var result = _materialRepository.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        [HttpGet("{id}", Name = "GetMaterial")]
        public IActionResult GetMaterial(int id)
        {
            var result = _materialRepository.Get(id);

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
        public IActionResult AddMaterial(Material material)
        {
            if (ModelState.IsValid)
            {
                Material a = new Material
                {
                    MaterialName = material.MaterialName
                };

                var result = _materialRepository.Insert(a);

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetMaterial), new { id = a.MaterialId }, a);
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
        public IActionResult EditMaterial(MaterialModel materialModel)
        {
            if (ModelState.IsValid && materialModel.MaterialId > 0)
            {
                Material material = new Material
                {
                    MaterialId = materialModel.MaterialId,
                    MaterialName = materialModel.MaterialName,
                };

                if (!_materialRepository.Get(material.MaterialId).Success)
                {
                    return NotFound($"Material {material.MaterialId} not found");
                }

                var result = _materialRepository.Update(material);

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
                if (materialModel.MaterialId < 1)
                {
                    ModelState.AddModelError("materialId", "Invalid Material ID");
                }
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(int id)
        {
            if (!_materialRepository.Get(id).Success)
            {
                return NotFound($"Material {id} not found");
            }

            var result = _materialRepository.Delete(id);

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
