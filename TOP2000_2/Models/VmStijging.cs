namespace Top2000_2.Models
{
    public class VmStijging
    {
        public string titel { get; set; } = string.Empty;
        public string naam { get; set; } = string.Empty;
        public int? uitgiftejaar { get; set; } = null;
        public int? positie { get; set; } = null;
        public int? Vorigjaar { get; set; } = null;
        public string verschil { get; set; } = string.Empty;
    }
}
