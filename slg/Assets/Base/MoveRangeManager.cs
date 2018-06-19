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

    public void CreateMoveRange(int x, int y, int z, int passValue) {
        GameObject move_cell = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
        move_cell.transform.position = new Vector3(x, y + 0.1f, z + 1);
        move_cell.name = "range_cell";
        range_cells.Add(move_cell);
        GameObject move_cell1 = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
        move_cell1.transform.position = new Vector3(x, y + 0.1f, z - 1);
        move_cell1.name = "range_cell";
        range_cells.Add(move_cell1);

        GameObject move_cell2 = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
        move_cell2.transform.position = new Vector3(x - 1, y + 0.1f, z);
        move_cell2.name = "range_cell";
        range_cells.Add(move_cell2);

        GameObject move_cell3 = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
        move_cell3.transform.position = new Vector3(x + 1, y + 0.1f, z);
        move_cell3.name = "range_cell";
        range_cells.Add(move_cell3);

    }

    private MoveRangeManager() {
    }
}
