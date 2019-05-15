using SQLite;

namespace Lab3.Entities
{
    [Table("StudentInfo")]
    public class StudentInfoEntity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Faculty { get; set; }
        public string Course { get; set; }
    }
}
