using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Top2000_2.Models
{
    [PrimaryKey(nameof(jaar), nameof(songid))]
    public class Top2000
    {
        public int jaar { get; set; }

        public int positie { get; set; }

        [ForeignKey("songid")]
        public int songid { get; set; }

        public Song ?song { get; set; } 
    }
}
