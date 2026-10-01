using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("Users")]
[Index(nameof(Username), IsUnique = true)] // Unique constraint for Username
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [StringLength(50)]
    [Column(TypeName = "VARCHAR(50)")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(255)]
    [Column(TypeName = "NVARCHAR(255)")]
    public string Password { get; set; }

    [StringLength(100)]
    [Column(TypeName = "NVARCHAR(100)")]
    public string? FullName { get; set; }

    [EmailAddress(ErrorMessage = "Email address is invalid.")]
    [StringLength(100)]
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Email { get; set; }

    [StringLength(20)]
    [Column(TypeName = "NVARCHAR(20)")]
    public string? Role { get; set; }
}