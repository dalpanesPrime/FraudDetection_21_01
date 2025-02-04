﻿using System.Numerics;

namespace FraudDetection_21_01.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public BigInteger CreditCard { get; set; }
    }
}
