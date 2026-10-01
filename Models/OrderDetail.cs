using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("OrderDetail")]
public class OrderDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    [Required(ErrorMessage = "Số lượng là bắt buộc nhập.")]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng sản phẩm mua phải lớn hơn 0.")]
    public int Quantity { get; set; }

    [Column(TypeName = "DECIMAL(18,2)")]
    public decimal UnitPrice { get; set; }

    // Thuộc tính điều hướng (Navigation Properties)
    [ForeignKey("OrderId")]
    public virtual Order? Order { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
}