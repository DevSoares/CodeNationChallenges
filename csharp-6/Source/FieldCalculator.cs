using System;
using System.Reflection;
using System.Linq;

namespace Codenation.Challenge
{
    public class FieldCalculator : ICalculateField
    {
        public decimal Addition(object obj)
        {
            decimal result = 0;

            foreach (var f in GetFields<AddAttribute>(obj))
            {
                result += (decimal)f.GetValue(obj);
            }
            return result;
        }

        public decimal Subtraction(object obj)
        {
            decimal result = 0;

            foreach (var f in GetFields<SubtractAttribute>(obj))
            {
                result -= (decimal)f.GetValue(obj);
            }
            return result;
        }

        public decimal Total(object obj)
        {
            decimal result = 0;

            result += Addition(obj);
            result += Subtraction(obj);
            return result;
        }

        private FieldInfo[] GetFields<T>(object obj)
        {
            var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            fields = fields.Where(a => a.GetCustomAttribute(typeof(T)) != null).ToArray();
            return fields;
        }
    }
}
