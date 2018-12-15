using System;

namespace SO
{
    public sealed class Cred : Card
    {
        public string Cat { get; set; }

        public Cred(int id, int clId, DateTime expDate, bool cust, decimal money, string cat)
            : base(id, clId, expDate, cust, money)
        { Cat = cat; }

        public Cred(object[] o)
            : base((int)o[0], (int)o[1], (DateTime)o[2], (bool)o[3], (decimal)o[4])
        { Cat = (string)o[5]; }

        public static implicit operator Cred(object[] o)
        { return new Cred(o); }
    }
}