using UnityEngine;
using System.Collections;

public class NavigationBehaviour : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		transform.Translate(Vector3.back * (NavigationController.speed*Time.deltaTime));
	}
}
