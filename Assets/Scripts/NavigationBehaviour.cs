using UnityEngine;
using System.Collections;

public class NavigationBehaviour : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		//will work if prefab is not rotated
		//transform.Translate(Vector3.back * (speed*Time.deltaTime));
		transform.position-=new Vector3(0,0,NavigationController.speed*Time.deltaTime);
	}
}
