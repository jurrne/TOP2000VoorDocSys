using Microsoft.EntityFrameworkCore;
using Top2000_2.Data;

namespace Top2000_2.Models
{
    public class VmLijst
    {
        public string titel { get; set; } = string.Empty;
        public string naam { get; set; } = string.Empty;
        public int? positie { get; set; } = null;
        public int? jaar { get; set; } = null;
        public int? Vorigjaar { get; set; } = null;
        public string? songFoto { get; set; } = null;
    }
}
