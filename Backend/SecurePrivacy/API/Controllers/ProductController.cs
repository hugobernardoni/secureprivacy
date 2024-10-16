using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Repositories.Interfaces;
using AutoMapper;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(ProductDto productDto) 
        {
            var product = _mapper.Map<Product>(productDto); 
            await _repository.Create(product);
            var createdProductDto = _mapper.Map<ProductDto>(product); 
            return CreatedAtAction(nameof(GetById), new { id = createdProductDto.Id }, createdProductDto);
        }

        [HttpPut("{id}")] 
        public async Task<ActionResult<ProductDto>> Update(string id, ProductDto productDto)
        {
            var existingProduct = await _repository.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _mapper.Map(productDto, existingProduct);
            await _repository.Update(existingProduct);

            var updatedProductDto = _mapper.Map<ProductDto>(existingProduct);
            return Ok(updatedProductDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var products = await _repository.GetAll();
            var productDtos = _mapper.Map<List<ProductDto>>(products); 
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(string id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDto>(product); 
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }
    }
}
