#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Models;

public class Gym
{
    [Key]
    public int GymId {get; set;}
    public string GymName {get; set;}
    public string Address1 {get; set;}
    public string Address2 {get; set;}
    public string City {get; set;}
    public string State {get; set;}
    public int Zip {get; set;}
    public int OwnerId {get; set;}
    public Owner? Owner {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public List<Hour> GymHours = new List<Hour>();
    public List<Equipment> GymEquipment = new List<Equipment>();
}