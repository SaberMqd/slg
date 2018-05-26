using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EntityLink : MonoBehaviour {

    public GameEntity entity;
}

public static class EntityLinkExtension
{
    public static bool HasEntity(this GameObject gameObject)
    {
        return gameObject != null && gameObject.GetComponent<EntityLink>() != null;
    }

    public static GameEntity GetEntity(this GameObject gameObject)
    {
        return gameObject.GetComponent<EntityLink>().entity;
    }

    public static void LinkEntity(this GameObject gameObject, GameEntity entity)
    {
		if (gameObject == null) {
			Debug.LogError ("GameObject NULL:" + gameObject.name);
		}
		if (gameObject.name.Contains ("TankScene")) {
			Debug.Log ("Use Scene:" + gameObject.name);
		}
		if (gameObject.GetComponent<EntityLink> () == null) {
			Debug.LogError ("EntityLink NULL:" + gameObject.name);
		}
        gameObject.GetComponent<EntityLink>().entity = entity;
        entity.AddGameObject(gameObject);
    }
}
