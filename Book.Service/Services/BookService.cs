using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Services
{
    public class BookService : IService<Product>
    {
        private readonly IRepository<Product> _productRepository;
        public BookService(IRepository<Product> productRepository)
        {
            this._productRepository = productRepository;
        }
        public void Create(Product product)
        {
            _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public IEnumerable<Product> GetAll(string name = null)
        {
            return string.IsNullOrEmpty(name)
                ? _productRepository.GetAll()
                : _productRepository.GetAll().Where(c => c.ProductName == name);
        }

        public Product GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public Product GetByName(string name)
        {
            return _productRepository.GetByName(name);
        }
    }
}
