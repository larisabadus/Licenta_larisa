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
            var exp = (Expenses)BindingContext;

            listView.ItemsSource = await App.Database.GetListItemsAsync(exp.ID);
        }


    }
}


