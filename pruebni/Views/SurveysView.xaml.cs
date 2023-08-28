using pruebni.Data;
using pruebni.Models;
using System.Collections.ObjectModel;

namespace pruebni.Views;

public partial class SurveysView : ContentPage
{
    TodoItemDatabase database;
    public ObservableCollection<TodoItem> Items { get; set; } = new();

    public SurveysView(TodoItemDatabase todoItemDatabase)
    {
        InitializeComponent();
        database = todoItemDatabase;
        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);

        });
    }

    async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not TodoItem item)
            return;

        await Shell.Current.GoToAsync(nameof(SurveyDetailsView), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }

    private async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SurveyDetailsView), true, new Dictionary<string, object>
        {
            ["Item"] = new TodoItem()
        });
    }
}