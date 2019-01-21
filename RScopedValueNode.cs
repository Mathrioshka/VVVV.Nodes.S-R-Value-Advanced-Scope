using System;
using System.ComponentModel.Composition;
using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.SR
{
	[PluginInfo(Name = "R", Category = "Value", Version = "Advanced Scope", Author = "alg", AutoEvaluate = true, Credits = "vux", Help = "Recieves value in parent module or globally")]
	public class RScopedValueNode : IPluginEvaluate
	{
		[Input("Receive String", IsSingle = true)] 
		private ISpread<string> FReceiveStringIn;

		[Output("Input Value")] 
		private ISpread<double> FOutput; 

		private readonly IPluginHost2 FHost;

		[ImportingConstructor]
		public RScopedValueNode(IPluginHost2 host, IHDEHost hdeHost)
		{
			FHost = host;
			hdeHost.MainLoop.OnRender += OnRender;
		}

		private void OnRender(object sender, EventArgs e)
		{
			var data = ValueDataHolder.Instance;
			string hostPath;
			FHost.GetHostPath(out hostPath);

			bool found;
			var value = data.GetData(FReceiveStringIn[0], out found);

			if (value.TargetScope == Scope.Module && value.Path != hostPath)
			{
				FOutput.SliceCount = 0;
				return;
			}

			FOutput.SliceCount = value.Values.SliceCount;
			FOutput.AssignFrom(value.Values);
		}

		public void Evaluate(int SpreadMax)
		{
			
		}
	}
}
