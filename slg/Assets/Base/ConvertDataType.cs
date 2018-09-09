using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace slg
{
	public static class ConvertDataType
	{
		public static List<T> NativeArrayToList<T>(NativeArray<T> na) where T : struct
		{
			List<T> list = new List<T>(na.ToArray());
			return list;
		}

		public static List<T> ComponentDataArrayToList<T>(ComponentDataArray<T> cda) where T : struct, IComponentData
		{
			NativeArray<T> na = cda.GetChunkArray(0, cda.Length);
			List<T> list = new List<T>(na.ToArray());
			return list;
		}

		public static NativeArray<T> ListToNativeArray<T>(List<T> list) where T : struct
		{
			NativeArray<T> na = new NativeArray<T>();
			na.CopyFrom(list.ToArray());
			return na;
		}

	}

}
