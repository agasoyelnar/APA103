namespace FrontToBackSqlConnection.Models.Base;

public class BaseEntity
{
        public int Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
}