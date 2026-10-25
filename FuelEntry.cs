namespace Gasolina.Models
{
    public class FuelEntry
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public double Kilometrage { get; set; }
        public double Litres { get; set; }
        public double Montant { get; set; }
    }
}