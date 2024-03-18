namespace GkPosApp
{
    public class OrderViewModel
    {
        public DateOnly Date { get; set; }

        public int Total { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

    }
}