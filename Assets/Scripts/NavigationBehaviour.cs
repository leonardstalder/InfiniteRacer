using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Spline))]
public class NavigationBehaviour : MonoBehaviour {
	
	public Spline spline;


	void Awake(){
		spline=GetComponent<Spline>();
	}
	
	protected virtual void Update () {
		
	}
}
