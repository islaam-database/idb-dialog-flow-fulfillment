﻿// <auto-generated />
using System;
using Islaam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Islaam.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20190908210131_StudentTeacherSource")]
    partial class StudentTeacherSource
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Islaam.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Source");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Islaam.Generation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Generations");
                });

            modelBuilder.Entity("Islaam.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BirthYear");

                    b.Property<string>("BirthYearSource");

                    b.Property<int?>("DeathYear");

                    b.Property<string>("DeathYearSource");

                    b.Property<string>("FillNameSource");

                    b.Property<string>("FullName");

                    b.Property<int?>("GenerationId");

                    b.Property<string>("GenerationSource");

                    b.Property<string>("Location");

                    b.Property<string>("LocationSource");

                    b.Property<int?>("MainTitleId");

                    b.Property<string>("MainTitleSource");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Source");

                    b.Property<int?>("TaqreedId");

                    b.Property<bool>("UseMascPron");

                    b.HasKey("Id");

                    b.HasIndex("GenerationId");

                    b.HasIndex("MainTitleId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Islaam.Praise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PraiseeId");

                    b.Property<int>("PraiserId");

                    b.Property<string>("Source")
                        .IsRequired();

                    b.Property<int?>("TitleId");

                    b.Property<int?>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("PraiseeId");

                    b.HasIndex("PraiserId");

                    b.HasIndex("TitleId");

                    b.HasIndex("TopicId");

                    b.ToTable("Praises");
                });

            modelBuilder.Entity("Islaam.Status", b =>
                {
                    b.Property<int?>("Rank")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("MentionPraisesOfEqualStatuses");

                    b.Property<bool>("MentionPraisesOfGreaterStatuses");

                    b.Property<string>("Name");

                    b.HasKey("Rank");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Islaam.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentSubjectId");

                    b.HasKey("Id");

                    b.HasIndex("ParentSubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Islaam.TeacherStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Source")
                        .IsRequired();

                    b.Property<int?>("StudentId");

                    b.Property<int?>("SubjectId");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherStudents");
                });

            modelBuilder.Entity("Islaam.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("StatusRank");

                    b.HasKey("Id");

                    b.HasIndex("StatusRank");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("Islaam.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ParentTopicId");

                    b.HasKey("Id");

                    b.HasIndex("ParentTopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Islaam.Book", b =>
                {
                    b.HasOne("Islaam.Person", "Author")
                        .WithMany("BooksAuthored")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("Islaam.Person", b =>
                {
                    b.HasOne("Islaam.Generation", "Generation")
                        .WithMany()
                        .HasForeignKey("GenerationId");

                    b.HasOne("Islaam.Praise", "MainTitle")
                        .WithMany()
                        .HasForeignKey("MainTitleId");
                });

            modelBuilder.Entity("Islaam.Praise", b =>
                {
                    b.HasOne("Islaam.Person", "Praisee")
                        .WithMany("PraisesReceived")
                        .HasForeignKey("PraiseeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Islaam.Person", "Praiser")
                        .WithMany("PraisesGiven")
                        .HasForeignKey("PraiserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Islaam.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId");

                    b.HasOne("Islaam.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("Islaam.Subject", b =>
                {
                    b.HasOne("Islaam.Subject", "ParentSubject")
                        .WithMany()
                        .HasForeignKey("ParentSubjectId");
                });

            modelBuilder.Entity("Islaam.TeacherStudent", b =>
                {
                    b.HasOne("Islaam.Person", "Student")
                        .WithMany("Teachers")
                        .HasForeignKey("StudentId");

                    b.HasOne("Islaam.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("Islaam.Person", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Islaam.Title", b =>
                {
                    b.HasOne("Islaam.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusRank");
                });

            modelBuilder.Entity("Islaam.Topic", b =>
                {
                    b.HasOne("Islaam.Topic", "ParentTopic")
                        .WithMany("ChildTopics")
                        .HasForeignKey("ParentTopicId");
                });
#pragma warning restore 612, 618
        }
    }
}
