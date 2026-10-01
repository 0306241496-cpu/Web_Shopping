using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Product")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm là bắt buộc nhập.")]
    [StringLength(200)]
    [Column(TypeName = "NVARCHAR(200)")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Giá bán là bắt buộc nhập.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
    [Column(TypeName = "DECIMAL(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "NVARCHAR(MAX)")]
    public string? Description { get; set; }

    [StringLength(255)]
    [Column(TypeName = "NVARCHAR(255)")]
    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }
}