﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GameObjectEntityManager {

    private static GameObjectEntityManager Instance = null;
    private Entity entity;
    private GameObject gameObject;

    private bool current = false;
    private GameObjectEntityManager() {

    }

    static public GameObjectEntityManager GetInstance() {
        if (Instance == null) {
            Instance = new GameObjectEntityManager();
        }
        return Instance;
    }

    private int id = 0;

    struct GE {
        public GameObject ge_gameObject;
        public Entity ge_entity;
    }

    private Dictionary<int, GE> geMaps = new Dictionary<int, GE>();

    public void SetAddGameObjectAndEntity(out int ID, GameObject gameObject, Entity entity) {
        ID = id++;
        geMaps.Add(ID, new GE { ge_gameObject = gameObject, ge_entity = entity, });
    }

    bool GetGE(int id, out GE ge) {
        if (geMaps.ContainsKey(id)) {
            ge = geMaps[id];
            return true;
        }
        ge = new GE {};
        return false;
    }

    public Entity GetCurrentEntity(out bool isExist) {
        isExist = current;
        return entity;
    }

    public GameObject GetCurrentGameObject(out bool isExist)
    {
        isExist = current;
        return gameObject;
    }

    public void SetCurrentEntity(Entity e) {
        entity = e;
        current = true;
    }

    public void SetCurrentGameObject(GameObject g) {
        gameObject = g;
        current = true;
    }

    public void SetCurrentExist(bool exist) {
        current = exist;
    }
}