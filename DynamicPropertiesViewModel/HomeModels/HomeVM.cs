using DynamicPropertiesViewModel.Models;

namespace DynamicPropertiesViewModel.HomeModels;

public class HomeVM 
{
    public List<Students> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public IEnumerator<Students> GetEnumerator()
    {
        throw new NotImplementedException();
    }
}