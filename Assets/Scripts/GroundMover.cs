using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {
	
	float speed = 0f;
	
	Rigidbody2D player;

	
	// Use this for initialization
	void Start () {
		GameObject goPlayer = GameObject.FindGameObjectWithTag("Player");
		
		if(goPlayer == null){
			Debug.LogError ("Couldn't find an object with tag 'Player'!");
			return;
		}
		
		player = goPlayer.rigidbody2D;
		
	}
	
	void FixedUpdate() {
		float vel = player.velocity.x * 0.75f;
		
		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
	}
}
