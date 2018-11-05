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

    struct Pos
    {
        public int x;
        public int y;
        public int lastMovement;
    };

    struct RealPos {
        public int x;
        public int y;
    };

    struct Node : BacktrackingAlg.Node
    {
        public float Cost()
        {
            var info_id = MapDataManager.GetInstance().map[x][y];
            return MapDataManager.GetInstance().cellInfo[info_id].PassEfficiency;
        }

        public BacktrackingAlg.Node[] GetAllAdjacentNodes()
        {
            Node[] nodes = new Node[4];
            int count = 0;
            if (x + 1 <= MapDataManager.GetInstance().width) {
                nodes[count] = new Node { x = x + 1, y = y };
                count++;
            }
            if (x - 1 >= 0) {
                nodes[count] = new Node { x = x - 1, y = y };
                count++;
            }
            if (y + 1 <= MapDataManager.GetInstance().height)
            {
                nodes[count] = new Node { x = x, y = y + 1 };
                count++;
            }
            if (y - 1 >= 0)
            {
                nodes[count] = new Node {  x = x,y = y - 1 };
                count++;
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
        foreach (var c in area) {
            var go = GameObject.Instantiate(Resources.Load<GameObject>("MoveCell"));
            var t = c.Key.Split('_');
            go.transform.position = new Vector3 { x = int.Parse(t[0]), y = int.Parse(t[1]), z = 0.5f};
        }
        return;
    }

    
    private MoveRangeManager() {
    }
}
