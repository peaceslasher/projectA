using System.Collections.Generic;

namespace SO
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<string> Tels { get; set; }

        public Client(int Id, string Name, string SurName)
        {
            this.Id = Id;
            this.Name = Name;
            this.SurName = SurName;
            Tels = new List<string>();
        }

        public Client(object[] o)
        {
            Id = (int)o[0];
            Name = (string)o[1];
            SurName = (string)o[2];
            Tels = new List<string>();
        }

        public static implicit operator Client(object[] o)
        { return new Client(o); }
    }
}