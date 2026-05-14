using System.ComponentModel.DataAnnotations.Schema;

namespace FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Sliders;

public class SliderUpdateVM
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Desc { get; set; }
    public string Image { get; set; }
    public int Order { get; set; }
    public IFormFile? Photo { get; set; }
}