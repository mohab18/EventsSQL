using Events.Models;
using Microsoft.EntityFrameworkCore;

namespace Events
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
       : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    
       public List<Event> RetrieveAllEvents()
        {
            return Events.ToList();
        }
        public Event RetrieveEvent(int id)
        {
            return Events.Find(id);
        }
        public void AddEvent(Event EventToBeAdded)
        {
            Events.Add(EventToBeAdded);
            SaveChanges();
        }
        public void UpdateEvent(Event EventToBeUpdated)
        {
            Event _event = Events.Find(EventToBeUpdated.Id);
            if(_event != null)
            {
                _event.Location=EventToBeUpdated.Location;
                _event.Date=EventToBeUpdated.Date;
                SaveChanges();
            }
        }
        public void DeleteEvent(int id)
        {
            Event _event = Events.Find(id);
            if (_event != null)
            {
                Events.Remove(_event);
                SaveChanges();
            }

        }
    }
}
