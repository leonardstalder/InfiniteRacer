using UnityEngine;
using System.Collections;

public class NavigationController : MonoBehaviour {
	
	//public static float blockSize=400f;
	public static float speed=120f;
	
	private float splinePosition=0f;
	//public static float acceleration=1f;
	
	public Transform[] blocks;
	private int blockIndex=0;

	public Transform block0Prefab;
	public Transform block45Prefab;
	//public Transform obstacleUPrefab;
	//public Transform obstacleDPrefab;
	//public Transform obstacleMPrefab;
	public Transform Player;
	
	//private float lastObstacleTime;
	
	void RespawnBlocks(){
		Destroy(blocks[blockIndex].gameObject);
		int prvIdx=(blockIndex+blocks.Length-1)%blocks.Length;
		Spline previousSpline=blocks[prvIdx].GetComponent<Spline>();
		
		blocks[blockIndex]=Instantiate((Random.value>0.5)?block0Prefab:block45Prefab, previousSpline.GetPositionOnSpline(1f), previousSpline.GetOrientationOnSpline(1f)) as Transform;
		blocks[blockIndex].parent=transform;
		blockIndex=(blockIndex+1)%blocks.Length;
	}
	
	/*
	 * TODO: Spawn obstacles as blocks children
	 * */
	void SpawnObstacles(){
	}
	
	
	void Start(){
		blocks=new Transform[6];
		
		Vector3 nextPosition=Vector3.zero;
		Quaternion nextOrientation=Quaternion.identity;
		Spline nextSpline=null;
		
		for(int i=0; i<blocks.Length; i++){
			blocks[i]=Instantiate (block0Prefab, nextPosition, nextOrientation) as Transform;
			nextSpline=blocks[i].GetComponent<Spline>();
			nextPosition=nextSpline.GetPositionOnSpline(1f);
			nextOrientation=nextSpline.GetOrientationOnSpline(1f);
			blocks[i].parent=transform;
		}
		
		//lastObstacleTime=Time.time;
	}
	
	void Update () {
		Spline spline=blocks[blockIndex].GetComponent<Spline>();
		splinePosition+=(speed*Time.deltaTime)/spline.splineLength;
		
		if (splinePosition>1f){
			float exceedingDistance=(splinePosition%1)*spline.splineLength;
			//Vector3 sOffset=-blocks[blockIndex].position+(Vector3.zero-spline.GetPositionOnSpline(1f));
			Vector3 sOffset=-spline.GetPositionOnSpline(1f);
			foreach (Transform t in blocks){
      	      t.position+=sOffset;
       		 }
			RespawnBlocks();
			//Warning: blockIndex changed
			spline=blocks[blockIndex].GetComponent<Spline>();
			splinePosition=exceedingDistance/spline.splineLength;
		}
		
		//SpawnObstacles();
		//Vector3 offset=-blocks[blockIndex].position+(Vector3.zero-spline.GetPositionOnSpline(splinePosition));
		Vector3 offset=-spline.GetPositionOnSpline(splinePosition);
		foreach (Transform t in blocks){
            t.position+=offset;
        }
		Player.rotation=spline.GetOrientationOnSpline(splinePosition);
	}
	
	
	/*void LateUpdate(){
		RespawnBlocks();
	}*/
	
}
