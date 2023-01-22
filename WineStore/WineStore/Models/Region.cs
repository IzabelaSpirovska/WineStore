namespace WineStore.Models
{
    public class Region
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Country Country { get; set; }
    }
}
