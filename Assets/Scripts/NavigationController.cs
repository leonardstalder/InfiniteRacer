using UnityEngine;

/*
 * Author: Arnaud Durand
 */
public class NavigationController : MonoBehaviour {
	
	public static float speed=120f;
	
	private float splinePosition=0f;
	//public static float acceleration=1f;
	
	public Transform[] blocks;
	private int blockIndex=0;

	public Transform block0Prefab;
	public Transform block45Prefab;
	
	public Transform Ring;
	public Transform Player;
	
	void RespawnBlocks(){
		Destroy(blocks[blockIndex].gameObject);
		int prvIdx=(blockIndex+blocks.Length-1)%blocks.Length;
		Spline previousSpline=blocks[prvIdx].GetComponent<Spline>();
		
		blocks[blockIndex]=Instantiate((Random.value>0.5)?block0Prefab:block45Prefab, previousSpline.GetPositionOnSpline(1f), previousSpline.GetOrientationOnSpline(1f)) as Transform;
		blocks[blockIndex].Rotate(new Vector3(0,0,Random.Range(0,360)),Space.Self);
		blocks[blockIndex].parent=transform;
		blockIndex=(blockIndex+1)%blocks.Length;
	}
	
	/*
	 * TODO: Spawn obstacles as blocks children
	 */
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
	}
	
	void Update () {
		Spline spline=blocks[blockIndex].GetComponent<Spline>();
		splinePosition+=(speed*Time.deltaTime)/spline.Length;
		
		if (splinePosition>1f){
			float exceedingDistance=(splinePosition%1)*spline.Length;
			Vector3 sOffset=-spline.GetPositionOnSpline(1f);
			foreach (Transform t in blocks){
      	      t.position+=sOffset;
       		 }
			RespawnBlocks();
			//Warning: blockIndex changed
			spline=blocks[blockIndex].GetComponent<Spline>();
			splinePosition=exceedingDistance/spline.Length;
		}
		
		//SpawnObstacles();
		Vector3 offset=-spline.GetPositionOnSpline(splinePosition);
		foreach (Transform t in blocks){
            t.position+=offset;
        }
		
		Ring.rotation=spline.GetOrientationOnSpline(splinePosition);
		Player.rotation=spline.GetOrientationOnSpline(splinePosition);
	}
	
}
