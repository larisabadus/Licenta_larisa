using System;
using Licenta_larisa.Data;
using System.IO;


namespace Licenta_larisa;

public partial class App : Application
{
    static ExpensesDatabase database;
    public static ExpensesDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
ExpensesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
LocalApplicationData), "Expenses.db3"));
            }
            return database;
        }
    }

       public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
