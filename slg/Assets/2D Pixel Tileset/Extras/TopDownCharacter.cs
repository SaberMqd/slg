using UnityEngine;
using System.Collections;

public class TopDownCharacter : MonoBehaviour {
	//This is a simple top-down perspective character script, which includes directional/diagonal movement and automatic sprite sorting.

	//Note that the character should be on the same Sorting Layer as the scenery objects.

	//Sort order offset should ideally be set to 1, to ensure that the character renders above objects on the same "order in layer", when moving in front of them.

	//This script requires a rigidbody and collider component, as it uses physics force to move. Refer to the "Wisp" prefab for ideal rigidbody values. Gravity scale must be set to 0!

	public float minMoveValue = 0.1f; //Minimum value that axis movement needs to be for the character to move.
	public float moveSpeed = 6.0f; //Move speed value in all directions. Value is later multiplied by below variable; pixels per unit.
	public int pixelsPerUnit = 32; //Amount of pixels per unit in Unity.
	public float sortOrderOffset = 1.0f; //Value with which to offset the automatic order in layer. Positive number means object gets rendered in front earlier and vice versa.
	private int sortIndex; //The sorting order number for the object.
	private float speed; //Internal/private final speed value; moveSpeed multiplied by pixelsPerUnit.
	
	void Start() {
		//Sorting order change, to appear in front of or behind objects.
		sortIndex = Mathf.RoundToInt(transform.position.y - sortOrderOffset);
		renderer.sortingOrder = -sortIndex;
	}

	void FixedUpdate() {
		speed = moveSpeed * pixelsPerUnit; //Multiply speed by unit size. Note that this does not mean, for instance, 1 unit per second, due to rigidbody mass and drag affecting speed.

		//Horizontal movement.
		if (Input.GetAxis("Horizontal") > minMoveValue) {
			rigidbody2D.AddForce(new Vector2(speed,0) * Time.deltaTime);
		}
		else if (Input.GetAxis("Horizontal") < -minMoveValue) {
			rigidbody2D.AddForce(new Vector2(-speed,0) * Time.deltaTime);
		}

		//Vertical movement.
		if (Input.GetAxis("Vertical") > minMoveValue) {
			rigidbody2D.AddForce(new Vector2(0,speed) * Time.deltaTime);
		}
		else if (Input.GetAxis("Vertical") < -minMoveValue) {
			rigidbody2D.AddForce(new Vector2(0,-speed) * Time.deltaTime);
		}
	}
	
	void Update () {
		//Sorting order change, to appear in front of or behind objects.
		sortIndex = Mathf.RoundToInt(transform.position.y - sortOrderOffset); //The Sorting Layer value is an int, so we must first round the value.
		renderer.sortingOrder = -sortIndex;
	}
}
