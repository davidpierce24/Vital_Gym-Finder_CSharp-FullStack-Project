#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Models;

public class Gym
{
    [Key]
    public int GymId {get; set;}
    [Required]
    public string GymName {get; set;}
    [Required]
    public string Address1 {get; set;}
    public string? Address2 {get; set;}
    [Required]
    public string City {get; set;}
    [Required]
    public string State {get; set;}
    [Required]
    [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Must be a valid Zip Code")]
    public string Zip {get; set;}
    [Required]
    public int OwnerId {get; set;}
    public Owner? Owner {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public List<Hour> GymHours = new List<Hour>();
    public List<Equipment> GymEquipment = new List<Equipment>();
}