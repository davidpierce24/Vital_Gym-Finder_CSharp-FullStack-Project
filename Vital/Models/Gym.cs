#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Models;

public class Gym
{
    [Key]
    public int GymId {get; set;}
    public string GymName {get; set;}
}