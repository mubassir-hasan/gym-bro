using GymBro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> Users { get; }
        DbSet<AppRole> Roles { get; }
        DbSet<Equipment> Equipments { get; }
        DbSet<Exercise> Exercises { get; }
        DbSet<ExerciseDetails> ExerciseDetails { get; }
        DbSet<ExerciseEquipment> ExerciseEquipments { get; }
        DbSet<ExerciseMuscle> ExerciseMuscles { get; }
        DbSet<Muscle> Muscles { get; }
        DbSet<WorkoutHistory> WorkoutHistories { get; }
        DbSet<WorkoutPlan> WorkoutPlans { get; }
        DbSet<WorkoutPlanDetails> WorkoutPlanDetails { get; }
        DbSet<OutboxMessage> OutboxMessages { get; }
        DbSet<WorkoutPlanDetailsGroup> WorkoutPlanDetailsGroups { get; }

        string GetConnectionString();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
