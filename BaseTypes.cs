using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.SR
{
	public enum Scope
	{
		Module,
		WholePatch
	}

	public struct ScopedValuepread
	{
		public ISpread<double> Values;
		public string Path;
		public Scope TargetScope;
	}
}
