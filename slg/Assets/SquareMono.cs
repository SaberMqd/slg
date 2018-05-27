using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof( EntityLink))]
public class SquareMono : MonoBehaviour ,IPointerEnterHandler{

    IGroup<GameEntity> colors;

	// Use this for initialization
	void Start () {
        //colors = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf)
        //colors.OnEntityUpdated += UpdateColor;
	}

    private void UpdateColor(IGroup<GameEntity> group, GameEntity entity, int index, IComponent previousComponent, IComponent newComponent)
    {
        //if(entity.Id.value = id)
        //{

        //}

    }

    // Update is called once per frame
    void Update () {
		
	}
    

    public void OnPointerEnter(PointerEventData eventData)
    {

        Debug.LogError(1111111111);
    }
}
