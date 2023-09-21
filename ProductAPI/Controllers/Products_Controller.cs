using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ProductAPI.DTOS;

namespace ProductAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class Products_Controller : ControllerBase
    {
        private static readonly List<ProductDTO> ProductList = new()
        {
            new ProductDTO(Guid.NewGuid(),
                "Termék1",
                2500,
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow
                ),
            new ProductDTO(Guid.NewGuid(),
                "Termék2",
                3000,
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow
                ),
            new ProductDTO(Guid.NewGuid(),
                "Termék3",
                3500,
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow
                )
        };

        [HttpGet("Mindent Kiír")]
        public IEnumerable<ProductDTO> GetAll()
        {
            return ProductList;
        }

        [HttpGet("Id Keresés")]
        public ActionResult<ProductDTO> GetById(Guid id) 
        {
            var item = ProductList.Find(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("Feltölt")]
        public ActionResult<ProductDTO> PostNewProduct(CreateProductDTO create_P)
        {
            var created = new ProductDTO(
                Guid.NewGuid(),
                create_P.Product_Name,
                create_P.Product_Price,
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow
                );
           
            ProductList.Add(created);
            return CreatedAtAction(nameof(GetById) , new {id=created.ID } , created);
        }

        [HttpPut("Edit")]
        public ProductDTO EditProductById(Guid ID, UpdateProductDTO update)
        { 
            var megadott = ProductList.Find(x=>x.ID==ID);
            var az = megadott with
            {
                Product_Name = update.Product_Name,
                Product_Price = update.Product_Price,
                Time_Modified = DateTimeOffset.UtcNow
            };

            ProductList[ProductList.FindIndex(x => x.ID == ID)] = az;
            return az;
        }

        [HttpDelete("Törlés")]
        public ActionResult DeleteById(Guid ID) 
        {
            var megadott = ProductList.Find(x => x.ID == ID);
            if (!ProductList.Contains(megadott))
            {
                ProductList.Remove(megadott);
                return NoContent();
            }
            return NotFound();
        }

    }
}
