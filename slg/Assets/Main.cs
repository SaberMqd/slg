using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using XML.Paraser;
using XML.Data;

public class Main : MonoBehaviour
{
    EntityManager entityManager;

    void Start()
    {
        // 获取EntityManager
        entityManager = World.Active.GetOrCreateManager<EntityManager>();

        // 定义实体的原型
        //var sampleArchetype = entityManager.CreateArchetype(typeof(CountData),typeof(CountData1));
        //entityManager.CreateEntity(sampleArchetype);

        var cells = XmlParaser<ItemCollection<XML.Data.Cell>>.Paraser(Application.dataPath + "/Config/cellAtt.xml");
        Dictionary<int, Cell> cellMap = new Dictionary<int, Cell>();
        foreach (var cell in cells.Items)
        {
            cellMap.Add(cell.ID, cell);
        }

        var terrains = XmlParaser<ItemCollection<XML.Data.Terrain>>.Paraser(Application.dataPath + "/Config/DemoMap.xml");
        foreach (var terr in terrains.Items)
        {
            var cellinfo = cellMap[terr.CellID];
            GameObject terr_go = GameObject.Instantiate(Resources.Load<GameObject>(cellinfo.Resourse));
            terr_go.transform.position = new Vector3(terr.X, terr.Y, 0);
            terr_go.transform.localScale.Set(1, 1, 1);
        }

    }

    private void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            Debug.Log("a");
            entityManager.CreateEntity(typeof(CountData));
            entityManager.CreateEntity(typeof(CountData1), typeof(CountData));
        }
    }
}