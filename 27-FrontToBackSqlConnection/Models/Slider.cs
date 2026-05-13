using System.ComponentModel.DataAnnotations.Schema;
using FrontToBackSqlConnection.Models.Base;
using Microsoft.Build.Framework;

namespace FrontToBackSqlConnection.Models;

public class Slider:BaseEntity
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Desc { get; set; }
    public string Image { get; set; }
    public int Order { get; set; }
    [Required]
    [NotMapped]
    public IFormFile Photo { get; set; }
}