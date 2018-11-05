using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using XML.Data;

public class MapDataManager
{
	static private MapDataManager instance = null;

	public Dictionary<int, Cell> cellInfo = new Dictionary<int, Cell>();

	public int[][] map = null;
    public int width = 0;
    public int height = 0;

	public bool isCreated = false;

	static public MapDataManager GetInstance()
	{
		if (instance == null)
		{
			instance = new MapDataManager();
		}
		return instance;
	}

	private MapDataManager()
	{
	}

	//public Entity[,,] Entities = new Entity();

	public Entity FindGroundCell(Vector3 position)
	{
        //return new Vector3(0,1);
        //return Entities[(int)position.x, (int)position.y, (int)position.z];
        return new Entity();
	}
}
