using UnityEngine;
using System.Collections;

// ------------------------------------------------------------------
// Author : Thomas Rouvinez
// Creation date : 16.10.2013
// Last Modified : 17.10.2013
//
// Description : class to handle all animations of the ship.
// ------------------------------------------------------------------

public class ShipAnimation : MonoBehaviour {
	
	// --------------------------------------------------------------
	// Variables.
	// --------------------------------------------------------------
	
	// Game Objects.
	private GameObject ship;
	private GameObject propellerLeft;
	private GameObject propellerRight;
	private GameObject wingLeft;
	private GameObject wingRight;
	
	public float smoothing = 0.15f;
	
	// --------------------------------------------------------------
	// Update.
	// --------------------------------------------------------------

	// Use this for initialization
	void Start ()
	{		
		// Get ship object.
		ship = GameObject.Find("Ship");
		
		// Get propeller objects.
		propellerLeft = GameObject.Find("PropellerLeft");
		propellerRight = GameObject.Find("PropellerRight");
		
		// Get wing objects.
		wingLeft = GameObject.Find("WingLeft");
		wingRight = GameObject.Find("WingRight");
	}
	
	// Update is called once per frame.
	void Update ()
	{
		rotatePropellers(); 	// Rotate the propellers.
		
		// Get user input.
		if(Input.GetKey(KeyCode.LeftArrow))
		{
            
		}
	}
	
	// --------------------------------------------------------------
	// Ship animations.
	// --------------------------------------------------------------
	
	// Rotate the propellers.
	void rotatePropellers()
	{
		propellerLeft.transform.Rotate(Vector3.up, Time.deltaTime * 100000);
		propellerRight.transform.Rotate(Vector3.up, Time.deltaTime * 100000);
	}
	
	// Slow down.
	void rotateLeft()
	{
		
	}
}