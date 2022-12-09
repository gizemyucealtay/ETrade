using ETrade.Dto;

namespace ETrade.Ui.Models
{
    public class BasketDetailModel
    {
        public List<ProductDTO> ProductDTO { get; set; }
        public List<BasketDetailDTO> BasketDetailDTOs { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Ratio { get; set; }
        public int UnitId { get; set; }
    }
}
