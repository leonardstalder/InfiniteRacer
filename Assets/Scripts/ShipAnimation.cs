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
	private GameObject propellerLeft;
	private GameObject propellerRight;
	
	// --------------------------------------------------------------
	// Update.
	// --------------------------------------------------------------

	// Use this for initialization
	void Start ()
	{		
		// Get propeller objects.
		propellerLeft = GameObject.Find("PropellerLeft");
		propellerRight = GameObject.Find("PropellerRight");
	}
	
	// Update is called once per frame.
	void Update ()
	{
		rotatePropellers(); 	// Rotate the propellers.
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
}