using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2
{
        public class ElectricityBill
        {
            private string _consumerNumber;
            private string _consumerName;
            private int _unitsConsumed;
            private double _billAmount;

            public string ConsumerNumber { get => _consumerNumber; set => _consumerNumber = value; }
            public string ConsumerName { get => _consumerName; set => _consumerName = value; }
            public int UnitsConsumed { get => _unitsConsumed; set => _unitsConsumed = value; }
            public double BillAmount { get => _billAmount; set => _billAmount = value; }
        }

}
