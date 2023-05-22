using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Top2000_2.Models
{
    public class Song
    {
        [Key]
        public int songid { get; set; }

        [StringLength(75)]
        public string titel { get; set; } = string.Empty;

        public int jaar { get; set; }
        [ForeignKey("ArtiestID")]
        public int artiestid { get; set; }

        public Artiest ?artiest { get; set; }
    }
}
