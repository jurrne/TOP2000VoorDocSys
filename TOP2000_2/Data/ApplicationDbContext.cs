using Top2000_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TOP2000_2.Models;

namespace Top2000_2.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {

        public DbSet<Artiest> Artiest { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Top2000> Lijst { get; set; }
        public DbSet<VmLijst> VmLijst { get; set; }
        public DbSet<VmStijging> vmStijging { get; set; }
        public DbSet<VmFilterOpNaam> vmFilterOpNaam { get; set; }
        public DbSet<VmDaling> VmDaling { get; set; }
        public DbSet<VmDaling> VmZelfdePositie { get; set; }
        public DbSet<VmNieuwInLijst> vmNieuwInLijst { get; set; }
        public DbSet<vmVerwijderdVanLijst> vmVerwijderdVanLijst { get; set; }
        public DbSet<vmTerugGekeerdInDeLijst> vmTerugGekeerdInDeLijst { get; set; }
        public DbSet<vmEenKeerInTop2000> vmEenKeerInTop2000 { get; set; }
        public DbSet<VmFotoToevoegen> VmFotoToevoegen { get; set; }
        public DbSet<vm3ArtiestenMetMeesteNummer> vm3ArtiestenMetMeesteNummer { get; set; }
		public DbSet<vmAlleEdities> vmAlleEdities { get; set; }
		public DbSet<vmsp8> vmsp8 { get; set; }
		public ApplicationDbContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VmLijst>().ToView("spLijst").HasNoKey();
            modelBuilder.Entity<VmStijging>().ToView("spStijgingVanSongs").HasNoKey();
            modelBuilder.Entity<VmFilterOpNaam>().ToView("spFilterOpNaam").HasNoKey();
            modelBuilder.Entity<VmDaling>().ToView("spDalingTOVvorigjaar").HasNoKey();
            modelBuilder.Entity<VmNieuwInLijst>().ToView("spNieuwInLijst").HasNoKey();
            modelBuilder.Entity<vmVerwijderdVanLijst>().ToView("spVerwijderdVanLijst").HasNoKey();
            modelBuilder.Entity<vmTerugGekeerdInDeLijst>().ToView("spTerugGekeerdInDeLijst").HasNoKey();
            modelBuilder.Entity<vmEenKeerInTop2000>().ToView("spEenKeerInTop2000").HasNoKey();
            modelBuilder.Entity<vm3ArtiestenMetMeesteNummer>().ToView("sp3ArtiestenMetMeesteNummer").HasNoKey();
            modelBuilder.Entity<VmFotoToevoegen>().ToView("spFotoToevoegen").HasNoKey();
            modelBuilder.Entity<vmAlleEdities>().ToView("spAlleEdities").HasNoKey();
            modelBuilder.Entity<vmsp8>().ToView("sp8").HasNoKey();

        }
    }
}
