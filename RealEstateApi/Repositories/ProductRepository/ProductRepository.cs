using Dapper;
using RealEstateApi.Dtos.ProductDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public void CreateProduct(CreateProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var query = "select * from Product";
            using(var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<ResultProductDto>(query);
                return products.ToList();
            }
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetAllProductsWithCategoryAsync()
        {
            var query = "select productId,Title,Price,coverImage,city,district,adress,Description,categoryName from Product inner join Category on Product.productCategory= " +
                "Category.categoryId";
            using (var connection = _context.CreateConnection())
            {
                var products =await connection.QueryAsync<ResultProductsWithCategoryDto>(query);
                return products.ToList();
            }
        }

        public Task<GetProductByIdDto> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(UpdateProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
