using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p=>p.IsDelete==false);
        }
        public IQueryable<Product> All(bool isAll)
        {
            if (isAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
           
        }
        public override void Delete(Product entity)
        {
            entity.IsDelete = true;
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}