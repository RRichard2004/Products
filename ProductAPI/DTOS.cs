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
            string Product_Name,
            int Product_Price
            );

        public record UpdateProductDTO(
            string Product_Name,
            int Product_Price
            );

    }
}
