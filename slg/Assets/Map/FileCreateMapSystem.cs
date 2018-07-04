using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;
using XML.Data;

namespace slg.map
{

    public class FileCreateMapSystem : ComponentSystem
    {
        ComponentGroup group;
        EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

        protected override void OnCreateManager(int capacity)
        {
            group = GetComponentGroup(typeof(FileCreateMap));
        }

        protected override void OnUpdate()
        {
            var entityArray = group.GetEntityArray();
            var sharedComponentArray = group.GetSharedComponentDataArray<FileCreateMap>();

            for (int i = 0; i < entityArray.Length; i++)
            {
                UnityEngine.Debug.Log(" i: " + i);
                if (MapDataManager.GetInstance().isCreated) {
                    return;
                }
                string mapPath = sharedComponentArray[i].path;
                string cellAttPath = Application.dataPath + "/Config/cellAtt.xml";

                if (sharedComponentArray[i].use_defalt_path == true) {
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
                    em.SetComponentData(e.Entity, new Position
                    {
                        Value = new float3(terr.X, 0, terr.Y)
                    });

                }

                MapDataManager.GetInstance().isCreated = true;
                //em.RemoveComponent(entityArray[i], typeof(FileCreateMap));
                //PostUpdateCommands.DestroyEntity(entityArray[i]);
                //group.ResetFilter();
                //group.Dispose();
                UnityEngine.Debug.Log(" delete over i: " + i);

            }

        }
    }
}