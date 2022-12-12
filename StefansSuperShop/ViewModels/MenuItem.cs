namespace StefansSuperShop.ViewModels
{
    public class MenuItem
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Text { get; set; }

        public bool IsActive { get; set; }
    }
}