using System.ComponentModel.DataAnnotations;

namespace Scheduling.Data
{
    public enum TimeSlot
    {
        Slot1 = 1, 
        Slot2 = 2, 
        Slot3 = 3, 
        Slot4 = 4, 
        Slot5 = 5, 
        Slot6 = 6, 
        Slot7 = 7, 
        Slot8 = 8,
    }
    public class EventItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title{ get; set; }
    
        public string? Addr{ get; set; }
        
        public string? Lector { get; set; }
        public string? Type { get; set; } 
        
        public TimeSlot Slot { get; set; }
        public DayOfWeek _dayOfWeek { get; set; }

        
    }

}
