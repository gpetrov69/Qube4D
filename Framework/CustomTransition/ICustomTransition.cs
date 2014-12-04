using UnityEngine;
using System.Collections;

namespace Qube4d.Framework.CustomTransition
{
	public interface ICustomTransition
	{
	#region Methods

	IEnumerator ToggleTransition(bool isTowardsFinalState);

	#endregion
	}
}