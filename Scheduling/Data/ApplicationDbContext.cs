using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Scheduling.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<EventItem> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EventItem>().HasData(
                new EventItem
                {
                    Id = 1,
                    Title = "Математика",
                    Addr = "Ауд. 101",
                    Lector = "Иванов И.И.",
                    Type = "Лекция",
                    Slot = TimeSlot.Slot1,
                    _dayOfWeek = DayOfWeek.Monday
                },

                new EventItem
                {
                    Id = 2,
                    Title = "Физика",
                    Addr = "Ауд. 203",
                    Lector = "Петров П.П.",
                    Type = "Лекция",
                    Slot = TimeSlot.Slot2,
                    _dayOfWeek = DayOfWeek.Tuesday
                },

                new EventItem
                {
                    Id = 3,
                    Title = "Программирование",
                    Addr = "Ауд. 304",
                    Lector = "Сидоров C.C.",
                    Type = "Лабораторная",
                    Slot = TimeSlot.Slot3,
                    _dayOfWeek = DayOfWeek.Wednesday
                }
            );
        }
    }
}
