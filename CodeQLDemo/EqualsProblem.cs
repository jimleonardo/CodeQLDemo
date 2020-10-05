using System;

namespace CodeQLDemo
{
    public class EqualsProblem :IEquatable<String>
    {
        protected bool Equals(EqualsProblem other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(string other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EqualsProblem) obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
