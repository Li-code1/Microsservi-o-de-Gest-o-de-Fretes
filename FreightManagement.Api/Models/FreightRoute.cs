// FreightManagement.Api/Models/FreightRoute.cs
namespace FreightManagement.Api.Models
{
    public class FreightRoute
    {
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public double DistanceInKm { get; set; }
        public decimal PricePerKm { get; private set; } = 2.50m; // Regra de negócio fixa para o exemplo

        public decimal CalculateTotalFreight()
        {
            if (DistanceInKm <= 0)
                throw new ArgumentException("A distância deve ser maior que zero.");

            decimal basePrice = (decimal)DistanceInKm * PricePerKm;

            // Regra de negócio: Adicional para entregas de longa distância (ex: > 500km)
            if (DistanceInKm > 500)
            {
                basePrice += 100.00m; // Taxa adicional de longa distância
            }

            return basePrice;
        }
    }
}