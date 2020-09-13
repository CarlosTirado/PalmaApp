using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Domain.Base
{
    [Serializable]
    [DebuggerDisplay("{Id} - {Name}")]
    public abstract class Enumeration<TEnumeration> : Enumeration<TEnumeration, int>
    where TEnumeration : Enumeration<TEnumeration>
    {
        protected Enumeration(int id, string name)
            : base(id, name)
        {
        }

        public static TEnumeration FromInt32(int id)
        {
            return FromId(id);
        }

        public static bool TryFromInt32(int listItemId, out TEnumeration result)
        {
            return TryParse(listItemId, out result);
        }
    }

    [Serializable]
    [DebuggerDisplay("{DisplayName} - {Value}")]
    public abstract class Enumeration<TEnumeration, TId> : IComparable<TEnumeration>, IEquatable<TEnumeration>
        where TEnumeration : Enumeration<TEnumeration, TId>
        where TId : IComparable
    {
        readonly string _name;
        readonly TId _id;

        private static Lazy<TEnumeration[]> _enumerations = new Lazy<TEnumeration[]>(GetEnumerations);

        protected Enumeration(TId id, string name)
        {
            _id = id;
            _name = name;
        }

        public TId Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int CompareTo(TEnumeration other)
        {
            return Id.CompareTo(other.Id);
        }

        public override sealed string ToString()
        {
            return Name;
        }

        public static TEnumeration[] GetAll()
        {
            return _enumerations.Value;
        }

        private static TEnumeration[] GetEnumerations()
        {
            Type enumerationType = typeof(TEnumeration);
            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<TEnumeration>()
                .ToArray();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TEnumeration);
        }

        public bool Equals(TEnumeration other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Enumeration<TEnumeration, TId> left, Enumeration<TEnumeration, TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enumeration<TEnumeration, TId> left, Enumeration<TEnumeration, TId> right)
        {
            return !Equals(left, right);
        }

        public static TEnumeration FromId(TId id)
        {
            return Parse(id, "value", item => item.Id.Equals(id));
        }

        public static TEnumeration Parse(string name)
        {
            return Parse(name, "display name", item => item.Name == name);
        }

        static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration result)
        {
            result = GetAll().FirstOrDefault(predicate);
            return result != null;
        }

        private static TEnumeration Parse(object id, string description, Func<TEnumeration, bool> predicate)
        {
            TEnumeration result;

            if (!TryParse(predicate, out result))
            {
                string message = string.Format("'{0}' is not a valid {1} in {2}", id, description, typeof(TEnumeration));
                throw new ArgumentException(message, "value");
            }

            return result;
        }

        public static bool TryParse(TId value, out TEnumeration result)
        {
            return TryParse(e => e.Id.Equals(value), out result);
        }

        public static bool TryParse(string name, out TEnumeration result)
        {
            return TryParse(e => e.Name == name, out result);
        }
    }
}
