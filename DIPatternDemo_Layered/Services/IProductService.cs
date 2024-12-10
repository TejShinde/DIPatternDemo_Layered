﻿using DIPatternDemo_Layered .Models;

namespace DIPatternDemo_Layered .Services
    {
    public interface IProductService
        {
        IEnumerable<Product> GetProducts ();
        Product GetProductById ( int id );
        int AddProduct ( Product prod );
        int UpdateProduct ( Product prod );
        int DeleteProduct ( int id );
        }
    }
