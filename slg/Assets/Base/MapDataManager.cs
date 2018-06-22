using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataManager {

    static private MapDataManager instance = null;

    public struct CellInfo {
        public int move_buf;
    };
    public Dictionary<int, CellInfo> cellInfo = new Dictionary<int, CellInfo>();

    public int[][] map = null;

    static public MapDataManager GetInstance() {
        if (instance == null) {
            instance = new MapDataManager();
        }
        return instance;
    }
    
    private MapDataManager() {
        map = new int[50][];
        for (int i = 0; i < 50; ++i) {
            map[i] = new int[50];
        }

        cellInfo[1001] = new CellInfo { move_buf = 1 };
        cellInfo[1002] = new CellInfo { move_buf = 1 };
        cellInfo[1003] = new CellInfo { move_buf = 2 };
        cellInfo[1004] = new CellInfo { move_buf = 9999 };
        cellInfo[1005] = new CellInfo { move_buf = 1 };
        cellInfo[1006] = new CellInfo { move_buf = 2 };
        cellInfo[1007] = new CellInfo { move_buf = 9999 };
        cellInfo[1008] = new CellInfo { move_buf = 1 };
        cellInfo[1009] = new CellInfo { move_buf = 1 };

        cellInfo[1010] = new CellInfo { move_buf = 1 };
        cellInfo[1011] = new CellInfo { move_buf = 1 };
        cellInfo[1012] = new CellInfo { move_buf = 9999 };
        cellInfo[1013] = new CellInfo { move_buf = 1 };
        cellInfo[1014] = new CellInfo { move_buf = 9999 };
        cellInfo[1015] = new CellInfo { move_buf = 1 };
        cellInfo[1016] = new CellInfo { move_buf = 3 };
        cellInfo[1017] = new CellInfo { move_buf = 9999 };
        cellInfo[1018] = new CellInfo { move_buf = 1 };

    }

}
