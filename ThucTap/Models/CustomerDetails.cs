namespace ThucTap.Models
{
    public class CustomerDetails
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public int Age { get; set; }
        // Các thuộc tính khác như Số điện thoại, Địa chỉ thanh toán, v.v. có thể được thêm vào
    }
}
