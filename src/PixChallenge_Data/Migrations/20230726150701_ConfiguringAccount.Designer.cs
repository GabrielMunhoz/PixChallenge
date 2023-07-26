﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PixChallenge_Data.Context;

#nullable disable

namespace PixChallenge_Data.Migrations
{
    [DbContext(typeof(PixChallengeContext))]
    [Migration("20230726150701_ConfiguringAccount")]
    partial class ConfiguringAccount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PixChallenge_Core.Entities.AccountHolder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KeyType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountHolder");
                });

            modelBuilder.Entity("PixChallenge_Core.Entities.BankTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateProcessed")
                        .HasColumnType("datetime2");

                    b.Property<int>("KeyType")
                        .HasColumnType("int");

                    b.Property<string>("PayeeKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("BankTransaction");
                });

            modelBuilder.Entity("PixChallenge_Core.Entities.BankTransaction", b =>
                {
                    b.HasOne("PixChallenge_Core.Entities.AccountHolder", "Sender")
                        .WithMany("BankTransactions")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("PixChallenge_Core.Entities.AccountHolder", b =>
                {
                    b.Navigation("BankTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
