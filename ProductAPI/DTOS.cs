using System.ComponentModel.DataAnnotations;

namespace ProductAPI
{
    public class DTOS//Data Transfer Object
    {
        public record ProductDTO(
            Guid ID,
            string Product_Name,
            int Product_Price,
            DateTimeOffset Time_Created,
            DateTimeOffset Time_Modified
            );

        public record CreateProductDTO(
            [Required]string Product_Name,
            [Range(0 , 10000)] int Product_Price
            );

        public record UpdateProductDTO(
            [Required] string Product_Name,
            [Range(0, 10000)] int Product_Price
            );

    }
}
