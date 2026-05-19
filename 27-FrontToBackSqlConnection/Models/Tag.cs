using FrontToBackSqlConnection.Models.Base;

namespace FrontToBackSqlConnection.Models;

public class Tag:BaseEntity
{
    public string Name { get; set; }
    public List<ProductTag> ProductTags { get; set; }
}