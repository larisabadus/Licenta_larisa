using Licenta_larisa.Models;

namespace Licenta_larisa;

public partial class ItemPage : ContentPage
{
    Expenses ex;

    public ItemPage(Expenses exp)
    {
        InitializeComponent();
        ex = exp;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var item = (Item)BindingContext;
        await App.Database.SaveItemAsync(item);
        listView.ItemsSource = await App.Database.GetItemsAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var item = (Item)BindingContext;
        await App.Database.DeleteItemAsync(item);
        listView.ItemsSource = await App.Database.GetItemsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetItemsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Item i;
        if (listView.SelectedItem != null)
        {
            i = listView.SelectedItem as Item;
            var ep = new ListItem()
            {
                ExpensesID = ex.ID,
                ItemID = i.ID
            };
            await App.Database.SaveListItemAsync(ep);
           
            i.ListItems = new List<ListItem> { ep };
            await Navigation.PopAsync();
        }

    }
}









