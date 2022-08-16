#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Models;

public class Hour
{
    [Key]
    public int HourId {get; set;}
    [DataType(DataType.Time)]
    public DateTime? SundayOpen {get; set;}
    [DataType(DataType.Time)]
    public DateTime? SundayClose {get; set;}
    [DataType(DataType.Time)]
    public DateTime? MondayOpen {get; set;}
    [DataType(DataType.Time)]
    public DateTime? MondayClose {get; set;}
    [DataType(DataType.Time)]
    public DateTime? TuesdayOpen {get; set;}
    [DataType(DataType.Time)]
    public DateTime? TuesdayClose {get; set;}
    [DataType(DataType.Time)]
    public DateTime? WednesdayOpen {get; set;}
    [DataType(DataType.Time)]
    public DateTime? WednesdayClose {get; set;}
    [DataType(DataType.Time)]
    public DateTime? ThursdayOpen {get; set;}
    [DataType(DataType.Time)]
    public DateTime? ThursdayClose {get; set;}
    [DataType(DataType.Time)]
    public DateTime? FridayOpen {get; set;}
    [DataType(DataType.Time)]
    public DateTime? FridayClose {get; set;}
    [DataType(DataType.Time)]
    public DateTime? SaturdayOpen {get; set;}
    [DataType(DataType.Time)]
    public DateTime? SaturdayClose {get; set;}
    [Required]
    public int GymId {get; set;}
    public Gym? Gym {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}