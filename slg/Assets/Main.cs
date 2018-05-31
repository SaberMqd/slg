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
            cellMap.Add(cell.ID, cell);
        }

		int xscale = 1000;
		int yscale = 1000;

		var terrains = XmlParaser<ItemCollection<xml.data.Terrain>>.Paraser(Application.dataPath + "/DemoMap.xml");
        foreach (var terr in terrains.Items)
        {
            var cellinfo = cellMap[terr.CellID];
            GameObject terr_go = GameObject.Instantiate(Resources.Load<GameObject>(cellinfo.Resourse));
			terr_go.transform.position = new Vector3(terr.X, 0, terr.Y);	
			terr_go.transform.localScale.Set(1, 1, 1);
		}

	}

    // Update is called once per frame
    void Update () {
        sys.Execute();
        sys.Cleanup();        
	}
}
