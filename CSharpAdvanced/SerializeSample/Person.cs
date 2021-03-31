using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeSample
{
    [Serializable()] //Attribute -> Serializable bedeutet, dass Klasse serialisierbar ist (binary, ..... )
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }

        [NonSerialized()] //Kontostand wird bei Serialisierung ausgelassen  Binär + JSON 
        public decimal Kontostand;
    }
}
