using System.ComponentModel.DataAnnotations;

namespace StudentsMVC.Models;

public class Student
{
    // Create atributes Student
    [Key] public int Id { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "The name is required")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "The last name is required")]
    public string? LastName { get; set; }

    [Display(Name = "Date of Birth")]
    [Required(ErrorMessage = "The date of birth is required")]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Gender")]
    [Required(ErrorMessage = "Gender is required")]
    public char Sex { get; set; }
}