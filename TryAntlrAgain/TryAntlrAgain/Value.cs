using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryAntlrAgain
{
    public class Value
    {
        public static Value VOID = new Value(new object());

        readonly object value;

        public Value(object value)
        {
            this.value = value;
        }

        public bool asBoolean()
        {
            bool result;

            if (bool.TryParse(value.ToString(), out result))
            {
                return (bool) value;
            }
            else
            {
                throw new Exception("Parse in Value.cs from obj to BOOL failed " + value.ToString());
            }
        }

        public double asDouble()
        {
            double result;

            if (double.TryParse(value.ToString(), out result))
            {
                return double.Parse(value.ToString());
            }
            else
            {
                throw new Exception("Parse in Value.cs from obj to DOUBLE failed " + value.ToString());
            }
        }
     
        public string asString()
        {
            return value.ToString();
        }

        public bool isDouble()
        {
            if (value is double) { return true; }
            else { return false; }
        }

        public override int GetHashCode()
        {
            if (value == null)
            {
                return 0;
            }

            return this.value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Value that = (Value)obj;
            if (value == obj)
            {
                return true;
            }

            if (value == null || obj == null || obj.GetType() != value.GetType())
            {
                return value.Equals(that.value);
            }

            return false;

        }
           
        public override string ToString()
        {
            return value.ToString();
        }
    }
}
