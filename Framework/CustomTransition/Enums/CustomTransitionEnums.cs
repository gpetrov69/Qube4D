using System;
namespace Qube4d.Framework.CustomTransition
{
	public enum TransitionStage
	{
		Unknown = 0,
		Initial = 1,
		Transitioning = 2,
		Final = 3
		//TODO: how about Static, Transitioning and determine if is in a certain state by implementing extension method IsInState()
	}
	
	public enum TransitionContext
	{
		Unknown = 0,
		Rotation = 1,
		Translation = 2,
		Scaling = 3,
		Coloring = 4
	}
	
	public enum TouchPositiveDirection
	{
		UpOrRight = 0,
		UpOrLeft = 1,
		DownOrLeft = 2,
		DownOrRight = 3
	}

	public enum TransitionCoordinates
	{
		Unknown = 0,
		Global = 1,
		Local = 2
	}
}

