using Gasolina.Models;

namespace Gasolina.Views;

public partial class AddFuelPage : ContentPage
{
    public AddFuelPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // 1. Vérification et conversion des valeurs saisies
        if (double.TryParse(txtKm?.Text, out double km) &&
            double.TryParse(txtLitres?.Text, out double litres) &&
            double.TryParse(txtMontant?.Text, out double montant))
        {
            // 2. Enregistrement dans le repository
            FuelRepository.AjouterPlein(km, litres, montant);

            // 3. Message de succès
            await DisplayAlert("Succès", "Plein enregistré avec succès !", "OK");

            // 4. Retour au tableau de bord
            await Shell.Current.GoToAsync("//DashboardPage");
        }
        else
        {
            // Message d'erreur si un champ est mal rempli ou vide
            await DisplayAlert("Erreur", "Veuillez remplir correctement tous les champs numériques.", "OK");
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        // Annuler et retourner au tableau de bord sans enregistrer
        await Shell.Current.GoToAsync("//DashboardPage");
    }
}