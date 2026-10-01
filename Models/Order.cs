using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Order")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    [Required(ErrorMessage = "Customer name is required.")]
    [StringLength(100)]
    [Column(TypeName = "NVARCHAR(100)")]
    public string CustomerName { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Phone number is invalid.")]
    [StringLength(15)]
    [Column(TypeName = "VARCHAR(15)")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Shipping address is required.")]
    [StringLength(255)]
    [Column(TypeName = "NVARCHAR(255)")]
    public string Address { get; set; }

    [StringLength(500)]
    [Column(TypeName = "NVARCHAR(500)")]
    public string? Note { get; set; }

    [StringLength(50)]
    [Column(TypeName = "NVARCHAR(50)")]
    public string Status { get; set; } = "Pending";

    [Column(TypeName = "DATETIME")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}