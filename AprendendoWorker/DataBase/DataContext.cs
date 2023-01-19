using AprendendoWorker.Models.PersonsResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoWorker.DataBase
{
    public class DataContext : DbContext
    {
        public virtual DbSet<GetResults> RICKMORTY { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-278IVMV;database=RICKMORTY;trusted_connection=true;Integrated Security=SSPI;TrustServerCertificate=True;");


        }
    }
}
