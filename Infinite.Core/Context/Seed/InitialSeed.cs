﻿using Infinite.Core.Domain.Entities;
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

        public static IEnumerable<CupomEntity> Cupom =>
            new List<CupomEntity>
            {
                new CupomEntity{ Tipo = "marketing" , Quantidade = 200 },
                new CupomEntity{ Tipo = "promocional" , Quantidade = 200 },
                new CupomEntity{ Tipo = "colaborador" , Quantidade = 200 }
            };

        public static IEnumerable<ProdutoEntity> Produto =>
            new List<ProdutoEntity>
            {
                new ProdutoEntity
                {
                    Nome = "GTAV",
                    CategoriaId = 2,
                    Estoque = 200,
                    Pontos = 300,
                    Preco = 25,
                },

                new ProdutoEntity
                {
                    Nome = "Dark Souls III",
                    CategoriaId = 3,
                    Estoque = 200,
                    Pontos = 500,
                    Preco = 150,
                },

                new ProdutoEntity
                {
                    Nome = "Sekiro",
                    CategoriaId = 3,
                    Estoque = 200,
                    Pontos = 300,
                    Preco = 199,
                },

                new ProdutoEntity
                {
                    Nome = "Elden Ring",
                    CategoriaId = 3,
                    Estoque = 200,
                    Pontos = 300,
                    Preco = 250,
                },

                new ProdutoEntity
                {
                    Nome = "The Elder Scrolls V: Skyrim",
                    CategoriaId = 2,
                    Estoque = 200,
                    Pontos = 100,
                    Preco = 40,
                },

            };

        public static IEnumerable<FormaPagEntity> FormaPag =>
            new List<FormaPagEntity>
            {
                new FormaPagEntity
                {
                    Frm = "PIX"
                },

                new FormaPagEntity
                {
                    Frm = "Cartão de crédito"
                },

                new FormaPagEntity
                {
                    Frm = "Boleto"
                },
            };

        public static IEnumerable<TipoUsuarioEntity> TipoUsuario =>
            new List<TipoUsuarioEntity>
            {
                new TipoUsuarioEntity{ Role = "Master" },
                new TipoUsuarioEntity{ Role = "UsuarioSite" }
            };

        public static IEnumerable<FuncionarioEntity> Funcionario =>
            new List<FuncionarioEntity>
            {
                new FuncionarioEntity
                {
                    Nome = "Alyson Solador de maguinho",
                    Email = "alyson@gmail.com",
                    Senha = "alyson@2022",
                    Telefone = "(11)93363-8836",
                    Usuario = new UsuarioEntity
                    {
                        Email = "alyson",
                        Password = "alyson@2022",
                        TipoUsuarioId = 1,
                    },
                    CupomId = 3,
                }
            };

        public static IEnumerable<ClienteEntity> Cliente =>
            new List<ClienteEntity>
            {
                new ClienteEntity
                {
                    Nome = "Samuel Gamer FF 10",
                    Tell = "(11)93363-8836",
                    Pontos = 0,
                    Usuario = new UsuarioEntity
                    {
                        Email = "samuel",
                        Password = "samuel@2022",
                        TipoUsuarioId = 1,
                    }
                }
            };
    }
}
