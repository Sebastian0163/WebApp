using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace keyswine.Models
{
    public class Wine
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int Age { get; set; }
        public byte[] Photo { get; set; }
        public DateTime PurchaseDate { get; set; }

        public int? WinemakerId { get; set; }
        public Winemaker Winemaker { get; set; }
    }

    public class Winemaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime PurchaseDate { get; set; }

        public ICollection<Wine> Wines { get; set; }
        public Winemaker()
        {
            Wines = new List<Wine>();
        }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Wine> Wines { get; set; }
        public Category()
        {
            Wines = new List<Wine>();
        }
    }
}