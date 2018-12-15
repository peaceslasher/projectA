using System;

namespace SO
{
    public sealed class Deb : Card
    {
        public Deb(int id, int clId, DateTime expDate, bool cust, decimal money)
            : base(id, clId, expDate, cust, money) { }

        public Deb(object[] o)
            : base((int)o[0], (int)o[1], (DateTime)o[2], (bool)o[3], (decimal)o[4]) { }

        public static implicit operator Deb(object[] o)
        { return new Deb(o); }
    }
}