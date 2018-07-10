using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        GameObject.Instantiate(Resources.Load<GameObject>("MoveCell"));
    }

    private void Update()
    {
       
    }

}