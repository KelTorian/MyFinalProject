using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Test.Utilities.Results;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);

            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            return new SuccessResult(Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {
            // İş Kodaları
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanenceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetails());
        }
    }
}
