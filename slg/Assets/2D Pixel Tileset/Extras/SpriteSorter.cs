using UnityEngine;
using System.Collections;

public class SpriteSorter : MonoBehaviour {
	//This script automatically sorts sprites depending on Y-position. This is very useful for games that use a top-down perspective, like the old Final Fantasy games.
	//Note that sorting requires the object to be on a Sorting Layer separate from the background. Otherwise objects may render behind scenery.
	public float sortOrderOffset; //Value with which to offset the automatic order in layer. Positive number means object gets rendered in front earlier and vice versa.
	private int sortIndex; //The sorting order number for the object.
	
	void Start() {
		//Sorting order change, to appear in front of or behind objects.
		sortIndex = Mathf.RoundToInt(transform.position.y - sortOrderOffset); //The Sorting Layer value is an int, so we must first round the value.
		renderer.sortingOrder = -sortIndex;
		Destroy(this);
	}
}
