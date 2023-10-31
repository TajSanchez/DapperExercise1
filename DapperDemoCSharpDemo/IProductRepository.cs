﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoCSharpDemo
{
    public interface IProductRepository
    {

        public IEnumerable<Product> GetAllProducts();
        public void InsertProduct(string name, double price, int categoryID);
        public Product GetProduct(int id);
        public void UpdateProduct(Product product);
    }

}