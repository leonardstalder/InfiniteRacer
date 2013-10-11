using UnityEngine;
using System.Collections;

public class LightBehaviour : MonoBehaviour {
	
	Light myLight;
	// Use this for initialization
	void Start () {
		myLight=gameObject.GetComponent<Light>();
		
	}
	
	// Update is called once per frame
	void Update () {
		// Reduced to 0 for demonstration.
		myLight.intensity+=0.0f;
	
	}
}
