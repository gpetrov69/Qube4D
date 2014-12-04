using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Qube4d.Framework.Extensions
{
	public static class Extensions
	{
		#region Public methods

		public static bool HasCollider(this GameObject obj)
		{
			return obj.collider!=null;
		}

		public static bool ApproxEquals(this float currentValue, float targetValue, float margin)
		{
			return (Mathf.Abs(currentValue - targetValue)) <= Mathf.Abs(margin);
		}

		public static bool ApproxEquals(this float currentValue, float targetValue, float margin, bool isRadians)
		{
			if(isRadians)
			{
				//convert to degrees
				currentValue = currentValue * Mathf.Rad2Deg;
				targetValue = targetValue * Mathf.Rad2Deg;
				margin = margin * Mathf.Rad2Deg;
			}

			//normalize angle values to 0 - 360
			float normCurrentAngle = Mathf.Abs(currentValue) > 360 ? currentValue - (currentValue%360)*360:currentValue;
			float normTargetAngle = Mathf.Abs(targetValue) > 360 ? targetValue - (targetValue%360)*360:targetValue;
				
			//positive 0 - 360
			float posNormCurrentValue = normCurrentAngle < 0 ? 360 + normCurrentAngle: normCurrentAngle;
			float posNormTargetValue = normTargetAngle < 0 ? 360 + normTargetAngle: normTargetAngle;
			
			//negative 0 - 360
			float negNormCurrentValue = normCurrentAngle > 0 ? normCurrentAngle - 360: normCurrentAngle;
			float negNormTargetValue = normTargetAngle > 0 ? normTargetAngle - 360: normTargetAngle;
				
			return (Mathf.Abs(posNormCurrentValue - posNormTargetValue)) <= Mathf.Abs(margin)
				|| (Mathf.Abs(negNormCurrentValue - negNormTargetValue)) <= Mathf.Abs(margin);

		}

		public static IEnumerable<Transform> Descendants(this Transform parent)
		{
			foreach(Transform child in parent)
			{
				yield return child;
				foreach(Transform subchild in child.Descendants())
				{
					yield return subchild;
				}
			}
		}

		#endregion
	}
}
