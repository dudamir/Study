namespace Structures
{
    public class DictionaryItem
    {
        protected bool Equals(DictionaryItem other)
        {
            return _key == other._key && Equals(_value, other._value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_key*397) ^ (_value != null ? _value.GetHashCode() : 0);
            }
        }

        private readonly int _key;
        private readonly object _value;

        internal DictionaryItem(int key, object value)
        {
            _key = key;
            _value = value;
        }

        public int Key
        {
            get { return _key; }
        }

        public object Value
        {
            get { return _value; }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Key == ((DictionaryItem)obj).Key;
        }
    }
}