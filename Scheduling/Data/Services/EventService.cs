using Scheduling.Data.Interfaces;

namespace Scheduling.Data.Services
{
    public class EventService : IEventService
    {
        private List<EventItem> _events = new List<EventItem>();
        private int _nextId = 1;

        
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
                Id = _nextId++,
                Title = title,
                Addr = addr,
                Lector = lector,
                Type = type,
                Slot = slot,
                _dayOfWeek = dayOfWeek
            };

            _events.Add(newEvent);
            return newEvent;
        }

       
        public EventItem? GetEvent(int slotNumber, DayOfWeek dayOfWeek)
        {
            return _events.FirstOrDefault(e =>
                e.Slot == (TimeSlot)slotNumber &&
                e._dayOfWeek == dayOfWeek);
        }

        
        public List<EventItem> GetAllEvents() => _events;

        
        public List<EventItem> GetEventsByDay(DayOfWeek day)
        {
            return _events.Where(e => e._dayOfWeek == day).ToList();
        }

        public void RemoveEvent(int id)
        {
            var eventToRemove = _events.FirstOrDefault(e => e.Id == id);
            if (eventToRemove != null)
            {
                _events.Remove(eventToRemove);
            }
        }
    }
}
