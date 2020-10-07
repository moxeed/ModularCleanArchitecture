using System.Collections.Generic;
using Charity.Domain.Common;
using Charity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Charity.Application.IdentityModule.Interfaces;
using Charity.Application.Module.Interfaces;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Domain.Entities.Core;
using Charity.Domain.Entities.dbo;
using Microsoft.Data.SqlClient;
using System;

namespace Charity.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        #region CharityPhase1DataBase

        public DbSet<Philanthropist> Philanthropists { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectDynamicData> ProjectDynamicDatas { get; set; }
        
        public DbSet<Post> Posts { get; set; }

        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<FileType> FileTypes { get; set; }

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.Deleted = _dateTime.NowUtc;
                        entry.Entity.DeletedBy = _authenticatedUser.UserId;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            AddData(builder);
            base.OnModelCreating(builder);
        }


        private void AddData(ModelBuilder builder)
        {
            builder.Entity<ProjectType>().HasData(new List<ProjectType>
            {
                new ProjectType{Id = 1,TypeName = "مدرسه",TypeEnName = "School"}, 
                new ProjectType{Id = 2,TypeName = "کتابخانه",TypeEnName = "Library"} 
            });

            builder.Entity<State>().HasData(new List<State>
            {
                new State{Id = 1,Name = "تهران"},
                new State{Id = 2,Name = "تبریز"},
            });
            builder.Entity<City>().HasData(new List<City>
            {
                new City{Id = 1,Name = "تهران",StateId = 1},
                new City{Id = 2,Name = "تبریز", StateId = 2},
            });

            builder.Entity<FileType>().HasData(new FileType { Id = 1, TypeName = "عکس", TypeEnName = "Image" });

            builder.Entity<UploadedFile>().HasData(new List<UploadedFile>
            {
                new UploadedFile{Id = 1,Created= DateTime.Now, FileName= "defaultProgImg.png",FilePath="Images/default.png",TypeId=1},
                new UploadedFile{Id = 2,Created= DateTime.Now, FileName= "defaultProgImg.png",FilePath="Images/kanoonlogo.png",TypeId=1,PostId = 1,ProjectId =1},
                new UploadedFile{Id = 3,Created= DateTime.Now, FileName= "defaultProgImg.png",FilePath="Images/kanoonlogo.png",TypeId=1,PostId = 1,ProjectId =1}
            });


            builder.Entity<Post>().HasData(new Post
            { 
                Id = 1,
                Title = "PostTitle",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Risus ultricies tristique nulla aliquet enim tortor. Vel risus commodo viverra maecenas accumsan lacus. Duis ultricies lacus sed turpis tincidunt id aliquet. Felis donec et odio pellentesque diam volutpat commodo sed egestas. Sem integer vitae justo eget magna fermentum iaculis eu. Eget arcu dictum varius duis. Arcu dui vivamus arcu felis bibendum. Placerat duis ultricies lacus sed turpis tincidunt id. Elit sed vulputate mi sit amet mauris commodo quis imperdiet. Non blandit massa enim nec dui nunc mattis. Nibh cras pulvinar mattis nunc sed blandit libero volutpat sed. Turpis cursus in hac habitasse platea dictumst.",
                Created = DateTime.Now,
                Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut"
            });

            builder.Entity<Philanthropist>().HasData(new Philanthropist
            {
                Id = 1,
                FirstName = "john",
                LastName = "due",
                NationalCode = "0021122334",
                Occupation = "Teacher",
                Sex = true,
                StudyField = "Computer",
                StudyUniversity = "UT",
                StudyGrade = "advance",
                PhoneNumber = "093728371",
                Tel = "829327832",
                FavoriteField = "School",
                OccupationAddress = "Street St.",
                CharityActivitiesHistory = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Risus ultricies tristique nulla aliquet enim tortor. Vel risus commodo viverra maecenas accumsan lacus. Duis ultricies lacus sed turpis tincidunt id aliquet. Felis donec et odio pellentesque diam volutpat commodo sed egestas. Sem integer vitae justo eget magna fermentum iaculis eu. Eget arcu dictum varius duis. Arcu dui vivamus arcu felis bibendum. Placerat duis ultricies lacus sed turpis tincidunt id. Elit sed vulputate mi sit amet mauris commodo quis imperdiet. Non blandit massa enim nec dui nunc mattis. Nibh cras pulvinar mattis nunc sed blandit libero volutpat sed. Turpis cursus in hac habitasse platea dictumst.",
                CityId = 1,
                Created = DateTime.Now,
                Email = "p1@gmail.com",
                ImageId = 1
            });

            builder.Entity<Project>().HasData(new Project
            {
                Id = 1,
                PhilanthropistId =1,
                CityId = 2,
                Title = "Project Title",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Risus ultricies tristique nulla aliquet enim tortor.Vel risus commodo viverra maecenas accumsan lacus.Duis ultricies lacus sed turpis tincidunt id aliquet. Felis donec et odio pellentesque diam volutpat commodo sed egestas. Sem integer vitae justo eget magna fermentum iaculis eu.Eget arcu dictum varius duis.Arcu dui vivamus arcu felis bibendum. Placerat duis ultricies lacus sed turpis tincidunt id. Elit sed vulputate mi sit amet mauris commodo quis imperdiet. Non blandit massa enim nec dui nunc mattis. Nibh cras pulvinar mattis nunc sed blandit libero volutpat sed. Turpis cursus in hac habitasse platea dictumst.",
                Fund = 1939828738,
                StartDate = DateTime.Now.AddYears(-1),
                EstimatedEndDate = DateTime.Now.AddMonths(-1),
                ActualEndDate = DateTime.Now,
                TypeId = 1,
                SurfaceArea = 2000000,
                Created = DateTime.Now
            });

            builder.Entity<ProjectDynamicData>().HasData(new ProjectDynamicData {Id=1, ProjectId = 1, Name = "school", Value = "4" });

            
        }
    }
}
