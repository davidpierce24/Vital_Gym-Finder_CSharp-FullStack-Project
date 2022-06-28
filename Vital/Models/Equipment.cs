#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Models;

public class Equipment
{
    [Key]
    public int EquipmentId {get; set;}
    public string EquipmentName {get; set;}
    public string EquipmentAmount {get; set;}
    public int GymId {get; set;}
    public Gym? Gym {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}