using System.Collections.Generic;
using Unity.Entities;
using XML.Paraser;
using XML.Data;
using UnityEngine;

public class MapCreateSystem : ComponentSystem
{
    struct Group {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<MapType> mapData;
    }

    [Inject] Group group;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            if (group.mapData[i].Type == 1) {
                var cells = XmlParaser<ItemCollection<XML.Data.Cell>>.Paraser(Application.dataPath + "/Config/cellAtt.xml");
                Dictionary<int, Cell> cellMap = new Dictionary<int, Cell>();
                foreach (var cell in cells.Items)
                {
                    cellMap.Add(cell.ID, cell);
                }

                var terrains = XmlParaser<ItemCollection<XML.Data.Terrain>>.Paraser(Application.dataPath + "/Config/DemoMap.xml");
                var cellNameIndex = 0;

                int x = 0;
                int y = 0;
                foreach (var terr in terrains.Items)
                {
                    MapDataManager.GetInstance().map[terr.X][terr.Y] = terr.CellID;
                    var cellinfo = cellMap[terr.CellID];
                    GameObject terr_go = GameObject.Instantiate(Resources.Load<GameObject>(cellinfo.Resourse));
                    terr_go.name = "mapcell";//+ cellNameIndex++;
                    terr_go.transform.position = new Vector3(terr.X, 0, terr.Y);
                    terr_go.transform.localScale.Set(1, 1, 1);
                }
                PostUpdateCommands.DestroyEntity(group.entity[i]);
            }
            break;
        }
    }
}
