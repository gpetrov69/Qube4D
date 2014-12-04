using UnityEngine;
using System;
using System.Collections;

namespace Qube4d.Framework.CustomTransition
{
	public class CustomTranslator : CustomMoverBase 
	{
		#region Public methods

		public CustomTranslator Create(Transform objectTransform, TransitionCoordinates transitionCoordinates)
		{
			base.Init(objectTransform, transitionCoordinates, TransitionContext.Translation);

			return this;
		}
		
		#endregion
	}
}
