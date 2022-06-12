using System.ComponentModel.DataAnnotations;

namespace Shop.Common.Dtos;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Prosze podać adres email")]
    [EmailAddress(ErrorMessage = "Nieprawidłowy adres email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Proszę podać hasło")]
    public string Password { get; set; }
}