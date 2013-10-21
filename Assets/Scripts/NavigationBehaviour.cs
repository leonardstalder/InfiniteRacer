using UnityEngine;
using System.Collections;

public class NavigationBehaviour : MonoBehaviour {
	
	public string splineName;
	//should be rdonly
	public Spline spline;

	void Awake(){
		spline=GameObject.FindWithTag("Splines").transform.Find(splineName).GetComponent<Spline>();
	}
	
	protected virtual void Update () {
		
	}
}
