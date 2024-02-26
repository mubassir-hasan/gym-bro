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
            var muscleListList = new List<Muscle>()
            {
                new (Title.Create("Biceps").Value,""),
                new (Title.Create("Long Head Bicep").Value,""),
                new (Title.Create("Short Head Bicep").Value, ""),
                new (Title.Create("Traps (mid-back)").Value, ""),
                new (Title.Create("Lower back").Value, ""),
                new (Title.Create("Abdominals").Value, "")      ,
                new (Title.Create("Lower Abdominals").Value, ""),
                new (Title.Create("Upper Abdominals").Value, ""),
                new (Title.Create("Calves").Value, ""),
                new (Title.Create("Tibialis").Value, ""),
                new (Title.Create("Soleus").Value, ""),
                new (Title.Create("Gastrocnemius").Value, ""),
                new (Title.Create("Forearms").Value, ""),
                new (Title.Create("Wrist Extensors").Value, ""),
                new(Title.Create("Wrist Flexors").Value, ""),
                new (Title.Create("Glutes").Value, ""),
                new (Title.Create("Gluteus Medius").Value, ""),
                new (Title.Create("Gluteus Maximus").Value, ""),
                new (Title.Create("Hamstrings").Value, ""),
                new (Title.Create("Medial Hamstrings").Value, ""),
                new (Title.Create("Lateral Hamstrings").Value, ""),
                new (Title.Create("Lats").Value, ""),
                new (Title.Create("Shoulders").Value, ""),
                new (Title.Create("Lateral Deltoid").Value, ""),
                new (Title.Create("Anterior Deltoid").Value, ""),
                new (Title.Create("Posterior Deltoid").Value, ""),
                new (Title.Create("Triceps").Value, ""),
                new (Title.Create("Long Head Tricep").Value, ""),
                new (Title.Create("Lateral Head Triceps").Value, ""),
                new (Title.Create("Medial Head Triceps").Value, ""),
                new (Title.Create("Traps").Value, ""),
                new (Title.Create("Upper Traps").Value, ""),
                new (Title.Create("Lower Traps").Value, ""),
                new (Title.Create("Quads").Value, ""),
                new (Title.Create("Inner Thigh").Value, ""),
                new (Title.Create("Inner Quadriceps").Value, ""),
                new (Title.Create("Outer Quadricep").Value, ""),
                new (Title.Create("Rectus Femoris").Value, ""),
                new (Title.Create("Chest").Value, ""),
                new (Title.Create("Upper Pectoralis").Value, ""),
                new (Title.Create("Mid and Lower Chest").Value, ""),
                new (Title.Create("Obliques").Value, ""),
                new (Title.Create("Hands").Value, ""),
                new (Title.Create("Feet").Value, ""),
                new (Title.Create("Front Shoulders").Value, ""),
                new (Title.Create("Rear Shoulders").Value, ""),

            };
            var existingMuscles=await _context.Muscles.Select(x=>x.Title).ToListAsync();

            var musclesToInsert = muscleListList.Where(x => !existingMuscles.Contains(x.Title));
            await _context.Muscles.AddRangeAsync(musclesToInsert);
            await _context.SaveChangesAsync();
        }
    }
}
