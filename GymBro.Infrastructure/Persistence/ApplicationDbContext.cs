using GymBro.Application.Common.Interfaces;
using GymBro.Domain.Entities;
using GymBro.Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, AppRole,string>, IApplicationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
            
        }



        public DbSet<Equipment> Equipments => Set<Equipment>();

        public DbSet<Exercise> Exercises => Set<Exercise>();

        public DbSet<ExerciseDetails> ExerciseDetails => Set<ExerciseDetails>();

        public DbSet<ExerciseEquipment> ExerciseEquipments => Set<ExerciseEquipment>();

        public DbSet<ExerciseMuscle> ExerciseMuscles => Set<ExerciseMuscle>();

        public DbSet<Muscle> Muscles => Set<Muscle>();

        public DbSet<WorkoutHistory> WorkoutHistories => Set<WorkoutHistory>();

        public DbSet<WorkoutPlan> WorkoutPlans => Set<WorkoutPlan>();

        public DbSet<WorkoutPlanDetails> WorkoutPlanDetails => Set<WorkoutPlanDetails>();


        public string GetConnectionString()
        {
            return Database.GetConnectionString()!;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.ApplyConfigurationsFromAssembly(typeof(GymBro.Domain.AssemblyReference).Assembly);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
