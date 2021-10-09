using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class Outings
    {
        public string Name { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public double TotalCost { get; set; }
        public double TotalCostPerPerson { get; set; }
        public EventType TypeOfEvent { get; set; }

        public Outings() { }

        public Outings(string name, int numberOfPeople, DateTime date, double totalCost, double totalCostPerPerson, EventType typeOfEvent)
        {
            Name = name;
            NumberOfPeople = numberOfPeople;
            Date = date;
            TotalCost = totalCost;
            TotalCostPerPerson = totalCostPerPerson;
            TypeOfEvent = typeOfEvent;
        }

        
    }

    
}
