using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Licenta_larisa.Models
{

    public class ListItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Expenses))]
        public int ExpensesID { get; set; }
        public int ItemID { get; set; }

        public int PriceID { get; set; }    
    }
}
