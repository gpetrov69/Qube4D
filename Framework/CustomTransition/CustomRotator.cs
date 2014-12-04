using UnityEngine;
using System;
using System.Collections;

namespace Qube4d.Framework.CustomTransition
{
	public class CustomRotator : CustomMoverBase
	{
		#region Public methods

		public CustomRotator Create(Transform objectTransform, TransitionCoordinates transitionCoordinates)
		{
			base.Init(objectTransform, transitionCoordinates, TransitionContext.Rotation);

			return this;
		}
		
		#endregion
	}
}

