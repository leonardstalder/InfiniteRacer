using UnityEngine;
using System.Collections;

public class NavigationBehaviour : MonoBehaviour {
	
	public float blockSize=80f;
	public float speed=1;
	public float acceleration=1;
	
	public Transform[] tubes;
	public int blockIndex=0;
	public Transform blockPrefab;
	public Transform obstacleUPrefab;
	public Transform obstacleDPrefab;
	
	private float lastObstacleTime;
	
	// Use this for initialization
	void Start () {
		for(int i=0; i<tubes.Length; i++){
			tubes[i]=Instantiate (blockPrefab, new Vector3(0f, 0f, i*blockSize), blockPrefab.rotation) as Transform;
			tubes[i].parent=transform;
		}
		lastObstacleTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(tubes[blockIndex].position.z<-blockSize){
			Vector3 tubePosition=tubes[blockIndex].position;
			Destroy(tubes[blockIndex].gameObject);
			tubes[blockIndex]=Instantiate(blockPrefab,tubePosition + new Vector3(0, 0, tubes.Length*blockSize), blockPrefab.rotation) as Transform;
			tubes[blockIndex].parent=transform;
			blockIndex=(blockIndex+1)%tubes.Length;
		}
		if (Time.time-lastObstacleTime>5f){
			lastObstacleTime=Time.time;
			Transform obstacle=Instantiate(obstacleUPrefab, obstacleUPrefab.position+(Vector3.forward*800), Quaternion.identity) as Transform;
			obstacle.parent=transform;
		}
	}
	
	void FixedUpdate () {
		transform.position-=new Vector3(0,0,speed*acceleration);
			
		
		
	}
}
