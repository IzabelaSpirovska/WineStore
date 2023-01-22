using System.ComponentModel.DataAnnotations;

namespace WineStore.Models
{
    public class Vintage
    {
        public int Id { get; set; }
        public String Name { get; set; }
        [DataType(DataType.Time)]
        public  DateTime ProductionDate { get; set; }
        public Winery Winery { get; set; }

    }
}
