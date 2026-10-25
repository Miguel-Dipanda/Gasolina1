namespace Gasolina.Views;

public partial class AverageConsumptionPage : ContentPage
{
    public AverageConsumptionPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        // Retour au tableau de bord
        await Shell.Current.GoToAsync("//DashboardPage");
    }
}