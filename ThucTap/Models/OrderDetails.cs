using System.ComponentModel.DataAnnotations;
using ThucTap.Commands;

namespace ThucTap.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public required CustomerDetails Customer { get; set; }
        public required List<ProductDetails> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        // Các thuộc tính khác như Trạng thái đơn hàng, Địa chỉ giao hàng, v.v. có thể được thêm vào
    }
}
