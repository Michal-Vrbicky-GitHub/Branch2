using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhashenii
{
    public class Administrator : Uzivatel
    {
        public Administrator(string coTySi, string heslo, bool zakodovat) : base(coTySi, heslo, zakodovat){}
    }
}
