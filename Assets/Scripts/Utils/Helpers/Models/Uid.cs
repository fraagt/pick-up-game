using System;

namespace Utils.Helpers.Models
{
	[Serializable]
	public struct Uid : IEquatable<Uid>
	{
		private readonly uint _value;

		private Uid(uint value)
		{
			_value = value;
		}

		public bool Equals(Uid other) => _value == other._value;

		public override bool Equals(object obj) => obj is Uid && Equals((Uid) obj);

		public override int GetHashCode() => _value.GetHashCode();

		public static explicit operator Uid(uint value) => new Uid(value);

		public static explicit operator uint(Uid uid) => uid._value;

		public static bool operator ==(Uid a, Uid b) => a._value == b._value;

		public static bool operator !=(Uid a, Uid b) => a._value != b._value;

		public override string ToString() => $"Uid #{_value}";
	}
}
