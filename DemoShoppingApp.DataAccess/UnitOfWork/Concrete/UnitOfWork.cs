using DemoShoppingApp.DataAccess.DbContext;
using DemoShoppingApp.DataAccess.Repositories.Abstract;
using DemoShoppingApp.DataAccess.Repositories.Concrete;
using DemoShoppingApp.DataAccess.UnitOfWork.Abstract;

namespace DemoShoppingApp.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }

        public UnitOfWork(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
            Category = new CategoryRepository(dbContext);
            Product = new ProductRepository(dbContext);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}