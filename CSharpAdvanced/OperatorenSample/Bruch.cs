using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorenSample
{
    public class Bruch
    {

        public int Zähler { get; set; } //Auto-Properties -> weil im hintergrund eine int variable angelegt wird
        public int Nenner { get; set; }

        public Bruch(int Zähler, int Nenner)
        {
            this.Zähler = Zähler;
            this.Nenner = Nenner;
        }

        public static bool operator == (Bruch left, Bruch right)
        {
            if (left.Nenner != left.Nenner)
                return false;

            if (left.Zähler != right.Zähler)
                return false;

            return true; 
        }


        public static bool operator != (Bruch left, Bruch right)
        {
            if (left.Nenner == left.Nenner)
                return false;

            if (left.Zähler == right.Zähler)
                return false;
            return true;
        }

        public static bool operator < (Bruch left, Bruch right)
        {
            return true;

        }

        public static bool operator > (Bruch left, Bruch right)
        {
            return true;
        }

        public static bool operator >= (Bruch left, Bruch right)
        {
            return true;
        }

        public static bool operator <=(Bruch left, Bruch right)
        {
            return true;
        }

        public static Bruch operator * (Bruch left, int right)
        {
            return new Bruch(left.Zähler * right, left.Nenner);
        }
        public static Bruch operator *(Bruch left, Bruch right)
        {
            return new Bruch(left.Zähler * right.Zähler, left.Nenner * right.Nenner);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();  
        }

    }
}
