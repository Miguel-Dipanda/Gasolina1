namespace Gasolina.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Simulation d'inscription -> Redirection vers le Login
        await Shell.Current.GoToAsync("//LoginPage");
    }

    private async void OnLoginTapped(object sender, EventArgs e)
    {
        // Retour à la page de connexion
        await Shell.Current.GoToAsync("//LoginPage");
    }
}