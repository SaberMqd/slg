using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;
using XML.Data;
using Unity.Collections;

namespace slg.map
{

    public class FileCreateMapSystem : ComponentSystem
    {

        struct Group
        {
            [ReadOnly]
            public SharedComponentDataArray<FileCreateMap> file;
            public EntityArray Entity;
            public int Length;
        }

        [Inject] Group group;

        protected override void OnUpdate()
        {
			while (group.Length != 0)
			{
				var sourceEntity = group.Entity[0];
				string mapPath = group.file[0].path;
				string cellAttPath = Application.dataPath + "/Config/cellAtt.xml";

				if (group.file[0].use_defalt_path == true)
				{
					mapPath = Application.dataPath + "/Config/DemoMap.xml";
				}

				var cells = XML.Paraser.XmlParaser<ItemCollection<XML.Data.Cell>>.Paraser(Application.dataPath + "/Config/cellAtt.xml");
				Dictionary<int, Cell> cellMap = new Dictionary<int, Cell>();
				foreach (var cell in cells.Items)
				{
					cellMap.Add(cell.ID, cell);
				}

				var terrains = XML.Paraser.XmlParaser<ItemCollection<XML.Data.Terrain>>.Paraser(Application.dataPath + "/Config/DemoMap.xml");

				foreach (var terr in terrains.Items)
				{
					MapDataManager.GetInstance().map[terr.X][terr.Y] = terr.CellID;
					var cellinfo = cellMap[terr.CellID];
					string resource_path = "Terrain_" + terr.CellID;
					var prefab = Resources.Load<GameObject>(resource_path);
					GameObject terr_go = GameObject.Instantiate(prefab);
					var e = terr_go.GetComponent<GameObjectEntity>();
					EntityManager.SetComponentData(e.Entity, new Position
					{
						Value = new float3(terr.X, 0, terr.Y)
					});
				}

				MapDataManager.GetInstance().isCreated = true;

				EntityManager.RemoveComponent<FileCreateMap>(sourceEntity);
				UpdateInjectedComponentGroups();
			}
        }
    }
}