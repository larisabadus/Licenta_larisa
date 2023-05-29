using Licenta_larisa.Models;
namespace Licenta_larisa;

public partial class ExpensePage : ContentPage
{
    public ExpensePage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var exp = (Expenses)BindingContext;
        exp.Date = DateTime.UtcNow;
        await App.Database.SaveExpensesAsync(exp);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var exp = (Expenses)BindingContext;
        await App.Database.DeleteExpensesAsync(exp);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ItemPage((Expenses)
       this.BindingContext)
        {
            BindingContext = new Item()
        });

    }

    
    protected override async void OnAppearing()
    {
        {
            base.OnAppearing();
            var expe = (Expenses)BindingContext;

            listView.ItemsSource = await App.Database.GetListItemsAsync(expe.ID);
        }


    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        var it = (Item)BindingContext;
        await App.Database.SaveItemAsync(it);
        listView.ItemsSource = await App.Database.GetItemsAsync();
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var it = (Item)BindingContext;
        await App.Database.DeleteItemAsync(it);
        listView.ItemsSource = await App.Database.GetItemsAsync();
    }
}


