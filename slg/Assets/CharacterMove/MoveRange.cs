using UnityEngine;

public class MoveRange {

    public int x;
    public int y;
    public int z;
    public int distance;

    public GameObject[] gameObjects;

    void CreateMoveRange() {
        gameObjects = new GameObject[distance*distance];

        for (int i = 0; i < distance * distance; ++i) {
            gameObjects[i] = GameObject.Instantiate(Resources.Load<GameObject>("move_cell"));
        }

    }

}
