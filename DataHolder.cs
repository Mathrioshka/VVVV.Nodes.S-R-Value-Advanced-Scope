using System.Collections.Generic;

namespace VVVV.Nodes.SR
{
	public delegate void HolderEventDelegate(string key);

	public abstract class DataHolder<T> where T : new()
	{
		private readonly Dictionary<string, T> FData = new Dictionary<string, T>();

		public void RemoveData(string key)
		{
			if (!FData.ContainsKey(key)) return;
			
			FData.Remove(key);
		}

		public void UpdateData(string key, T data)
		{
			if (!FData.ContainsKey(key))
			{
				FData.Add(key, data);
			}
			
			FData[key] = data;
		}

		public T GetData(string key, out bool found)
		{
			if (FData.ContainsKey(key))
			{
				found = true;
				return FData[key];
			}
			
			found = false;

			return new T();
		}

	}
}