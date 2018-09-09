using System;
using Unity.Entities;

namespace slg
{
	public enum OBJType
	{
		Unite = 0,
		Cell,
		UI,

	};

	[Serializable]
	public struct ObjectType : IComponentData
	{
		public OBJType Value;
	}
	public class ObjectTypeComponent : ComponentDataWrapper<ObjectType> { }
}
