using DeskBooker.Core.Domain;
using System;
using System.Collections.Generic;

namespace DeskBooker.Core.Processor
{
    public interface IDeskRepository
    {
        public IEnumerable<Desk> GetAvailableDesks(DateTime date);

        public IEnumerable<Desk> GetAll();
    }
}