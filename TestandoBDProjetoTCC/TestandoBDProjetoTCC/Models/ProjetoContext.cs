using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestandoBDProjetoTCC.Models
{
    public class ProjetoContext: DbContext
    {
        public DbSet<CrimeCadastrado> CrimeCadastrado { get; set; }
        public DbSet<CrimeSSP> CrimeSSP { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoCrime> TipoCrime { get; set; }
        public DbSet<Vitima> VItima { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VitimaCrimeCadastrado>().HasKey(vcc => new { vcc.CrimeCadastradoId, vcc.VitimaId });
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jvieira\\Documents\\Visual Studio 2015\\Projects\\appCabeleireiro\\TestandoBDProjetoTCC\\TestandoBDProjetoTCC\\App_Data\\ProjetoBD.mdf;Integrated Security=True");
        }


    }
}