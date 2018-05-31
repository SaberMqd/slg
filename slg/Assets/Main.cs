using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using xml.data;
using xml.paraser;

public class Main : MonoBehaviour {
    Systems sys;
	// Use this for initialization
	void Start () {

        Debug.Log("hello slg");

        sys = new MainSystem(Contexts.sharedInstance);

        //game
        GameEntity e = Contexts.sharedInstance.game.CreateEntity();
        e.AddPosition(Vector3.zero);

        //GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("ppp"));
        //go.LinkEntity(e);

        //GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("terrain_"+1001));
        //go.LinkEntity(e);

        //生成了20种地形
        //var oos;

        var cells = XmlParaser<ItemCollection<xml.data.Cell>>.Paraser(Application.dataPath + "/cellAtt.xml");
        Dictionary<int, Cell> cellMap = new Dictionary<int, Cell>();
        foreach (var cell in cells.Items)
        {
			UnityEngine.Debug.Log(cell.ID + " " + cell.Name);
            cellMap.Add(cell.ID, cell);
        }

        var terrains = XmlParaser<ItemCollection<xml.data.Terrain>>.Paraser(Application.dataPath + "/DemoMap.xml");
        foreach (var terr in terrains.Items)
        {
            var cellinfo = cellMap[terr.CellID];
            //GameObject terr_go = GameObject.Instantiate(Resources.Load<GameObject>(cellinfo.Resourse));
            GameObject terr_go = GameObject.Instantiate(Resources.Load<GameObject>("ppp"));
            terr_go.transform.position.Set(terr.X, terr.Y, 0);
            terr_go.transform.localScale.Set(1000, 1000, 1);
        }
        
    }

    // Update is called once per frame
    void Update () {
        sys.Execute();
        sys.Cleanup();        
	}
}
