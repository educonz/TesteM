﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TesteMeta.Domain;

namespace Data.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20180401012849_EntidadeUsuario")]
    partial class EntidadeUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Usuarios.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TesteMeta.Domain.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Estado");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("TesteMeta.Domain.Fornecedor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("TesteMeta.Domain.ServicoPrestado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAtendimento");

                    b.Property<string>("DescricaoServico");

                    b.Property<long>("IdCliente");

                    b.Property<long>("IdFornecedor");

                    b.Property<int>("TipoServico");

                    b.Property<decimal>("ValorServico");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("ServicoPrestado");
                });

            modelBuilder.Entity("TesteMeta.Domain.ServicoPrestado", b =>
                {
                    b.HasOne("TesteMeta.Domain.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TesteMeta.Domain.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
