using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



namespace EntityRelationships
{

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<CustomerProductOrder> CustomerOrder { get; set; }
        //links the one to many relationship
    }


    class Order
    {
        public int Id { get; set; }
        public DateTime Order_date { get; set; }
        public string Order_status { get; set; }
        public List<CustomerProductOrder> CustomerProducts { get; set; }
    }


    class CustomerProductOrder
    {
        public int Id { get; set; }
        public Product Product_quantity { get; set; }
        public Order Order_revenue { get; set; }

    }



    class ProductOrdersContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerProductOrder> CustomerProductOrders { get; set; }


        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=EntityRelationships;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


    }




    class Program
    {
        static void Main(string[] args)
        {
            using (ProductOrdersContext context = new ProductOrdersContext())
            {
                context.Database.EnsureCreated();

                Product product = new Product
                {
                    Name = "civic",
                    Price = 16000
                };


                Order order = new Order
                {
                    Order_date = DateTime.Now,
                    Order_status = "complete"
                };


                CustomerProductOrder customerproductorder = new CustomerProductOrder
                {
                    Product_quantity = product,
                    Order_revenue = order
                };


                context.Products.Add(product);
                context.Orders.Add(order);
                context.CustomerProductOrders.Add(customerproductorder);

                context.SaveChanges();

 

                //LINQ queries:
       
                public CustomerProductOrder LINQOperations()

                // List all orders where a product is sold  

                Order orders_altima = DbContext.Orders
                .Include(o => o.Id)
                .Where(p => p.Name == "altima");                      
                

                // For a given product, find the order where it is sold the maximum.
                
                 CustomerProductOrder civic_max_order = DbContext.CustomerProductOrders
                .Include(cpo => cpo.Product_quantity)
                .Where(p => p.Name == "civic")
                .OrderbyDecending(cpo.Product_quantity);




            }

        }

    }






}



