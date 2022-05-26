using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WorkScheduler.Data;

public class WorkDTO
{
    [HiddenInput]
    [DisplayFormat(NullDisplayText = "Some Error Occured")]
    public DateTime Created {get;set;}
    
    [HiddenInput]
    [DisplayFormat(NullDisplayText = "Yet to be updated")]
    public DateTime Updated { get; set; }
    
    [Required(ErrorMessage = "Enter the issued date.")]
    [DataType(DataType.Date)]
    public DateTime DeadLine { get; set; }
    
    [Required(ErrorMessage = "Enter the description.")]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Enter the name.")]
    public string Name { get; set; } = "";
    
    [HiddenInput]
    public int Id { get; set; }
    
    [DisplayFormat(NullDisplayText = "Noone yet")]
    public string? Assignee { get; set; }
}