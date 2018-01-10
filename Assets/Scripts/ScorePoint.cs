using UnityEngine;
using System.Collections;

public class ScorePoint : MonoBehaviour {

	BirdMovement birdScript;
	
	void Start(){
		GameObject goPlayer = GameObject.FindGameObjectWithTag("Player");
		if(goPlayer == null){
			Debug.LogError("Could not find an object with tag 'Player'");
		}
		else{
			birdScript = goPlayer.GetComponent<BirdMovement>();
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Player")){
			if(!birdScript.dead){
				Score.AddPoint();
			}
			
		}
	}
}
