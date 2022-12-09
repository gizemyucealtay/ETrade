using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    public class Products:BaseDescription
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public int VatId { get; set; }
        [ForeignKey("VatId")]
        public Vat Vat { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }  //bir ürünün birden çok category si olur
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; } //bir ürünün bir tane birimi olur
        public ICollection<BasketDetail> BasketDetail { get; set; }
    }
}
