using System.Drawing;

namespace WineStore.Models
{
    public class Wine
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public int Year { get; set; }

        public int AlcoholPercentage { get; set; }

        public Color Color { get; set; }

        public Winery Winery { get; set; }
        public decimal Price { get; set; }
    }
}
