using UnityEngine;
using System.Collections;

public class BGLooperScript : MonoBehaviour {

	int numBGPanels = 6;

	void OnTriggerEnter2D(Collider2D collider){
	
		if(collider.CompareTag("Pipes")){
			Destroy(collider.gameObject);
			Destroy(collider.transform.parent.gameObject);
		}
		else{
			Debug.Log ("Triggered: " + collider.name);
			
			float widthOfBGObject = ((BoxCollider2D)collider).size.x;
			
			Vector3 pos = collider.transform.position;
			
			pos.x += widthOfBGObject * numBGPanels - widthOfBGObject/2;
			
			collider.transform.position = pos;
		}
	}
}
