using UnityEngine;
using System;
using System.Collections;

namespace Qube4d.Framework
{
	public class DataEventArgs:EventArgs
	{
		private object _data;
		public object Data 
		{
			get{return _data;}
			set {_data = value;}
		}

		public DataEventArgs() {}
		public DataEventArgs(object data)
		{
			_data=data;
		}
	}
}
