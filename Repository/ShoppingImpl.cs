using PostgresSQL.API.Model;
using PostgresSQL.API.DBContext;

namespace PostgresSQL.API.Repository
{
    public class ShoppingImpl
    {
        private EF_DataContext? _context;
        public ShoppingImpl(EF_DataContext context)
        {
            _context = context;

        }

        public List<Product> GetProducts()
        {
            List<Product> response = new List<Product>();
            var dataList = _context?.Products.ToList();
            dataList?.ForEach(row => response.Add(new Product()
            {
                brand = row.brand,
                id = row.id,
                name = row.name,
                price = row.price,
                size = row.size
            }));

            return response;
        }

        public Product GetProductByID(Guid id)
        {
            Product response = new Product();
            var row = _context.Products.Where(db => db.id.Equals(id)).FirstOrDefault();
            return new Product()
            {
                brand = row.brand,
                id = row.id,
                name = row.name,
                price = row.price,
                size = row.size
            };
        }

        public void SaveOrder(Order ordermodel)
        {
            Order dbTable = _context.Orders.FirstOrDefault(d => d.id == ordermodel.id);

            if (dbTable == null)
            {
                dbTable = new Order();
                _context.Orders.Add(dbTable);
            }

            dbTable.phone = ordermodel.phone;
            dbTable.address = ordermodel.address;
            dbTable.name = ordermodel.name;
            dbTable.product = _context.Products.FirstOrDefault(f => f.id == ordermodel.product_id);

            _context.SaveChanges();
        }

        public void DeleteOrder(Guid id)
        {
            var order = _context.Orders.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

    }
}