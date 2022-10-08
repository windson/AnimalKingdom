using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnimalKingdom.Models;

namespace AnimalKingdom.Data
{
    public class AnimalKingdomContext : DbContext
    {
        public AnimalKingdomContext (DbContextOptions<AnimalKingdomContext> options)
            : base(options)
        {
        }

        public DbSet<AnimalKingdom.Models.Animal> Animal { get; set; } = default!;
    }
}
