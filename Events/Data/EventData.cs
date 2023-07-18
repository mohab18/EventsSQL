using Events.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.Data 
{
    public class EventData : EventDataInterface
    {
        private readonly EventDbContext DbContext;

        public EventData(EventDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public List<Event> RetrieveAllEvents()
        {
            return DbContext.RetrieveAllEvents();
        }

        public Event RetrieveEvent(int id)
        {
            return DbContext.RetrieveEvent(id);
        }

        public void AddEvent(Event EventToBeAdded)
        {
            DbContext.AddEvent(EventToBeAdded);

        }

        public void UpdateEvent(Event EventToBeUpdated)
        {
            DbContext.UpdateEvent(EventToBeUpdated);
        }

        public void DeleteEvent(int id)
        {
            DbContext.DeleteEvent(id);
        }

    }
}
