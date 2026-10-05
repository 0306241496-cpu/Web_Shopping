using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Category")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Category name is required.")]
    [StringLength(100)]
    [Column(TypeName = "NVARCHAR(100)")]
    public string CategoryName { get; set; }=string.Empty;

    [Column(TypeName = "NVARCHAR(MAX)")]
    public string? Description { get; set; }
}