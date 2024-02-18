using RealEstateApi.Dtos.ProductDtos;

namespace RealEstateApi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<List<ResultProductsWithCategoryDto>> GetAllProductsWithCategoryAsync();
        void CreateProduct(CreateProductDto productDto);
        void DeleteProduct(int id);
        void UpdateProduct(UpdateProductDto productDto);
        Task<GetProductByIdDto> GetProductById(int id);
    }
}
