using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeManager {

    static private AttackRangeManager instance;

    private List<GameObject> range_cells = new List<GameObject>();

    static public AttackRangeManager GetInstance()
    {
        if (instance == null)
        {
            instance = new AttackRangeManager();
        }
        return instance;
    }

    public void DestroyAttackRange()
    {
        foreach (var go in range_cells)
        {
            GameObject.Destroy(go);
        }
        range_cells.Clear();
    }

    public void CreateAttackRange(int x, int y, int z, int passValue)
    {
        GameObject move_cell = GameObject.Instantiate(Resources.Load<GameObject>("attack_cell"));
        move_cell.transform.position = new Vector3(x, y + 0.1f, z + 1);
        move_cell.name = "attack_cell";
        range_cells.Add(move_cell);
        GameObject move_cell1 = GameObject.Instantiate(Resources.Load<GameObject>("attack_cell"));
        move_cell1.transform.position = new Vector3(x, y + 0.1f, z - 1);
        move_cell1.name = "attack_cell";
        range_cells.Add(move_cell1);

        GameObject move_cell2 = GameObject.Instantiate(Resources.Load<GameObject>("attack_cell"));
        move_cell2.transform.position = new Vector3(x - 1, y + 0.1f, z);
        move_cell2.name = "attack_cell";
        range_cells.Add(move_cell2);

        GameObject move_cell3 = GameObject.Instantiate(Resources.Load<GameObject>("attack_cell"));
        move_cell3.transform.position = new Vector3(x + 1, y + 0.1f, z);
        move_cell3.name = "attack_cell";
        range_cells.Add(move_cell3);

    }

    private AttackRangeManager()
    {
    }

}
