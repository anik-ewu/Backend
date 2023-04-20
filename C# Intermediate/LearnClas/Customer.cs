
using System;
using System.Collections.Generic;

namespace LearnClas
{
    public class Customer
    {
        public int Id;
        public string Name;
        public List<Order> Orders;

        public Customer()
        {
            this.Id = 1;
            this.Name = "Sabbir";
            Orders = new List<Order>();

        }

    }
}
