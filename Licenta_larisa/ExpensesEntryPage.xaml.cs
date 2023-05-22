using Licenta_larisa.Models;

namespace Licenta_larisa;

public partial class ExpensesEntryPage : ContentPage
{
	public ExpensesEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetExpensesAsync();
    }
    async void OnExpensesAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExpensePage
        {
            BindingContext = new Expenses ()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ExpensePage
            {
                BindingContext = e.SelectedItem as Expenses
            });
        }
    }
}