namespace Gasolina.Views;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        // Retour au tableau de bord
        await Shell.Current.GoToAsync("//DashboardPage");
    }
}