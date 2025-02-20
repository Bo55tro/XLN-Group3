﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactWithASP.Data;

#nullable disable

namespace ReactWithASP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ReactWithASP.Models.Case", b =>
                {
                    b.Property<int>("caseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DetailId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReasonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("agentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("caseComments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("caseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("caseKeyWords")
                        .HasColumnType("TEXT");

                    b.Property<string>("caseNotes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("caseStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("caseId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DetailId");

                    b.HasIndex("ReasonId");

                    b.ToTable("Cases", (string)null);
                });

            modelBuilder.Entity("ReactWithASP.Models.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("categoryId");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("ReactWithASP.Models.Client", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("clientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("clientId");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("ReactWithASP.Models.Detail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DetailName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReasonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetailId");

                    b.HasIndex("ReasonId");

                    b.ToTable("Details", (string)null);
                });

            modelBuilder.Entity("ReactWithASP.Models.Reason", b =>
                {
                    b.Property<int>("ReasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReasonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReasonId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Reasons", (string)null);
                });

            modelBuilder.Entity("ReactWithASP.Models.Case", b =>
                {
                    b.HasOne("ReactWithASP.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReactWithASP.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReactWithASP.Models.Detail", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReactWithASP.Models.Reason", "Reason")
                        .WithMany()
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Client");

                    b.Navigation("Detail");

                    b.Navigation("Reason");
                });

            modelBuilder.Entity("ReactWithASP.Models.Detail", b =>
                {
                    b.HasOne("ReactWithASP.Models.Reason", "Reason")
                        .WithMany()
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reason");
                });

            modelBuilder.Entity("ReactWithASP.Models.Reason", b =>
                {
                    b.HasOne("ReactWithASP.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
