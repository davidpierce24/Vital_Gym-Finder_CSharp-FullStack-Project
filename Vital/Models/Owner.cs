#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Models;

public class Owner
{
    [Key]
    public int OwnerId {get; set;}
    [Required]
    [MinLength(2)]
    public string FirstName {get; set;}
    [Required]
    [MinLength(2)]
    public string LastName {get; set;}
    [Required]
    public string Username {get; set;}
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address.")]
    public string Email {get; set;}
    [Required]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password must contain at least 1 number, 1 letter, and a special character")]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password {get; set;}
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public List<Gym> GymsOwned {get; set;} = new List<Gym>();
}