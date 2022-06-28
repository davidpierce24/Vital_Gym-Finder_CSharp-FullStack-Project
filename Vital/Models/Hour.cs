#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Models;

public class Hour
{
    [Key]
    public int HourId {get; set;}
    public DateTime SundayOpen {get; set;}
    public DateTime SundayClose {get; set;}
    public DateTime MondayOpen {get; set;}
    public DateTime MondayClose {get; set;}
    public DateTime TuesdayOpen {get; set;}
    public DateTime TuesdayClose {get; set;}
    public DateTime WednesdayOpen {get; set;}
    public DateTime WednesdayClose {get; set;}
    public DateTime ThursdayOpen {get; set;}
    public DateTime ThursdayClose {get; set;}
    public DateTime FridayOpen {get; set;}
    public DateTime FridayClose {get; set;}
    public DateTime SaturdayOpen {get; set;}
    public DateTime SaturdayClose {get; set;}
    [Required]
    public int GymId {get; set;}
    public Gym? Gym {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}