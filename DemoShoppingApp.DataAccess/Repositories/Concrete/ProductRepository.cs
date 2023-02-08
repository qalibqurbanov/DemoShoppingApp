using System.Linq;
using DemoShoppingApp.DataAccess.DbContext;
using DemoShoppingApp.DataAccess.Models;
using DemoShoppingApp.DataAccess.Repositories.Abstract;

namespace DemoShoppingApp.DataAccess.Repositories.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            this.dbContext = _dbContext;
        }

        public void Update(Product product)
        {
            Product prod = this.dbContext.Products.FirstOrDefault(p => p.ID == product.ID);

            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.ProductDescription = product.ProductDescription;
                prod.ProductPrice = product.ProductPrice;
                prod.ProductImageUrl = product.ProductImageUrl;
            }
        }
    }
}