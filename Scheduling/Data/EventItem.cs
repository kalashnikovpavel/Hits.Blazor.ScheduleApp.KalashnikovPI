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
        public int Id { get; set; }
        public string? Title{ get; set; }
        public string? Addr{ get; set; }
        public string? Lector { get; set; }
        public string? Type { get; set; } 
        public TimeSlot Slot { get; set; }
        
        public DayOfWeek _dayOfWeek { get; set; }

        
    }
    public class EventService
    {
        private List<EventItem> _events = new List<EventItem>();
        private int _nextId = 1;

        // Метод для добавления события
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

        // Получение событий для определенного дня и слота
        public EventItem? GetEvent(int slotNumber, DayOfWeek dayOfWeek)
        {
            return _events.FirstOrDefault(e =>
                e.Slot == (TimeSlot)slotNumber &&
                e._dayOfWeek == dayOfWeek);
        }

        // Получение всех событий
        public List<EventItem> GetAllEvents() => _events;

        // Получение событий для определенного дня
        public List<EventItem> GetEventsByDay(DayOfWeek day)
        {
            return _events.Where(e => e._dayOfWeek == day).ToList();
        }
    }

}
