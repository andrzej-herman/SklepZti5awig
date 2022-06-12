using System.ComponentModel.DataAnnotations;

namespace Shop.Common.Dtos;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "Prosze podać adres email")]
    [EmailAddress(ErrorMessage = "Nieprawidłowy adres email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Proszę podać imię")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Proszę podać nazwisko")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Proszę podać hasło")]
    [MinLength(8, ErrorMessage = "Minimalna długość hasła to 8 znaków")]
    public string Password { get; set; }
}