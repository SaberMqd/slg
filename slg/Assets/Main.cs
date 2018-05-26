using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using map.creater;

public class Main : MonoBehaviour {
    Systems sys;
	// Use this for initialization
	void Start () {

        Debug.Log("hello slg");

        sys = new MainSystem(Contexts.sharedInstance);

        //game
        GameEntity e = Contexts.sharedInstance.game.CreateEntity();
        e.AddPosition(Vector3.zero);

        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("ppp"));
        go.LinkEntity(e);

        //生成了20种地形
        //var oos;

        //XmlParaser xmlParaser = new XmlParaser(Application.dataPath);
        //var cells = xmlParaser.GetAllCrustalBlock();
        //foreach( var cell in cells.Items)
        //{
            //create cell entity
            //add component
        //}
            

    }

    // Update is called once per frame
    void Update () {
        sys.Execute();
        sys.Cleanup();        
	}
}
