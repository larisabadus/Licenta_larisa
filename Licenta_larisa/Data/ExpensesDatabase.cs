using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Licenta_larisa.Models;



namespace Licenta_larisa.Data
{
    public class ExpensesDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ExpensesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Expenses>().Wait();
            _database.CreateTableAsync<Item>().Wait();
            _database.CreateTableAsync<ListItem>().Wait();
        }
        public Task<List<Expenses>> GetExpensesAsync()
        {
            return _database.Table<Expenses>().ToListAsync();
        }
        public Task<Expenses> GetExpensesAsync(int id)
        {
            return _database.Table<Expenses>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveExpensesAsync(Expenses exp)
        {
            if (exp.ID != 0)
            {
                return _database.UpdateAsync(exp);
            }
            else
            {
                return _database.InsertAsync(exp);
            }
        }
        public Task<int> DeleteExpensesAsync(Expenses exp)
        {
            return _database.DeleteAsync(exp);
        }


        public Task<int> SaveItemAsync(Item item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(Item item)
        {
            return _database.DeleteAsync(item);
        }
        public Task<List<Item>> GetItemsAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }
    


        public Task<int> SaveListItemAsync(ListItem listi)
        {
            if (listi.ID != 0)
            {
                return _database.UpdateAsync(listi);
            }
            else
            {
                return _database.InsertAsync(listi);
            }
        }
        public Task<List<Item>> GetListItemsAsync(int expensesid)
        {
            return _database.QueryAsync<Item>(
            "select I.ID, I.Description from Item I"
            + " inner join ListItem LI"
            + " on I.ID = LI.ItemID where LI.ExpensesID = ?",
            expensesid);
        }
    }
}

















