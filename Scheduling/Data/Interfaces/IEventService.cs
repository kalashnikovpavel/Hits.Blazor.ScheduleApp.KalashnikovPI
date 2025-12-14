namespace Scheduling.Data.Interfaces
{
    public interface IEventService
    {
        public EventItem AddEvent(
            string title,
            string addr,
            string lector,
            string type,
            TimeSlot slot,
            DayOfWeek dayOfWeek);

        public EventItem? GetEvent(int slotNumber, DayOfWeek dayOfWeek);
        public List<EventItem> GetAllEvents();
        public List<EventItem> GetEventsByDay(DayOfWeek day);
        public void RemoveEvent(int id);
    }
}
