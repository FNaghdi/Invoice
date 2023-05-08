using Business.DTOs;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductAction
    {

        void Save( ProductModel productModel);
        void Update(Product product);
        void Delete(int idp);
    }
}
