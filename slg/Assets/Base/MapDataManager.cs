using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataManager {

    static private MapDataManager instance;

    static public MapDataManager GetInstance() {
        if (instance == null) {
            instance = new MapDataManager();
        }
        return instance;
    }
    
    private MapDataManager() { }
}
