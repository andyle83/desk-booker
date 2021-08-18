using DeskBooker.Core.Domain;
using System;
using System.Collections.Generic;

namespace DeskBooker.Core.Processor
{
    public interface IDeskRepository
    {
        public List<Desk> GetAvailableDesk(DateTime date);
    }
}