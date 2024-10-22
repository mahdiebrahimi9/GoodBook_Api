using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Common.Domain
{
    public class AggregateRoot : BaseEntity
    {
        //Back Field
        private readonly List<BaseDomainEvent> _domainEvent = new List<BaseDomainEvent>();

        [NotMapped]
        public List<BaseDomainEvent> DomainEvent => _domainEvent;

        public void AddDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvent.Add(eventItem);
        }

        public void RemoveDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvent?.Remove(eventItem);
        }
    }
}
