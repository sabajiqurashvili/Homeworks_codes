using System.ComponentModel.DataAnnotations;
using Homework15.Models.Attributes;

namespace Homework15.Models;

public class Person
{
    [Required(ErrorMessage = "name is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "lastname is required")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "doctor is required")]
    public string Doctor { get; set; }
    
    [Required(ErrorMessage = "time is required")]
    [TimeRange("10:00","19:00",ErrorMessage = "visit time must be between 10:00 and 19:00")]
    public DateTime Time { get; set; }
}