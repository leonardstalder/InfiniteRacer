using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : NavigationBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if(transform.position.z<0f)
			Destroy(gameObject);
	}
}
