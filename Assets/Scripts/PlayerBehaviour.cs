using UnityEngine;
using System.Collections;
	
public class PlayerBehaviour : MonoBehaviour {
	
	public float radius=12f;
	public float depth=12;
	public float cameraRadius=6f;
	private float speed=0f;
	public float maxSpeed=1f;
	public float acceleration=2f;
	public float deceleration=2f;
	public Spline ring;
	private float positionOnRing=0f;

	private float shiftAmount=0f;
	
	public void Shift(float shiftAmount){
		this.shiftAmount=shiftAmount;
	}

	//public static float horizontalSpeed=200f;
	
	void Start () {
		//transform.position=new Vector3(0,-radius,depth);
		//Camera.main.transform.position=Vector3.down*cameraRadius;
		
	}
		
	// Update is called once per frame
	
	void LateUpdate () {
		if(Input.anyKey){		
			if (Input.GetKey ("left")&&(speed > -maxSpeed))
				speed = speed - acceleration * Time.deltaTime;
			else if (Input.GetKey ("right")&&(speed < maxSpeed))
				speed = speed + acceleration * Time.deltaTime;
			else {
				if(speed > deceleration * Time.deltaTime)
					speed = speed - deceleration * Time.deltaTime;
				else speed = speed + deceleration * Time.deltaTime;
			}
		}
	/*
		else if (positionOnRing == 0)
			speed = 0;
		else if(positionOnRing > 0.01 && positionOnRing <= 0.5)
			speed = -4f * (positionOnRing * positionOnRing);
				else if (positionOnRing > 0.5 && positionOnRing < 0.99)
			speed = 4f * (1f - positionOnRing) * (1f - positionOnRing);
		else speed = 0;
	*/
		float motion=speed * Time.deltaTime;
		
		motion+=shiftAmount;
		shiftAmount=0f;
		positionOnRing+=motion;		
		positionOnRing=(positionOnRing+1)%1;
		
		transform.position=ring.GetPositionOnSpline(positionOnRing);
		transform.Rotate(new Vector3(0f, 0f, motion*360),Space.Self);
		//transform.rotation=ring.GetOrientationOnSpline(positionOnRing);				
	}
			
}
