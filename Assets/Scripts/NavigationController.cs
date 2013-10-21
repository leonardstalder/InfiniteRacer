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
	public Transform obstacleUPrefab;
	public Transform obstacleDPrefab;
	public Transform obstacleMPrefab;

	private float lastObstacleTime;
	
	void RespawnBlocks(){
		Destroy(blocks[blockIndex].gameObject);
		int prvIdx=(blockIndex+blocks.Length-1)%blocks.Length;
		blocks[blockIndex]=Instantiate(block45Prefab, blocks[prvIdx].GetComponent<NavigationBehaviour>().spline.GetPositionOnSpline(1f)+blocks[prvIdx].position, Quaternion.identity) as Transform;
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
		
		for(int i=0; i<blocks.Length; i++){
			blocks[i]=Instantiate (block0Prefab, nextPosition, Quaternion.identity) as Transform;
			nextPosition+=blocks[i].GetComponent<NavigationBehaviour>().spline.GetPositionOnSpline(1f);
			blocks[i].parent=transform;
		}
		
		lastObstacleTime=Time.time;
	}
	
	void Update () {
		Spline spline=blocks[blockIndex].GetComponent<NavigationBehaviour>().spline;
		splinePosition+=(speed*Time.deltaTime)/spline.splineLength;

		if (splinePosition>1f){
			float exceedingDistance=(splinePosition%1)*spline.splineLength;
			Vector3 sOffset=-blocks[blockIndex].position+(Vector3.zero-spline.GetPositionOnSpline(1f));
			foreach (Transform t in blocks){
      	      t.position+=sOffset;
       		 }
			RespawnBlocks();
			//Warning: blockIndex changed
			spline=blocks[blockIndex].GetComponent<NavigationBehaviour>().spline;
			splinePosition=exceedingDistance/spline.splineLength;
		}
		
		//SpawnObstacles();
		Vector3 offset=-blocks[blockIndex].position+(Vector3.zero-spline.GetPositionOnSpline(splinePosition));
		foreach (Transform t in blocks){
            t.position+=offset;
        }
	}
	
	
	/*void LateUpdate(){
		RespawnBlocks();
	}*/
	
}
