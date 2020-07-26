using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FamilyThings.Enumerations
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }
        public string Symbol { get; private set; }

        protected Enumeration() { }
        protected Enumeration(int id, string name, string symbol)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
        public bool Matches(object other) => Id.Equals(other);
        // Other utility methods ...
    }
}
