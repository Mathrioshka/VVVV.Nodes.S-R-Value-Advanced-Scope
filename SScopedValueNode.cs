using System;
using System.ComponentModel.Composition;
using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.SR
{
	[PluginInfo(Name = "S", Category="Value", Version = "Advanced Scope", Author = "alg", AutoEvaluate = true, Credits = "vux", Help = "Sends value in parent module or globally")]
	public class SScopedValueNode : IPluginEvaluate, IDisposable
	{
		[Input("Input Value", DefaultValue = 0)] 
		private ISpread<double> FValueIn;

		[Input("Send String", DefaultString = "devnull", IsSingle = true)] 
		private ISpread<string> FSendStringIn;

		[Input("Visibility", DefaultEnumEntry = "Module", IsSingle = true)]
		private ISpread<Scope> FScopeIn;

		private readonly IPluginHost2 FHost;

		[ImportingConstructor]
		public SScopedValueNode(IPluginHost2 host, IHDEHost hdeHost)
		{
			FHost = host;
			hdeHost.MainLoop.OnPrepareGraph += OnPrepareGraph;
		}

		private void OnPrepareGraph(object sender, EventArgs e)
		{
			var data = ValueDataHolder.Instance;
			string hostPath;
			FHost.GetHostPath(out hostPath);

			var value = new ScopedValuepread { TargetScope = FScopeIn[0], Values = FValueIn, Path = hostPath };
			data.UpdateData(FSendStringIn[0], value);
		}

		public void Dispose()
		{
			var data = ValueDataHolder.Instance;
			data.RemoveData(FSendStringIn[0]);
		}

		public void Evaluate(int SpreadMax)
		{
			
		}
	}
}
