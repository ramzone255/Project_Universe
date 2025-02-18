﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Universe.Persistence.src.Data;

#nullable disable

namespace Project_Universe.Persistence.Migrations
{
    [DbContext(typeof(Project_UniverseDbContext))]
    partial class Project_UniverseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Contractor_Company", b =>
                {
                    b.Property<int>("id_contractor_company")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_contractor_company"));

                    b.Property<string>("description_contractor_company")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("name_contractor_company")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id_contractor_company");

                    b.HasIndex("id_contractor_company")
                        .IsUnique();

                    b.ToTable("Contractor_Company");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Customer_Company", b =>
                {
                    b.Property<int>("id_customer_company")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_customer_company"));

                    b.Property<string>("description_customer_company")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("name_customer_company")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id_customer_company");

                    b.HasIndex("id_customer_company")
                        .IsUnique();

                    b.ToTable("Customer_Company");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Post", b =>
                {
                    b.Property<int>("id_post")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_post"));

                    b.Property<string>("name_post")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id_post");

                    b.HasIndex("id_post")
                        .IsUnique();

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Priority", b =>
                {
                    b.Property<int>("id_priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_priority"));

                    b.Property<string>("name_priority")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id_priority");

                    b.HasIndex("id_priority")
                        .IsUnique();

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Project", b =>
                {
                    b.Property<int>("id_project")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_project"));

                    b.Property<DateTime?>("end_date_project")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_contractor_company")
                        .HasColumnType("int");

                    b.Property<int>("id_customer_company")
                        .HasColumnType("int");

                    b.Property<int>("id_priority")
                        .HasColumnType("int");

                    b.Property<string>("name_project")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("start_date_project")
                        .HasColumnType("datetime2");

                    b.HasKey("id_project");

                    b.HasIndex("id_contractor_company");

                    b.HasIndex("id_customer_company");

                    b.HasIndex("id_priority");

                    b.HasIndex("id_project")
                        .IsUnique();

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Project_Task", b =>
                {
                    b.Property<int>("id_project_task")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_project_task"));

                    b.Property<int?>("id_project")
                        .HasColumnType("int");

                    b.Property<int?>("id_task")
                        .HasColumnType("int");

                    b.HasKey("id_project_task");

                    b.HasIndex("id_project");

                    b.HasIndex("id_project_task")
                        .IsUnique();

                    b.HasIndex("id_task");

                    b.ToTable("Project_Task");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Staff", b =>
                {
                    b.Property<int>("id_staff")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_staff"));

                    b.Property<string>("email_staff")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("id_post")
                        .HasColumnType("int");

                    b.Property<string>("lastname_staff")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name_staff")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("patronymic_staff")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id_staff");

                    b.HasIndex("id_post");

                    b.HasIndex("id_staff")
                        .IsUnique();

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Status", b =>
                {
                    b.Property<int>("id_status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_status"));

                    b.Property<string>("name_status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id_status");

                    b.HasIndex("id_status")
                        .IsUnique();

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Task", b =>
                {
                    b.Property<int>("id_task")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_task"));

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("id_priority")
                        .HasColumnType("int");

                    b.Property<int>("id_status")
                        .HasColumnType("int");

                    b.Property<string>("name_task")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id_task");

                    b.HasIndex("id_priority");

                    b.HasIndex("id_status");

                    b.HasIndex("id_task")
                        .IsUnique();

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Task_Staff", b =>
                {
                    b.Property<int>("id_task_staff")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_task_staff"));

                    b.Property<int?>("id_staff")
                        .HasColumnType("int");

                    b.Property<int?>("id_task")
                        .HasColumnType("int");

                    b.HasKey("id_task_staff");

                    b.HasIndex("id_staff");

                    b.HasIndex("id_task");

                    b.HasIndex("id_task_staff")
                        .IsUnique();

                    b.ToTable("Task_Staff");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.User", b =>
                {
                    b.Property<int>("id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_user"));

                    b.Property<int>("id_staff")
                        .HasColumnType("int");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id_user");

                    b.HasIndex("id_staff");

                    b.HasIndex("id_user")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Project", b =>
                {
                    b.HasOne("Project_Universe.Domain.src.Entities.Contractor_Company", "Contractor_Company")
                        .WithMany("Project")
                        .HasForeignKey("id_contractor_company")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Universe.Domain.src.Entities.Customer_Company", "Customer_Company")
                        .WithMany("Project")
                        .HasForeignKey("id_customer_company")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Universe.Domain.src.Entities.Priority", "Priority")
                        .WithMany("Project")
                        .HasForeignKey("id_priority")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor_Company");

                    b.Navigation("Customer_Company");

                    b.Navigation("Priority");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Project_Task", b =>
                {
                    b.HasOne("Project_Universe.Domain.src.Entities.Project", "Project")
                        .WithMany("Project_Task")
                        .HasForeignKey("id_project")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Project_Universe.Domain.src.Entities.Task", "Task")
                        .WithMany("Project_Task")
                        .HasForeignKey("id_task")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Project");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Staff", b =>
                {
                    b.HasOne("Project_Universe.Domain.src.Entities.Post", "Post")
                        .WithMany("Staff")
                        .HasForeignKey("id_post")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Task", b =>
                {
                    b.HasOne("Project_Universe.Domain.src.Entities.Priority", "Priority")
                        .WithMany("Task")
                        .HasForeignKey("id_priority")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Universe.Domain.src.Entities.Status", "Status")
                        .WithMany("Task")
                        .HasForeignKey("id_status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Priority");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Task_Staff", b =>
                {
                    b.HasOne("Project_Universe.Domain.src.Entities.Staff", "Staff")
                        .WithMany("Task_Staff")
                        .HasForeignKey("id_staff")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Project_Universe.Domain.src.Entities.Task", "Task")
                        .WithMany("Task_Staff")
                        .HasForeignKey("id_task")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Staff");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.User", b =>
                {
                    b.HasOne("Project_Universe.Domain.src.Entities.Staff", "Staff")
                        .WithMany("User")
                        .HasForeignKey("id_staff")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Contractor_Company", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Customer_Company", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Post", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Priority", b =>
                {
                    b.Navigation("Project");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Project", b =>
                {
                    b.Navigation("Project_Task");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Staff", b =>
                {
                    b.Navigation("Task_Staff");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Status", b =>
                {
                    b.Navigation("Task");
                });

            modelBuilder.Entity("Project_Universe.Domain.src.Entities.Task", b =>
                {
                    b.Navigation("Project_Task");

                    b.Navigation("Task_Staff");
                });
#pragma warning restore 612, 618
        }
    }
}
