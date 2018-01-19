using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace keyswine.Models
{
    public class Wine
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Назва")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Опис")]
        public string Description { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        [Display(Name = "Категорія")]
        public Category Category { get; set; }
        [Required]
        [Display(Name = "Рік ")]
        public int Age { get; set; }

        [Display(Name = "фотографія")]
        public byte[] Photo { get; set; }
        [Required]
        [Display(Name = "Дата поставки")]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Display(Name = "Винороб")]
        public int? WinemakerId { get; set; }

        public Winemaker Winemaker { get; set; }
    }

    public class Winemaker
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "П.І.Б")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Електронна адресса")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Required]
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
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Категорія")]
        public string Name { get; set; }


        public ICollection<Wine> Wines { get; set; }
        public Category()
        {
            Wines = new List<Wine>();
        }
    }
}