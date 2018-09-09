using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct RoundCount : IComponentData
{
	public int value;
}
public class RoundCountComponent : ComponentDataWrapper<RoundCount> { }
