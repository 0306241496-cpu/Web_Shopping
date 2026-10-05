using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Product")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(200)]
    [Column(TypeName = "NVARCHAR(200)")]
    public string ProductName { get; set; }=string.Empty;

    [Required(ErrorMessage = "Selling price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    [Column(TypeName = "DECIMAL(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "NVARCHAR(MAX)")]
    public string? Description { get; set; }

    [StringLength(255)]
    [Column("Image", TypeName = "NVARCHAR(255)")]
    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }
}