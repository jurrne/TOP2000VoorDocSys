using Microsoft.EntityFrameworkCore;
using Top2000_2.Data;
using System.Collections.Generic;

namespace Top2000_2.Models
{
    public class VmLijstData
    {
        private readonly ApplicationDbContext _dbContext;

        public VmLijstData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static List<VmLijst> GetLijstData(int jaar, ApplicationDbContext dbContext)
        {
            return dbContext.VmLijst.FromSqlInterpolated($"spLijst {jaar}").ToList();
        }
    }
}
