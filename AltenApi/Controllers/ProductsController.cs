using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        //[HttpGet("{id}")]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        //public async Task<ActionResult<ProductDto>> GetProductById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _service.CreateProductAsync(payload);

            //return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            return Created($"/api/products/{product.Id}", product);

        }
    }
}
