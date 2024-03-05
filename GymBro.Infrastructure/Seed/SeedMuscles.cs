using GymBro.Domain.Entities;
using GymBro.Domain.ValueObjects;
using GymBro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymBro.Infrastructure.Seed
{
    public sealed class SeedMuscles
    {
        private readonly ApplicationDbContext _context;

        public SeedMuscles(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            var muscleList = new List<Muscle>()
        {
            new Muscle { Title = Title.Create("Biceps").Value, Image = "" },
            new Muscle { Title = Title.Create("Long Head Bicep").Value, Image = "" },
            new Muscle { Title = Title.Create("Short Head Bicep").Value, Image = "" },
            new Muscle { Title = Title.Create("Traps (mid-back)").Value, Image = "" },
            new Muscle { Title = Title.Create("Lower back").Value, Image = "" },
            new Muscle { Title = Title.Create("Abdominals").Value, Image = "" },
            new Muscle { Title = Title.Create("Lower Abdominals").Value, Image = "" },
            new Muscle { Title = Title.Create("Upper Abdominals").Value, Image = "" },
            new Muscle { Title = Title.Create("Calves").Value, Image = "" },
            new Muscle { Title = Title.Create("Tibialis").Value, Image = "" },
            new Muscle { Title = Title.Create("Soleus").Value, Image = "" },
            new Muscle { Title = Title.Create("Gastrocnemius").Value, Image = "" },
            new Muscle { Title = Title.Create("Forearms").Value, Image = "" },
            new Muscle { Title = Title.Create("Wrist Extensors").Value, Image = "" },
            new Muscle { Title = Title.Create("Wrist Flexors").Value, Image = "" },
            new Muscle { Title = Title.Create("Glutes").Value, Image = "" },
            new Muscle { Title = Title.Create("Gluteus Medius").Value, Image = "" },
            new Muscle { Title = Title.Create("Gluteus Maximus").Value, Image = "" },
            new Muscle { Title = Title.Create("Hamstrings").Value, Image = "" },
            new() { Title = Title.Create("Medial Hamstrings").Value, Image = "" },
            new() { Title = Title.Create("Lateral Hamstrings").Value, Image = "" },
            new Muscle { Title = Title.Create("Lats").Value, Image = "" },
            new Muscle { Title = Title.Create("Shoulders").Value, Image = "" },
            new Muscle { Title = Title.Create("Lateral Deltoid").Value, Image = "" },
            new Muscle { Title = Title.Create("Anterior Deltoid").Value, Image = "" },
            new Muscle { Title = Title.Create("Posterior Deltoid").Value, Image = "" },
            new Muscle { Title = Title.Create("Triceps").Value, Image = "" },
            new Muscle { Title = Title.Create("Long Head Tricep").Value, Image = "" },
            new Muscle { Title = Title.Create("Lateral Head Triceps").Value, Image = "" },
            new Muscle { Title = Title.Create("Medial Head Triceps").Value, Image = "" },
            new Muscle { Title = Title.Create("Traps").Value, Image = "" },
            new Muscle { Title = Title.Create("Upper Traps").Value, Image = "" },
            new Muscle { Title = Title.Create("Lower Traps").Value, Image = "" },
            new Muscle { Title = Title.Create("Quads").Value, Image = "" },
            new Muscle { Title = Title.Create("Inner Thigh").Value, Image = "" },
            new Muscle { Title = Title.Create("Inner Quadriceps").Value, Image = "" },
            new Muscle { Title = Title.Create("Outer Quadricep").Value, Image = "" },
            new Muscle { Title = Title.Create("Rectus Femoris").Value, Image = "" },
            new Muscle { Title = Title.Create("Chest").Value, Image = "" },
            new Muscle { Title = Title.Create("Upper Pectoralis").Value, Image = "" },
            new Muscle { Title = Title.Create("Mid and Lower Chest").Value, Image = "" },
            new Muscle { Title = Title.Create("Obliques").Value, Image = "" },
            new Muscle { Title = Title.Create("Hands").Value, Image = "" },
            new Muscle { Title = Title.Create("Feet").Value, Image = "" },
            new Muscle { Title = Title.Create("Front Shoulders").Value, Image = "" },
            new Muscle { Title = Title.Create("Rear Shoulders").Value, Image = "" }
        };
            var existingMuscles = await _context.Muscles.Select(x => x.Title).ToListAsync();

            var musclesToInsert = muscleList.Where(x => !existingMuscles.Contains(x.Title));
            await _context.Muscles.AddRangeAsync(musclesToInsert);
            await _context.SaveChangesAsync();
        }
    }
}
