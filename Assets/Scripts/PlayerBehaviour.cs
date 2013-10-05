using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float radius=5f;
	private float relativePlayerPosition=0f;
	public float speed;
	public float maxSpeed;
	public float acceleration;
	public float deceleration;
	private Transform camera;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey ("left")&&(speed > -maxSpeed))
			speed = speed - acceleration * Time.deltaTime;
		else if (Input.GetKey ("right")&&(speed < maxSpeed))
			speed = speed + acceleration * Time.deltaTime;
		else {
			if(speed > deceleration * Time.deltaTime)
				speed = speed - deceleration * Time.deltaTime;
			else if(speed < -deceleration * Time.deltaTime)
				speed = speed + deceleration * Time.deltaTime;
			else
				speed = 0;
		}
		relativePlayerPosition+=speed * Time.deltaTime;
		
		//better use rotate around API
		transform.position=new Vector3(Mathf.Sin(relativePlayerPosition*Mathf.PI)*radius,-Mathf.Cos(relativePlayerPosition*Mathf.PI)*radius,transform.position.z);
		Camera.main.transform.localEulerAngles=Vector3.forward*relativePlayerPosition*180;
	}
		
}
