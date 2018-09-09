using slg.character.attribute;
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace slg.Round
{
	public enum RoundStep
	{
		BeforeAction = 0,
		Action,
		AfterAction,
	}

	[Serializable]
	public struct CampArray : ISharedComponentData
	{
		public NativeArray<Camp> Value;
	}
	public class CampListComponent : SharedComponentDataWrapper<CampArray> { }

	[Serializable]
	public struct CurrentPhase : IComponentData
	{
		public Camp value;
	}
	public class CurrentPhaseComponent : ComponentDataWrapper<CurrentPhase> { }

	[Serializable]
	public struct Step : IComponentData
	{
		public RoundStep value;
	}
	public class StepComponent : ComponentDataWrapper<Step> { }
}


