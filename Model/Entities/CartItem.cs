namespace PawsitivePlace.Model.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public string ImageSource { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
        public string arrival { get; set; }
    }
}
