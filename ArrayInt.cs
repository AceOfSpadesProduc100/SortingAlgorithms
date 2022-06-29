using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace AlgoWPF
{
    public struct ArrayInt : IComparable, IComparable<ArrayInt>, IConvertible, IEquatable<ArrayInt>, IFormattable
    {
        private const int MIN_VALUE = int.MinValue;
        private const int MAX_VALUE = int.MaxValue;

        public static readonly ArrayInt MinValue = new(MIN_VALUE);
        public static readonly ArrayInt MaxValue = new(MAX_VALUE);
        private static bool IsValidValue(int value)
        {
            return value is >= MIN_VALUE and <= MAX_VALUE;
        }

        private int _value;
        public int Value
        {
            get
            {
                Sort.reads++;
                return _value == 0 ? MIN_VALUE : _value; // Treat the default, 0, as being the minimum value.
            }
            set
            {
                Sort.writes++;
                _value = value;
            }
        }

        public ArrayInt(int value)
        {
            if (!IsValidValue(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Value must be between {MIN_VALUE} and {MAX_VALUE}.");
            }

            _value = value;
        }

        #region IComparable
        public int CompareTo(object obj)
        {
            return obj is ArrayInt l
                ? Value.CompareTo(l)
                : throw new ArgumentException("Object must be of type " + nameof(ArrayInt), nameof(obj));
        }
        #endregion

        #region IComparable<LimitedInt>
        public int CompareTo(ArrayInt other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region IConvertible
        public TypeCode GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDateTime(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)Value).ToType(conversionType, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt64(provider);
        }
        #endregion

        #region IEquatable<LimitedInt>
        public bool Equals(ArrayInt other)
        {
            return this == other;
        }
        #endregion

        #region IFormattable
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.ToString(format, formatProvider);
        }
        #endregion

        #region operators
        public static bool operator ==(ArrayInt left, ArrayInt right)
        {
            Sort.comparisons++;
            return left.Value == right.Value;
        }

        public static bool operator !=(ArrayInt left, ArrayInt right)
        {
            Sort.comparisons++;
            return left.Value != right.Value;
        }

        public static bool operator <(ArrayInt left, ArrayInt right)
        {
            Sort.comparisons++;
            return left.Value < right.Value;
        }
        public static implicit operator ArrayInt[](ArrayInt vec)
        {
            throw new NotImplementedException();
        }

        public static bool operator >(ArrayInt left, ArrayInt right)
        {
            Sort.comparisons++;
            return left.Value > right.Value;
        }

        public static bool operator <=(ArrayInt left, ArrayInt right)
        {
            Sort.comparisons++;
            return left.Value <= right.Value;
        }

        public static bool operator >=(ArrayInt left, ArrayInt right)
        {
            Sort.comparisons++;
            return left.Value >= right.Value;
        }

        public static ArrayInt operator ++(ArrayInt left)
        {
            return (ArrayInt)(left.Value + 1);
        }

        public static ArrayInt operator --(ArrayInt left)
        {
            return (ArrayInt)(left.Value - 1);
        }

        public static ArrayInt operator +(ArrayInt left, ArrayInt right)
        {
            return (ArrayInt)(left.Value + right.Value);
        }

        public static ArrayInt operator -(ArrayInt left, ArrayInt right)
        {
            return (ArrayInt)(left.Value - right.Value);
        }

        public static ArrayInt operator *(ArrayInt left, ArrayInt right)
        {
            return (ArrayInt)(left.Value * right.Value);
        }

        public static ArrayInt operator /(ArrayInt left, ArrayInt right)
        {
            return (ArrayInt)(left.Value / right.Value);
        }

        public static ArrayInt operator %(ArrayInt left, ArrayInt right)
        {
            return (ArrayInt)(left.Value % right.Value);
        }

        public static ArrayInt operator &(ArrayInt left, ArrayInt right)
        {
            return (ArrayInt)(left.Value & right.Value);
        }

        public static ArrayInt operator |(ArrayInt left, ArrayInt right)
        {
            return (ArrayInt)(left.Value | right.Value);
        }

        public static ArrayInt operator ^(ArrayInt left, ArrayInt right)
        {
            return (ArrayInt)(left.Value ^ right.Value);
        }

        public static ArrayInt operator ~(ArrayInt left)
        {
            return (ArrayInt)~left.Value;
        }

        public static ArrayInt operator >>(ArrayInt left, int right)
        {
            return (ArrayInt)(left.Value >> right);
        }

        public static ArrayInt operator <<(ArrayInt left, int right)
        {
            return (ArrayInt)(left.Value << right);
        }

        public static implicit operator int(ArrayInt value)
        {
            return value.Value;
        }

        public static implicit operator ArrayInt(int value)
        {
            return !IsValidValue(value) ? throw new OverflowException() : new ArrayInt(value);
        }

        #endregion

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null)
        {
            return Value.TryFormat(destination, out charsWritten, format, provider);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is ArrayInt l && Equals(l);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        #region static methods
        public static bool TryParse(ReadOnlySpan<char> s, out int result)
        {
            return int.TryParse(s, out result);
        }

        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out int result)
        {
            return int.TryParse(s, style, provider, out result);
        }

        public static int Parse(string s, IFormatProvider provider)
        {
            return int.Parse(s, provider);
        }

        public static int Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            return int.Parse(s, style, provider);
        }

        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, ref int result)
        {
            return int.TryParse(s, style, provider, out result);
        }

        public static int Parse(string s)
        {
            return int.Parse(s);
        }

        public static int Parse(string s, NumberStyles style)
        {
            return int.Parse(s, style);
        }

        public static int Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider provider = null)
        {
            return int.Parse(s, style, provider);
        }

        public static bool TryParse(string s, ref int result)
        {
            return int.TryParse(s, out result);
        }
        #endregion
    }
}
