namespace Top2000_2.Models
{
    public class VmDaling
    {
        public string titel { get; set; } = string.Empty;
        public string naam { get; set; } = string.Empty;
        public int? jaar { get; set; } = null;
        public int? positie { get; set; } = null;
        public int? Vorigjaar { get; set; } = null;
        public string Gedaald { get; set; } = string.Empty;
    }
}
