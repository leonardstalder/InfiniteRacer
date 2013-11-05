using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Spline))]
public class NavigationBehaviour : MonoBehaviour {
	
	public Spline spline
	{
		get {return GetComponent<Spline>();}
	}
	
	public float torque=0f;
	
	/*
	 * TODO: Spawn obstacles as blocks children
	 */
	protected virtual void SpawnObstacles () {
		
	}
}
