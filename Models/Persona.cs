using SQLite;

namespace dsegoviaS5A.Models
{
    [Table("Persona")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(25), Unique]
        public string Name { get; set; }
    }
}
