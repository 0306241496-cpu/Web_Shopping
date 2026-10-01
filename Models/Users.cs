using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("Users")]
[Index(nameof(Username), IsUnique = true)] // Ràng buộc không trùng lặp (Unique) cho Username
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Tên đăng nhập là bắt buộc nhập.")]
    [StringLength(50)]
    [Column(TypeName = "VARCHAR(50)")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Mật khẩu là bắt buộc nhập.")]
    [StringLength(255)]
    [Column(TypeName = "NVARCHAR(255)")]
    public string Password { get; set; }

    [StringLength(100)]
    [Column(TypeName = "NVARCHAR(100)")]
    public string? FullName { get; set; }

    [EmailAddress(ErrorMessage = "Địa chỉ Email không đúng định dạng.")]
    [StringLength(100)]
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Email { get; set; }

    [StringLength(20)]
    [Column(TypeName = "NVARCHAR(20)")]
    public string? Role { get; set; }
}