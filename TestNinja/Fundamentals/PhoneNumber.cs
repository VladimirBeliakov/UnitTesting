using System;

namespace TestNinja.Fundamentals
{
    public class PhoneNumber
    {
        public string Area { get; }
        public string Major { get; }
        public string Minor { get; }

        public PhoneNumber(string area, string major, string minor)
        {
            Area = area;
            Major = major;
            Minor = minor;
        }

        public static PhoneNumber Parse(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number cannot be blank.");

            if (number.Length != 10)
                throw new ArgumentException("Phone number should be 10 digits long.");

            var area = number.Substring(0, 3);
            var major = number.Substring(3, 3);
            var minor = number.Substring(6);

            return new PhoneNumber(area, major, minor);
        }

        public override string ToString()
        {
            return String.Format($"({Area}){Major}-{Minor}");
        }

        protected bool Equals(PhoneNumber other)
        {
            return string.Equals(Area, other.Area) &&
                   string.Equals(Major, other.Major) &&
                   string.Equals(Minor, other.Minor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PhoneNumber)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Area.GetHashCode() ^ Major.GetHashCode() ^ Minor.GetHashCode();
            }
        }
    }
}