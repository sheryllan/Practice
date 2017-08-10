using System;

namespace GetValuesFromColumn
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
            bool boolResult;
            int intResult;

            if (int.TryParse(value.ToString(), out intResult))
            {
                if (intResult == 0) { return false; } //IFISERROR(0)
                if (intResult == 1) { return true; } //IFISERROR(1)
            }            
            else if (bool.TryParse(value.ToString(), out boolResult))
            {
                return (bool)value;
            }

            throw new Exception("Parse in Value.cs from obj to BOOL failed " + value.ToString());

        }
        public double asDouble()
        {
            double result;

            if (double.TryParse(value.ToString(), out result))
            {
                return result;
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