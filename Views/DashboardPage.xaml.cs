using Gasolina.Models;

namespace Gasolina.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Vérifie si on a enregistré des pleins
        if (FuelRepository.Pleins != null && FuelRepository.Pleins.Count > 0)
        {
            // 1. Récupérer le dernier plein saisi
            var dernierPlein = FuelRepository.Pleins.Last();

            // Afficher le kilométrage actuel
            if (lblKilometrage != null)
                lblKilometrage.Text = $"{dernierPlein.Kilometrage} km";

            // Afficher les litres du dernier plein dans la grande carte du haut
            if (lblDernierPleinLitres != null)
                lblDernierPleinLitres.Text = $"Dernier plein : {dernierPlein.Litres} L";

            // 2. S'il y a au moins 2 pleins, on calcule le coût par km et la consommation
            if (FuelRepository.Pleins.Count >= 2)
            {
                var avantDernierPlein = FuelRepository.Pleins[FuelRepository.Pleins.Count - 2];
                double distanceParcourue = dernierPlein.Kilometrage - avantDernierPlein.Kilometrage;

                if (distanceParcourue > 0)
                {
                    // Calcul du coût par kilomètre (Montant / Distance)
                    double coutParKm = dernierPlein.Montant / distanceParcourue;
                    if (lblCoutKm != null)
                        lblCoutKm.Text = $"{coutParKm:F0} FCFA";

                    // Calcul de la consommation moyenne (Litres / Distance * 100)
                    double consoMoyenne = (dernierPlein.Litres / distanceParcourue) * 100;
                    if (lblConsommation != null)
                        lblConsommation.Text = $"{consoMoyenne:F1} L/100 km";
                }
            }
            else
            {
                // S'il n'y a qu'un seul plein
                if (lblCoutKm != null) lblCoutKm.Text = "- FCFA";
                if (lblConsommation != null) lblConsommation.Text = "Ajoutez un 2e plein";
            }
        }
    }

    // 1. Redirection vers Nouveau plein
    private async void OnAddFuelTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AddFuelPage");
    }

    // 2. Redirection vers l'historique
    private async void OnHistoryTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//HistoryPage");
    }

    // 3. Redirection vers la page d'entretien
    private async void OnMaintenanceTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MaintenancePage");
    }

    // 4. Redirection vers le Coût Kilométrique
    private async void OnCostPerKmTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CostPerKmPage");
    }

    // 5. Redirection vers la Consommation Moyenne
    private async void OnAverageConsumptionTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AverageConsumptionPage");
    }

    // Bouton de déconnexion
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }
}