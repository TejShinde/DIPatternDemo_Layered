using DIPatternDemo_Layered .Data;
using DIPatternDemo_Layered .Models;

namespace DIPatternDemo_Layered .Repositories
    {
    public class ProductRepository : IProductRepository
        {
        private readonly ApplicationDBContext db;
        public ProductRepository ( ApplicationDBContext db )
            {
            this .db = db;
            }
        public int AddProduct ( Product prod )
            {
            int result = 0;
            db .Products .Add(prod);
            result = db .SaveChanges();
            return result;
            }

        public int DeleteProduct ( int id )
            {
            int result = 0;
            var p = db .Products .Where(x => x .ProductId == id) .SingleOrDefault();
            if ( p != null )
                {
                db .Products .Remove(p);
                result = db .SaveChanges();
                }
            return result;
            }

        public Product GetProductById ( int id )
            {

            var res = (from p in db .Products
                       join c in db .Categories on p .CategoryId equals c .CategoryId
                       where p .ProductId == id
                       select new Product
                           {
                           ProductId = p .ProductId ,
                           ProductName = p .ProductName ,
                           Price = p .Price ,
                           CategoryId = c .CategoryId ,
                           CategoryName = c .CategoryName ,
                           ImageUrl = p .ImageUrl
                           }) .FirstOrDefault();
            return res;
            //return db .Products .Where(x => x .ProductId == id) .SingleOrDefault();
            }
        public IEnumerable<Product> GetProducts ()
            {
            var result = (from p in db .Products
                          join c in db .Categories on p .CategoryId equals c .CategoryId
                          select new Product
                              {
                              ProductId = p .ProductId ,
                              ProductName = p .ProductName ,
                              Price = p .Price ,
                              CategoryId = p .CategoryId ,
                              CategoryName = c .CategoryName ,
                              ImageUrl = p .ImageUrl
                              }) .ToList();
            return result;
            }

        public int UpdateProduct ( Product prod )
            {
            int result = 0;
            var p = db .Products .Where(x => x .ProductId == prod .ProductId) .SingleOrDefault();
            if ( p != null )
                {
                // db .Entry(prod) .State = Microsoft .EntityFrameworkCore .EntityState .Modified;
                //Or
                p .ProductName = prod .ProductName;
              //  p .CategoryName = prod .CategoryName;
                p .Price = prod .Price;
                p .CategoryId = prod .CategoryId;
                p .ImageUrl = prod .ImageUrl;
                result = db .SaveChanges();
                }
            return result;

            }
        }
    }
