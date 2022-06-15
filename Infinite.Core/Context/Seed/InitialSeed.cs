using Infinite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Context.Seed
{
    public static class InitialSeed
    {
        public static IEnumerable<CategoriaEntity> Categoria =>
            new List<CategoriaEntity>
            {
                new CategoriaEntity{ Categoria = "RPG" },
                new CategoriaEntity{ Categoria = "FPS" },
                new CategoriaEntity{ Categoria = "Soulslike" },
                new CategoriaEntity{ Categoria = "Consoles" },
                new CategoriaEntity{ Categoria = "Computadores" },
            };

        public static IEnumerable<>

    }
}
