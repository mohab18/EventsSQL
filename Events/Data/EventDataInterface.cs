using Events.Models;

namespace Events.Data
{
    public interface EventDataInterface
    {
        public List<Event> RetrieveAllEvents();

        public Event RetrieveEvent(int id);

        public void AddEvent(Event EventToBeAdded);

        public void UpdateEvent(Event EventToBeUpdated);

        public void DeleteEvent(int id);


    }
}
