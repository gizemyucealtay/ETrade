using ETrade.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    public class BasketDetail : IBaseTable
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; } //order daki ıd gidicek master daki ıd ile eslesicek
       
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Ratio { get; set; }
        public int UnitId { get; set; }
        [ForeignKey("OrderId")]
        public BasketMaster BasketMaster { get; set; } //bir detail kaydına ait bir tane master olur 
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
    }
}
