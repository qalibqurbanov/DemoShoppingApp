using DemoShoppingApp.DataAccess.Repositories.Abstract;

namespace DemoShoppingApp.DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }

        void SaveChanges();
    }
}