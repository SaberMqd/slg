using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MoveRangeManager {

    static private MoveRangeManager instance;

    private List<Entity> range_cells = new List<Entity>();

    static public MoveRangeManager GetInstance()
    {
        if (instance == null)
        {
            instance = new MoveRangeManager();
        }
        return instance;
    }

    public void DestroyMoveRange() {
        var em = World.Active.GetOrCreateManager<EntityManager>();
        foreach (var go in range_cells) {
            em.DestroyEntity(go);
        }
        range_cells.Clear();
    }

    public struct Pos
    {
        public int x;
        public int y;
        public int lastMovement;
    };

    public struct RealPos {
        public int x;
        public int y;
    };

    public struct Node : BacktrackingAlg.Node
    {
        public float Cost()
        {
            var info_id = MapDataManager.GetInstance().map[x][y];
            var passCost = MapDataManager.GetInstance().cellInfo[info_id].PassEfficiency;
            if (passCost <= 0) {
                return 99;
            }
            return passCost;
        }

        public BacktrackingAlg.Node[] GetAllAdjacentNodes()
        {
            Node[] nodes = new Node[4];
            int count = 0;
            if (x + 1 <= MapDataManager.GetInstance().width-1) {
                nodes[count] = new Node { x = x + 1, y = y };
                count++;
            }
            if (x - 1 >= 0) {
                nodes[count] = new Node { x = x - 1, y = y };
                count++;
            }
            if (y + 1 <= MapDataManager.GetInstance().height-1)
            {
                nodes[count] = new Node { x = x, y = y + 1 };
                count++;
            }
            if (y - 1 >= 0)
            {
                nodes[count] = new Node {  x = x,y = y - 1 };
                count++;
            }
            if (0 == count) {
                return null;
            }
            BacktrackingAlg.Node[] ret = new BacktrackingAlg.Node[count];
            for (int i = 0; i < count; ++i) {
                ret[i] = nodes[i];
            }
            return ret;
        }

        public string ID()
        {
            return x+"_"+y;
        }

        public int x;
        public int y;
    };

    public void CreateMoveRange(int x, int y, int z, int passValue) {
        var area = BacktrackingAlg.GetAccessibleArea(new Node { x = x, y = y}, passValue);
        UnityEngine.Debug.Log("areas num is " + area.Count);
        foreach (var c in area) {
            var t = c.Key.Split('_');
            var prefab = Resources.Load<GameObject>("MoveCell");
            GameObject terr_go = GameObject.Instantiate(prefab);
            var e = terr_go.GetComponent<GameObjectEntity>();
            GameProcessManager.entity_manager.SetComponentData(e.Entity, new Position
            {
                Value = new float3(int.Parse(t[0]), 0, z = int.Parse(t[1]))
            });
        }
        return;
    }

    
    private MoveRangeManager() {
    }
}
