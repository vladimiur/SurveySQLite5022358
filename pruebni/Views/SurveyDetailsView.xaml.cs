using pruebni.Data;
using pruebni.Models;

namespace pruebni.Views;

[QueryProperty("Item", "Item")]
public partial class SurveyDetailsView : ContentPage
{
    public readonly string[] FavotitoEquipo =
       {
            "Alianza Lima",
            "América",
            "Boca Juniors",
            "Caracas FC",
            "Peñarol",
            "Coco-Coco",
            "Real Madrid"
        };

    TodoItem item;
    public TodoItem Item
    {
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }


    TodoItemDatabase database;
    public SurveyDetailsView(TodoItemDatabase todoItemDatabase)
    {
        InitializeComponent();
        database = todoItemDatabase;
    }

    private async void FavoriteTeamButton_Clicked(object sender, EventArgs e)
    {
        var favoriteTeam = await DisplayActionSheet(Literals.FavoriteTeamTitle, null, null, FavotitoEquipo);
        if (!string.IsNullOrWhiteSpace(favoriteTeam))
        {
            FavoriteTeamLabel.Text = favoriteTeam;
        }
    }

    private async void OkButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }
        item.FavoriteTeam = FavoriteTeamLabel.Text;
        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");

    }

    private async void OnButton_Clicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCalcelButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}