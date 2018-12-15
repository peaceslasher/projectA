using System;

namespace SO
{
    public abstract class Card
    {
        public int Id { get; set; }
        public int ClId { get; set; }
        public DateTime ExpDate { get; set; }
        public bool Cust { get; set; }
        public decimal Money { get; set; }

        public Card(int id, int clId, DateTime expDate, bool cust, decimal money)
        {
            Id = id;
            ClId = clId;
            ExpDate = expDate;
            Cust = cust;
            Money = money;
        }
    }
}