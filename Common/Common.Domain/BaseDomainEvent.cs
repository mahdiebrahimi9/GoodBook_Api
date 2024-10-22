using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class BaseDomainEvent : INotification
    {
        public BaseDomainEvent()
        {

            CreationDate = DateTime.Now;
        }
        public DateTime CreationDate { get; protected set; }

    }
}
