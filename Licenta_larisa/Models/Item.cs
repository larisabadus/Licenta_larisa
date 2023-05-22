using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Licenta_larisa.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<ListItem> ListItems { get; set; }
    }
}
