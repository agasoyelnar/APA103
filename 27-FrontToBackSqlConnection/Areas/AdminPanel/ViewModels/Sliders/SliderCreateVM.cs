using System.ComponentModel.DataAnnotations.Schema;

namespace FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Sliders;

public class SliderCreateVM
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Desc { get; set; }
    public int Order { get; set; }
    [NotMapped]
    public IFormFile Photo { get; set; }
}