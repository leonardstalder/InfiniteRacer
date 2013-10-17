using UnityEngine;
using System.Collections;

public class NavigationController : MonoBehaviour {
	
	public static float blockSize=400f;
	public static float speed=160f;
	//public static float acceleration=1f;
	
	private Transform[] blocks;
	private int blockIndex=0;

	public Transform blockPrefab;
	public Transform obstacleUPrefab;
	public Transform obstacleDPrefab;
	public Transform obstacleMPrefab;

	
	private float lastObstacleTime;
	
	void RespawnBlocks(){
		if(blocks[blockIndex].position.z<-blockSize){
			Vector3 tubePosition=blocks[blockIndex].position;
			Destroy(blocks[blockIndex].gameObject);
			blocks[blockIndex]=Instantiate(blockPrefab, tubePosition + new Vector3(0, 0, blocks.Length*blockSize), blockPrefab.rotation) as Transform;
			blocks[blockIndex].gameObject.AddComponent<NavigationBehaviour>();
			blocks[blockIndex].parent=transform;
			blockIndex=(blockIndex+1)%blocks.Length;
		}
	}
	
	void SpawnObstacles(){
		if (Time.time-lastObstacleTime>1f){	
			lastObstacleTime=Time.time;
			Transform obstacle;
			float randval=Random.value;
			if(randval<1/3f)
				obstacle=Instantiate(obstacleUPrefab, obstacleUPrefab.position + new Vector3(0, 0, blocks.Length*blockSize), obstacleUPrefab.rotation) as Transform;
			else{
				if (randval<2/3f)
					obstacle=Instantiate(obstacleDPrefab, obstacleDPrefab.position + new Vector3(0, 0, blocks.Length*blockSize), obstacleDPrefab.rotation) as Transform;
				else
					obstacle=Instantiate(obstacleMPrefab, obstacleMPrefab.position + new Vector3(0, 0, blocks.Length*blockSize), obstacleMPrefab.rotation) as Transform;
			}
			obstacle.gameObject.AddComponent<ObstacleBehaviour>();
			obstacle.parent=transform;
		}
		
	}
	
	void Start(){
		blocks=new Transform[6];
		for(int i=0; i<blocks.Length; i++){
			blocks[i]=Instantiate (blockPrefab, new Vector3(0f, 0f, i*blockSize), blockPrefab.rotation) as Transform;
			blocks[i].gameObject.AddComponent<NavigationBehaviour>();
			blocks[i].parent=transform;
		}
		lastObstacleTime=Time.time;
	}
	
	
	// Update is called once per frame
	void Update () {
		SpawnObstacles();
	}
	
	void LateUpdate(){
		RespawnBlocks();
	}
	
}
