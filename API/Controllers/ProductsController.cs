using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _repo.GetProductsAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrand = await _repo.GetProductBrandsAsync();
            if (productBrand == null)
            {
                return NotFound();
            }

            return Ok(productBrand);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            var productType = await _repo.GetProductTypesAsync();
            if (productType == null)
            {
                return NotFound();
            }

            return Ok(productType);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _storeContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _storeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _storeContext.Products.Add(product);
            await _storeContext.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _storeContext.Products.Remove(product);
            await _storeContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _storeContext.Products.Any(e => e.Id == id);
        }*/
    }
}
