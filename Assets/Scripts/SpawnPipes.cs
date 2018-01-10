using UnityEngine;
using System.Collections;

public class SpawnPipes : MonoBehaviour {
	public GameObject pipePrefab;
	public float distanceBetweenPipes;	// Once the spawner has travelled this distance in the x, spawn pipe
	public float highPoint;
	public float lowPoint;
	

	Vector3 pipePosition;
	float distanceTraveled =0f;
	float previousX =0f;
	// Use this for initialization
	void Start () {
		// Spawn pipe at beginning
		spawnPipe ();

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void FixedUpdate(){
		distanceTraveled = transform.position.x - previousX;
		if(distanceTraveled >= distanceBetweenPipes){
			distanceTraveled=0f;
			spawnPipe ();
		}
	}
	
	void spawnPipe(){
		previousX = transform.position.x;
		pipePosition = new Vector3(previousX,Random.Range(lowPoint, highPoint),0);
		
		Instantiate (pipePrefab,pipePosition, Quaternion.identity);
	}
}
