using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace keyswine.Models
{
    public class Wine
    {
        public int Id { get; set; }

        [Display(Name = "Назва")]
        public string ProductName { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }
       
        public int? CategoryId { get; set; }

        [Display(Name = "Категорія")]
        public Category Category { get; set; }

        [Display(Name = "Рік ")]
        public int Age { get; set; }

        [Display(Name = "фотографія")]
        public byte[] Photo { get; set; }

        [Display(Name = "Дата поставки")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Винороб")]
        public int? WinemakerId { get; set; }

        public Winemaker Winemaker { get; set; }
    }

    public class Winemaker
    {
        public int Id { get; set; }

        [Display(Name = "П.І.Б")]
        public string Name { get; set; }
       
        [EmailAddress]
        [Display(Name = "Електронна адресса")]
        public string Email { get; set; }
        
        [Phone]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "День наробження")]
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
        [Display(Name = "Категорія")]
        public string Name { get; set; }


        public ICollection<Wine> Wines { get; set; }
        public Category()
        {
            Wines = new List<Wine>();
        }
    }
}