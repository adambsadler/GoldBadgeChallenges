using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Repository
{
    public enum TypeOfEvent
    {
        Bowling = 1,
        Cookout,
        Softball,
        Golf
    }
    public class Outing
    {
        public TypeOfEvent EventType { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }

        public Outing() { }

        public Outing(TypeOfEvent eventType, int numberOfPeople, DateTime dateOfEvent, decimal costPerPerson, decimal totalCost)
        {
            EventType = eventType;
            NumberOfPeople = numberOfPeople;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            TotalCost = totalCost;
        }
    }
}
