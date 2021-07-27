using OnlineShop.Core.Abstractions;
using OnlineShop.Core.Abstractions.Operations;
using OnlineShop.Core.BusinessModels;
using OnlineShop.Core.Exceptions;
using System;

namespace OnlineShop.BLL.Operations
{
    public class ProductOperation : IProductOperation
    {
        private readonly IRepositoryManager _repositoryes;
        public ProductOperation(IRepositoryManager repositoryes)
        {
            _repositoryes = repositoryes;
        }
        public void AddProduct(ProductModel model)
        {
            _repositoryes.Products.AddProduct(model);
            _repositoryes.SaveChanges();
            //var category = _repositoryes.Categoryes.Get((int)model.CategoryId);
            //if (category == null)
            //     throw new LogicException("There is no category with that Id");
            //using (var transaction = _repositoryes.BeginTransaction())
            //{
            //    try
            //    {

            //        
            //        transaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //        throw;
            //    }
            //}
        }
    }
}
