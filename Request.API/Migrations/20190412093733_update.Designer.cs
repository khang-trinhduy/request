﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Request.API.Infrastructure;

namespace Request.API.Migrations
{
    [DbContext(typeof(RequestContext))]
    [Migration("20190412093733_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Request.API.Model.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("RequestId");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("RequestId");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("Request.API.Model.Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId");

                    b.Property<int>("DataType");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("RequestId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("RequestId");

                    b.ToTable("Data");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Data");
                });

            modelBuilder.Entity("Request.API.Model.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<int?>("CurrentStateId");

                    b.Property<DateTime>("DateRequested");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<int>("ProcessId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("CurrentStateId");

                    b.HasIndex("ProcessId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Request.API.Model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId");

                    b.Property<DateTime>("DeadLine");

                    b.Property<bool>("IsDone");

                    b.Property<int>("RequestId");

                    b.Property<DateTime>("Start");

                    b.Property<string>("UserRole");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("RequestId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Request.API.Models.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ProcessId");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Request.API.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityType");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Duration");

                    b.Property<bool>("IsRequired");

                    b.Property<string>("Name");

                    b.Property<int>("ProcessId");

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.HasIndex("StateId");

                    b.ToTable("Activities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Activity");
                });

            modelBuilder.Entity("Request.API.Models.ExtendActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ExtendActivity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ExtendActivity");
                });

            modelBuilder.Entity("Request.API.Models.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("Request.API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId");

                    b.Property<string>("Name");

                    b.Property<int>("ProcessId");

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ProcessId");

                    b.HasIndex("StateId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Request.API.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ETA");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProcessId");

                    b.Property<int>("StateType");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Request.API.Models.TransitionRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActionId");

                    b.Property<int?>("CurrentStateId");

                    b.Property<int?>("NextStateId");

                    b.Property<int>("ProcessId");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("CurrentStateId");

                    b.HasIndex("NextStateId");

                    b.HasIndex("ProcessId");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("Request.API.Models.Comment", b =>
                {
                    b.HasBaseType("Request.API.Model.Data");

                    b.Property<byte[]>("Emoji");

                    b.Property<string>("Messages");

                    b.Property<string>("Topic");

                    b.ToTable("Data");

                    b.HasDiscriminator().HasValue("COMMENT");
                });

            modelBuilder.Entity("Request.API.Models.Email", b =>
                {
                    b.HasBaseType("Request.API.Model.Data");

                    b.Property<byte[]>("Attach");

                    b.Property<string>("Client");

                    b.Property<string>("ConfirmEmail");

                    b.Property<string>("ConfirmPass");

                    b.Property<string>("Contents");

                    b.Property<string>("From");

                    b.Property<bool>("IsSent");

                    b.Property<string>("Server");

                    b.Property<string>("Subject");

                    b.Property<string>("To");

                    b.ToTable("Data");

                    b.HasDiscriminator().HasValue("EMAIL");
                });

            modelBuilder.Entity("Request.API.Models.TLeave", b =>
                {
                    b.HasBaseType("Request.API.Model.Data");

                    b.Property<string>("AbsentName");

                    b.Property<string>("ApproverName");

                    b.Property<DateTime>("DayOff");

                    b.Property<bool>("IsDone");

                    b.Property<bool>("IsReallyNotApproved");

                    b.Property<string>("Reason");

                    b.ToTable("Data");

                    b.HasDiscriminator().HasValue("TALENT-LEAVE");
                });

            modelBuilder.Entity("Request.API.Models.ActivityAdapter", b =>
                {
                    b.HasBaseType("Request.API.Models.Activity");

                    b.Property<int?>("ExtendActivityId");

                    b.HasIndex("ExtendActivityId");

                    b.ToTable("Activities");

                    b.HasDiscriminator().HasValue("ADAPTER");
                });

            modelBuilder.Entity("Request.API.Models.EmailActivityOperator", b =>
                {
                    b.HasBaseType("Request.API.Models.Activity");

                    b.Property<int?>("AdapterId");

                    b.HasIndex("AdapterId");

                    b.ToTable("Activities");

                    b.HasDiscriminator().HasValue("EMAIL");
                });

            modelBuilder.Entity("Request.API.Models.GenericActivityOperator", b =>
                {
                    b.HasBaseType("Request.API.Models.Activity");

                    b.Property<int?>("AdapterId")
                        .HasColumnName("GenericActivityOperator_AdapterId");

                    b.HasIndex("AdapterId");

                    b.ToTable("Activities");

                    b.HasDiscriminator().HasValue("GENERIC");
                });

            modelBuilder.Entity("Request.API.Models.TLActivityOperator", b =>
                {
                    b.HasBaseType("Request.API.Models.Activity");

                    b.Property<string>("AbsentName");

                    b.Property<int?>("AdapterId")
                        .HasColumnName("TLActivityOperator_AdapterId");

                    b.Property<string>("ApproverName");

                    b.Property<DateTime>("DayOff");

                    b.Property<bool>("IsReallyNotApproved");

                    b.Property<string>("Reason");

                    b.HasIndex("AdapterId");

                    b.ToTable("Activities");

                    b.HasDiscriminator().HasValue("TALENT-LEAVE");
                });

            modelBuilder.Entity("Request.API.Models.EmailSender", b =>
                {
                    b.HasBaseType("Request.API.Models.ExtendActivity");

                    b.HasDiscriminator().HasValue("EmailSender");
                });

            modelBuilder.Entity("Request.API.Model.ActivityLog", b =>
                {
                    b.HasOne("Request.API.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("Request.API.Model.Request", "Request")
                        .WithMany("Histories")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Request.API.Model.Data", b =>
                {
                    b.HasOne("Request.API.Models.Activity", "Activity")
                        .WithMany("Data")
                        .HasForeignKey("ActivityId");

                    b.HasOne("Request.API.Model.Request", "Request")
                        .WithMany("Data")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("Request.API.Model.Request", b =>
                {
                    b.HasOne("Request.API.Models.State", "CurrentState")
                        .WithMany()
                        .HasForeignKey("CurrentStateId");

                    b.HasOne("Request.API.Models.Process", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Request.API.Model.Task", b =>
                {
                    b.HasOne("Request.API.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("Request.API.Model.Request", "Request")
                        .WithMany("Tasks")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Request.API.Models.Action", b =>
                {
                    b.HasOne("Request.API.Models.Process")
                        .WithMany("Actions")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Request.API.Models.Activity", b =>
                {
                    b.HasOne("Request.API.Models.Process", "Process")
                        .WithMany("Activities")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Request.API.Models.State", "State")
                        .WithMany("Activities")
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("Request.API.Models.Role", b =>
                {
                    b.HasOne("Request.API.Models.Activity", "Activity")
                        .WithMany("Roles")
                        .HasForeignKey("ActivityId");

                    b.HasOne("Request.API.Models.Process", "Process")
                        .WithMany("Roles")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Request.API.Models.State", "State")
                        .WithMany("Roles")
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("Request.API.Models.State", b =>
                {
                    b.HasOne("Request.API.Models.Process", "Process")
                        .WithMany("States")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Request.API.Models.TransitionRule", b =>
                {
                    b.HasOne("Request.API.Models.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("Request.API.Models.State", "CurrentState")
                        .WithMany()
                        .HasForeignKey("CurrentStateId");

                    b.HasOne("Request.API.Models.State", "NextState")
                        .WithMany()
                        .HasForeignKey("NextStateId");

                    b.HasOne("Request.API.Models.Process", "Process")
                        .WithMany("Rules")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Request.API.Models.ActivityAdapter", b =>
                {
                    b.HasOne("Request.API.Models.ExtendActivity", "ExtendActivity")
                        .WithMany()
                        .HasForeignKey("ExtendActivityId");
                });

            modelBuilder.Entity("Request.API.Models.EmailActivityOperator", b =>
                {
                    b.HasOne("Request.API.Models.ActivityAdapter", "Adapter")
                        .WithMany()
                        .HasForeignKey("AdapterId");
                });

            modelBuilder.Entity("Request.API.Models.GenericActivityOperator", b =>
                {
                    b.HasOne("Request.API.Models.ActivityAdapter", "Adapter")
                        .WithMany()
                        .HasForeignKey("AdapterId");
                });

            modelBuilder.Entity("Request.API.Models.TLActivityOperator", b =>
                {
                    b.HasOne("Request.API.Models.ActivityAdapter", "Adapter")
                        .WithMany()
                        .HasForeignKey("AdapterId");
                });
#pragma warning restore 612, 618
        }
    }
}
