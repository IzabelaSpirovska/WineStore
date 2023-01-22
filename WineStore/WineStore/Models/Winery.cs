namespace WineStore.Models
{
    public class Winery
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Region Region { get; set; }
        public Country Country { get; set; }
    }
}
