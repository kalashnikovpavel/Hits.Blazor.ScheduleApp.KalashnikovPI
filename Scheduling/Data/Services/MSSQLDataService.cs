using Scheduling.Data.Interfaces;

namespace Scheduling.Data.Services
{
    public class MSSQLDataService : IEventService
    {
        
        private readonly  ApplicationDbContext _context;

        public MSSQLDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public EventItem AddEvent(
            string title,
            string addr,
            string lector,
            string type,
            TimeSlot slot,
            DayOfWeek dayOfWeek)
        {
            var newEvent = new EventItem
            {
                Title = title,
                Addr = addr,
                Lector = lector,
                Type = type,
                Slot = slot,
                _dayOfWeek = dayOfWeek
            };

            _context.Events.Add(newEvent);
            _context.SaveChanges();

            return newEvent;
        }

        public EventItem? GetEvent(int slotNumber, DayOfWeek dayOfWeek)
        {
            return _context.Events
                .FirstOrDefault(e =>
                    e.Slot == (TimeSlot)slotNumber &&
                    e._dayOfWeek == dayOfWeek);
        }

        public List<EventItem> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public List<EventItem> GetEventsByDay(DayOfWeek day)
        {
            return _context.Events
                .Where(e => e._dayOfWeek == day)
                .ToList();
        }

        public void RemoveEvent(int id) 
        {
            throw new NotImplementedException();
        }
    }
}
