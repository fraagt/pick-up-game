using System;
using Utils.Helpers.Models;

namespace Utils.Helpers
{
	public class UidGenerator
	{
		private uint _current = UInt32.MinValue;

		public Uid Next() => (Uid) _current++;
	}
}
