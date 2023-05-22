using System.ComponentModel.DataAnnotations;

namespace Top2000_2.Models
{
    public class Artiest
    {
        [Key]
        public int Artiestid { get; set; }
        public string naam { get; set; } = string.Empty;
    }
}
