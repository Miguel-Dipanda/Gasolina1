namespace Gasolina.Views;

public partial class CostPerKmPage : ContentPage
{
    // Valeurs par défaut pour le calcul frontend (à connecter plus tard au backend)
    private const double CostPerKm = 92.0;       // 92 FCFA / km
    private const double ConsumptionRate = 7.2;   // 7,2 L / 100 km

    public CostPerKmPage()
    {
        InitializeComponent();
    }

    private void OnCalculateClicked(object sender, EventArgs e)
    {
        string inputText = DistanceEntry.Text?.Trim();

        if (double.TryParse(inputText, out double distance) && distance > 0)
        {
            // Calcul du carburant estimé en Litres : (Distance * 7.2) / 100
            double estimatedFuel = (distance * ConsumptionRate) / 100.0;

            // Calcul du coût estimé en FCFA : Distance * 92
            double estimatedCost = distance * CostPerKm;

            // Mise à jour des libellés à l'écran
            FuelEstimateLabel.Text = $"{estimatedFuel:F1} L";
            CostEstimateLabel.Text = $"{estimatedCost:N0} FCFA";
        }
        else
        {
            DisplayAlert("Saisie invalide", "Veuillez entrer une distance valide en kilomètres.", "OK");
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        // Retour au tableau de bord
        await Shell.Current.GoToAsync("//DashboardPage");
    }
}