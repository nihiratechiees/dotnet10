using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myApi.Model;

namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products=new List<Product>()
        {
            new Product{Id=1,Name="Laptop",Price=30000},
             new Product{Id=2,Name="Mobile",Price=15000},
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,Product product)
        {
            var _prod=products.FirstOrDefault(p => p.Id == id);
            if( _prod == null )
            {
                return NotFound();
            }
            _prod.Name = product.Name;
            _prod.Price = product.Price;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _prod = products.FirstOrDefault(p => p.Id == id);
            if (_prod == null)
            {
                return NotFound();
            }
            products.Remove(_prod);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Getbycode(int id)
        {
            var _prod = products.FirstOrDefault(p => p.Id == id);
            if (_prod == null)
            {
                return NotFound();
            }
            return Ok(_prod);
        }
    }
}
