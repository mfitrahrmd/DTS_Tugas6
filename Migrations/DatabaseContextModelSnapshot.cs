﻿// <auto-generated />
using System;
using DTS_Tugas6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DTSTugas6.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DTS_Tugas6.Models.Account", b =>
                {
                    b.Property<string>("EmployeeNik")
                        .HasColumnType("char(5)")
                        .HasColumnName("employee_nik");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.HasKey("EmployeeNik")
                        .HasName("pk_tb_m_accounts");

                    b.ToTable("TB_M_Accounts", (string)null);
                });

            modelBuilder.Entity("DTS_Tugas6.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNik")
                        .IsRequired()
                        .HasColumnType("char(5)")
                        .HasColumnName("account_nik");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_tb_tr_account_roles");

                    b.HasIndex("AccountNik")
                        .HasDatabaseName("ix_tb_tr_account_roles_account_nik");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_tb_tr_account_roles_role_id");

                    b.ToTable("TB_TR_Account_Roles", (string)null);
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("degree");

                    b.Property<decimal>("GPA")
                        .HasColumnType("decimal(3,2)")
                        .HasColumnName("gpa");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("major");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("Id")
                        .HasName("pk_tb_m_educations");

                    b.HasIndex("UniversityId")
                        .HasDatabaseName("ix_tb_m_educations_university_id");

                    b.ToTable("TB_M_Educations", (string)null);
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Employee", b =>
                {
                    b.Property<string>("Nik")
                        .HasColumnType("char(5)")
                        .HasColumnName("nik");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Nik")
                        .HasName("pk_tb_m_employees");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_tb_m_employees_email");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasDatabaseName("ix_tb_m_employees_phone_number")
                        .HasFilter("[phone_number] IS NOT NULL");

                    b.ToTable("TB_M_Employees", (string)null);
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Profiling", b =>
                {
                    b.Property<string>("EmployeeNik")
                        .HasColumnType("char(5)")
                        .HasColumnName("employee_nik");

                    b.Property<int>("EducationId")
                        .HasColumnType("int")
                        .HasColumnName("education_id");

                    b.HasKey("EmployeeNik")
                        .HasName("pk_tb_tr_profilings");

                    b.HasIndex("EducationId")
                        .IsUnique()
                        .HasDatabaseName("ix_tb_tr_profilings_education_id");

                    b.ToTable("TB_TR_Profilings", (string)null);
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_tb_m_roles");

                    b.ToTable("TB_M_Roles", (string)null);
                });

            modelBuilder.Entity("DTS_Tugas6.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_tb_m_universities");

                    b.ToTable("TB_M_Universities", (string)null);
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Account", b =>
                {
                    b.HasOne("DTS_Tugas6.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("DTS_Tugas6.Models.Account", "EmployeeNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tb_m_accounts_tb_m_employees_employee_nik");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DTS_Tugas6.Models.AccountRole", b =>
                {
                    b.HasOne("DTS_Tugas6.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountNik")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_tb_tr_account_roles_tb_m_accounts_account_nik");

                    b.HasOne("DTS_Tugas6.Models.Role", "Role")
                        .WithMany("AccountsRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_tb_tr_account_roles_tb_m_roles_role_id");

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Education", b =>
                {
                    b.HasOne("DTS_Tugas6.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tb_m_educations_tb_m_universities_university_id");

                    b.Navigation("University");
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Profiling", b =>
                {
                    b.HasOne("DTS_Tugas6.Models.Education", "Education")
                        .WithOne("Profiling")
                        .HasForeignKey("DTS_Tugas6.Models.Profiling", "EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tb_tr_profilings_tb_m_educations_education_id");

                    b.HasOne("DTS_Tugas6.Models.Employee", "Employee")
                        .WithOne("Profiling")
                        .HasForeignKey("DTS_Tugas6.Models.Profiling", "EmployeeNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tb_tr_profilings_tb_m_employees_employee_nik");

                    b.Navigation("Education");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Education", b =>
                {
                    b.Navigation("Profiling")
                        .IsRequired();
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Employee", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Profiling")
                        .IsRequired();
                });

            modelBuilder.Entity("DTS_Tugas6.Models.Role", b =>
                {
                    b.Navigation("AccountsRoles");
                });

            modelBuilder.Entity("DTS_Tugas6.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
