using SO;
using System.Collections.Generic;

namespace PL
{
    public abstract class CardP
    {
        public static IEnumerable<Deb> ListDeb()
        {
            foreach (Deb c in Cnn.ExecCmd("list_deb_cards"))
                yield return c;
        }

        public static IEnumerable<Cred> ListCred()
        {
            foreach (Cred c in Cnn.ExecCmd("list_cred_cards"))
                yield return c;
        }
    }
}