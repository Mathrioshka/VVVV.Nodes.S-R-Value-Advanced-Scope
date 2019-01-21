namespace VVVV.Nodes.SR
{
	public class ValueDataHolder : DataHolder<ScopedValuepread>
	{
		private static ValueDataHolder FInstance;

		public static ValueDataHolder Instance
		{
			get { return FInstance ?? (FInstance = new ValueDataHolder()); }
		}
	}
}