using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CalculateSalesPrice_MVC.Models
{
    public class Quotation
    {
        [Key]
        public int QuotationId { get; set; }    

        [Display(Name ="Full Price")]

        public double SalePrice { get; set; }
        [Display(Name = " Discount Percent")]

        public double Discount { get; set; }
        [Display(Name =" Discount Amount")]
        
        public double DiscountAmount { get; set; }  
        [Display(Name ="Your New Price")]

        public double TotalPrice { get; set; }

        public DateTime CreateAt { get; set; }

        public void CalculateDiscountAmount()
        {
            DiscountAmount = SalePrice * Discount / 100;
        }
        public void CalculateTotalPrice()
        {
            TotalPrice = SalePrice - DiscountAmount;
        }
    }
    
}