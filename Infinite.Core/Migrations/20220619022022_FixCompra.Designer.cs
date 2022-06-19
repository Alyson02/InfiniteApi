﻿// <auto-generated />
using System;
using Infinite.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infinite.Core.Migrations
{
    [DbContext(typeof(InfiniteContext))]
    [Migration("20220619022022_FixCompra")]
    partial class FixCompra
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infinite.Core.Domain.Entities.AgendamentoEntity", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("JogoId")
                        .HasColumnType("int");

                    b.Property<int>("MaquinaId")
                        .HasColumnType("int");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("JogoId");

                    b.HasIndex("MaquinaId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ArquivoEntity", b =>
                {
                    b.Property<int>("ArquivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Base64")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Tamanho")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("ArquivoId");

                    b.ToTable("Arquivo");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CarrinhoEntity", b =>
                {
                    b.Property<int>("CarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CarrinhoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CartaoClienteEntity", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("CartaoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "CartaoId");

                    b.HasIndex("CartaoId");

                    b.ToTable("CartaoCliente");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CartaoEntity", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApelidoCard")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Badeira")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CodigoSeg")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("NumCard")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.HasKey("CardId");

                    b.ToTable("Cartao");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CategoriaEntity", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ClienteEntity", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.Property<string>("Tell")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CompraEntity", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartaoId")
                        .HasColumnType("int");

                    b.Property<string>("CupomId")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Desconto")
                        .HasColumnType("double");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<double>("Pontos")
                        .HasColumnType("double");

                    b.Property<double>("Total")
                        .HasColumnType("double");

                    b.HasKey("CompraId");

                    b.HasIndex("CartaoId");

                    b.HasIndex("CupomId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CupomEntity", b =>
                {
                    b.Property<string>("CupomId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TipoCupomId")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<int>("VendasRealizadas")
                        .HasColumnType("int");

                    b.HasKey("CupomId");

                    b.HasIndex("TipoCupomId");

                    b.ToTable("Cupom");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.EnderecoClienteEntity", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "EnderecoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("EnderecoCliente");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.EnderecoEntity", b =>
                {
                    b.Property<int>("EndId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CEP")
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("NomeRua")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NumCasa")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("EndId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.FormaPagEntity", b =>
                {
                    b.Property<int>("FrmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Frm")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("FrmId");

                    b.ToTable("FormaPag");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.FotoProdutoEntity", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("ArquivoId")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId", "ArquivoId");

                    b.HasIndex("ArquivoId");

                    b.ToTable("FotoProduto");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.FuncionarioEntity", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CupomId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("CupomId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ItemCarrinhoEntity", b =>
                {
                    b.Property<int>("CarrinhoID")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnidade")
                        .HasColumnType("double");

                    b.HasKey("CarrinhoID", "ProdutoID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("ItemCarrinho");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.JogoEntity", b =>
                {
                    b.Property<int>("JogoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descrição")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("PontoPreco")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("JogoId");

                    b.ToTable("Jogo");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.MaquinaEntity", b =>
                {
                    b.Property<int>("MaquinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Termino")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MaquinaId");

                    b.ToTable("Maquina");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.PagamentoEntity", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Dados")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("FormaId")
                        .HasColumnType("int");

                    b.Property<int?>("FormaPagFrmId")
                        .HasColumnType("int");

                    b.HasKey("PagamentoId");

                    b.HasIndex("FormaPagFrmId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ProdutoEntity", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CapaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.HasKey("ProdutoID");

                    b.HasIndex("CapaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.TipoCupomEntity", b =>
                {
                    b.Property<int>("TipoCupomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.HasKey("TipoCupomId");

                    b.ToTable("TipoCupom");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.TipoUsuarioEntity", b =>
                {
                    b.Property<int>("TipoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.HasKey("TipoUsuarioId");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.AgendamentoEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.ClienteEntity", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.JogoEntity", "Jogo")
                        .WithMany()
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.MaquinaEntity", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Jogo");

                    b.Navigation("Maquina");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CarrinhoEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.ClienteEntity", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CartaoClienteEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.CartaoEntity", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.ClienteEntity", null)
                        .WithMany("Cartoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartao");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ClienteEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.UsuarioEntity", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CompraEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.CartaoEntity", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.CupomEntity", "Cupom")
                        .WithMany()
                        .HasForeignKey("CupomId");

                    b.HasOne("Infinite.Core.Domain.Entities.EnderecoEntity", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.PagamentoEntity", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartao");

                    b.Navigation("Cupom");

                    b.Navigation("Endereco");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CupomEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.TipoCupomEntity", "TipoCupom")
                        .WithMany()
                        .HasForeignKey("TipoCupomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoCupom");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.EnderecoClienteEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.ClienteEntity", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.EnderecoEntity", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.FotoProdutoEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.ArquivoEntity", "Arquivo")
                        .WithMany()
                        .HasForeignKey("ArquivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.ProdutoEntity", null)
                        .WithMany("Fotos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arquivo");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.FuncionarioEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.CupomEntity", "Cupom")
                        .WithMany()
                        .HasForeignKey("CupomId");

                    b.HasOne("Infinite.Core.Domain.Entities.UsuarioEntity", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cupom");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ItemCarrinhoEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.CarrinhoEntity", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CarrinhoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.ProdutoEntity", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.PagamentoEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.FormaPagEntity", "FormaPag")
                        .WithMany()
                        .HasForeignKey("FormaPagFrmId");

                    b.Navigation("FormaPag");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ProdutoEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.ArquivoEntity", "Capa")
                        .WithMany()
                        .HasForeignKey("CapaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infinite.Core.Domain.Entities.CategoriaEntity", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Capa");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.UsuarioEntity", b =>
                {
                    b.HasOne("Infinite.Core.Domain.Entities.TipoUsuarioEntity", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.CarrinhoEntity", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ClienteEntity", b =>
                {
                    b.Navigation("Cartoes");

                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("Infinite.Core.Domain.Entities.ProdutoEntity", b =>
                {
                    b.Navigation("Fotos");
                });
#pragma warning restore 612, 618
        }
    }
}
