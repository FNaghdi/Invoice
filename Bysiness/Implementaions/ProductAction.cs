using Business.DTOs;
using Business.Services;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Implementaions
{
    public class ProductAction : IProductAction
    {
        PersonContext _PersonContext;
        public ProductAction(PersonContext personContext) { 
            _PersonContext = personContext;
        }
        public void Delete(int idp)
        {
            var product = _PersonContext.people.FirstOrDefault(p => p.ID == idp);
            if (product != null)
            {
                _PersonContext.people.Remove(product);
                _PersonContext.SaveChanges();
            }

        }

     

        public void Save(ProductModel productModel)
        {
          Product product =  new Product(); 
            product.Mark=productModel.Mark;
            product.ProductName=productModel.ProductName;   
            product.ProductCode=productModel.ProductCode;   
            _PersonContext.Add(product);
            _PersonContext.SaveChanges();

        }

        public void Update(Product product)
        {
            try { 
          var productt = _PersonContext.products.FirstOrDefault(p => p.ID == product.ID);
           
            productt.Mark = product.Mark;   

            productt.ProductName=product.ProductName;
            productt.ProductCode=product.ProductCode;



            if (product != null)
            {
                Console.WriteLine(product.ID);
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



}
    }

        
    
}
