namespace Gasolina.Views;

public partial class MaintenancePage : ContentPage
{
    public MaintenancePage()
    {
        InitializeComponent();
    }

    private async void OnAddReminderClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Rappel", "La fonctionnalité d'ajout de rappel sera bientôt disponible.", "OK");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        // Retour direct au tableau de bord
        await Shell.Current.GoToAsync("//DashboardPage");
    }
}