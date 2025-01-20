
using SQLite;

namespace Maui_WorkingDemo
{
    [Table("Contacts")]
    public class Contacts
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("contact_name")]
        public string ContactName { get; set; }

        [Column("mobile")]
        public string Mobile { get; set; }

        [Column("email")]
        public string Email { get; set; }
         
    }
}
