using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed = 100f;
	float forwardSpeed = 1.2f;
	Animator animator;
	
	bool didFlap = false;
	public bool dead = false;
	float deathCooldown;
	
	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
		
	}
	
	void Update(){
		if(dead){
			deathCooldown -= Time.deltaTime;
			if(deathCooldown <=0){
				if(Input.GetKeyDown(KeyCode.Space)||(Input.GetMouseButtonDown(0))){
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
		else{
			if(Input.GetKeyDown(KeyCode.Space)||(Input.GetMouseButtonDown(0))){
				didFlap = true;
			}
		}
	}
	
	
	void FixedUpdate () {
		if(dead)
			return;
			
		rigidbody2D.AddForce(Vector2.right * forwardSpeed);
		if(didFlap){
			rigidbody2D.AddForce(Vector2.up * flapSpeed);
			didFlap=false;
			
			
			animator.SetTrigger("DoFlap");
		}
		if(rigidbody2D.velocity.y > 0 ){
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		else{
			float angle = Mathf.Lerp (0, -70, -rigidbody2D.velocity.y / 3f);
			transform.rotation = Quaternion.Euler(0,0,angle);
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(!collision.gameObject.CompareTag("Roof")){
			animator.SetTrigger("Death");
			dead = true;
			deathCooldown = 0.5f;
		}
	}
}
