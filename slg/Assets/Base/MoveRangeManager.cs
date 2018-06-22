using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRangeManager {

    static private MoveRangeManager instance;

    private List<GameObject> range_cells = new List<GameObject>();

    static public MoveRangeManager GetInstance()
    {
        if (instance == null)
        {
            instance = new MoveRangeManager();
        }
        return instance;
    }

    public void DestroyMoveRange() {
        foreach (var go in range_cells) {
            GameObject.Destroy(go);
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

    public void CreateMoveRange(int x, int y, int z, int passValue) {

        Stack<Pos> tmpFindStack = new Stack<Pos>();
        HashSet<RealPos> tmpFindResult = new HashSet<RealPos>();

        tmpFindStack.Push(new Pos { x = x, y = z, lastMovement = passValue });

        var count = 0;
        while (tmpFindStack.Count != 0) {
            var node = tmpFindStack.Pop();
            if (node.lastMovement >= 0) {
                tmpFindResult.Add(new RealPos { x = node.x, y = node.y });
            }
            //下面的节点
            {
                var x1 = node.x;
                var y1 = node.y - 1;
                var m1 = node.lastMovement;
                Debug.Log(x1 + " "+ y1 + " " + m1);
                if (x1 > 0 && y1 > 0)
                {
                    var id = MapDataManager.GetInstance().map[x1][y1];
                    Debug.Log(" MapDataManager.GetInstance().map[x1][y1]" + id);

                    m1 -= MapDataManager.GetInstance().cellInfo[id].move_buf;
                    Debug.Log(" MapDataManager.GetInstance().cellInfo[id].move_buf " + MapDataManager.GetInstance().cellInfo[id].move_buf);

                    if (m1 >= 0)
                    {
                        tmpFindStack.Push(new Pos { x = x1, y = y1, lastMovement = m1 });
                    }
                }
            }
            //上节点
            {
                var x1 = node.x;
                var y1 = node.y + 1;
                var m1 = node.lastMovement;
                if (x1 > 0 && y1 > 0)
                {
                    var id = MapDataManager.GetInstance().map[x1][y1];
                    m1 -= MapDataManager.GetInstance().cellInfo[id].move_buf;
                    if (m1 >= 0)
                    {
                        tmpFindStack.Push(new Pos { x = x1, y = y1, lastMovement = m1 });
                    }
                }
            }
            //左节点
            {
                var x1 = node.x-1;
                var y1 = node.y;
                var m1 = node.lastMovement;
                if (x1 > 0 && y1 > 0)
                {
                    var id = MapDataManager.GetInstance().map[x1][y1];
                    m1 -= MapDataManager.GetInstance().cellInfo[id].move_buf;
                    if (m1 >= 0)
                    {
                        tmpFindStack.Push(new Pos { x = x1, y = y1, lastMovement = m1 });
                    }
                }
            }
            //右节点
            {
                var x1 = node.x+1;
                var y1 = node.y;
                var m1 = node.lastMovement;
                if (x1 > 0 && y1 > 0)
                {
                    var id = MapDataManager.GetInstance().map[x1][y1];
                    m1 -= MapDataManager.GetInstance().cellInfo[id].move_buf;
                    if (m1 >= 0)
                    {
                        tmpFindStack.Push(new Pos { x = x1, y = y1, lastMovement = m1 });
                    }
                }
            }
        }
        Debug.Log("tmpFindResult.size " + tmpFindResult.Count);
        foreach (var node in tmpFindResult) {
            if (node.x == x && node.y == z) {
                continue;
            }
            GameObject move_cell = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
            move_cell.transform.position = new Vector3(node.x, (float)y+0.1f, node.y);
            move_cell.name = "range_cell";
            range_cells.Add(move_cell);
        }
    }

    
    private MoveRangeManager() {
    }
}
