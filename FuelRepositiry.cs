using Gasolina.Models;

namespace Gasolina
{
    public static class FuelRepository
    {
        // C'est notre "liste en mémoire" qui servira d'historique temporaire
        public static List<FuelEntry> Pleins { get; set; } = new List<FuelEntry>();

        // Méthode pour ajouter un plein facilement
        public static void AjouterPlein(double km, double litres, double montant)
        {
            var nouveauPlein = new FuelEntry
            {
                Kilometrage = km,
                Litres = litres,
                Montant = montant,
                Date = DateTime.Now
            };

            Pleins.Add(nouveauPlein);
        }
    }
}