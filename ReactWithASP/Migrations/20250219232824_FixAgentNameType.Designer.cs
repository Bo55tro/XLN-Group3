﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactWithASP.Data;

#nullable disable

namespace ReactWithASP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250219232824_FixAgentNameType")]
    partial class FixAgentNameType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.16");

            modelBuilder.Entity("ReactWithASP.Models.Agent", b =>
                {
                    b.Property<int>("agentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("agentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("agentPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("agentUsername")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("agentId");

                    b.ToTable("Agents", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
