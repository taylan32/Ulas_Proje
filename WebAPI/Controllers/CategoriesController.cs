using Business.Abstract;
using Business.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _categoryService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateCategoryRequestDto request)
        {
            var result = _categoryService.Add(request);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateCategoryRequestDto request)
        {
            var result = _categoryService.Update(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            // deleteById void olduğu için birşeye eşitlenmedi
            _categoryService.DeleteById(id);
            return Ok();
        }


    }
}
