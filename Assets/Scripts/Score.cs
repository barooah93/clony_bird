using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore =0;
	
	static public void AddPoint(){
		score++;
		if(score > highScore){
			highScore = score;
		}
	}
	void Start(){
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore",0);
	}
	void OnDestroy(){
		PlayerPrefs.SetInt ("highScore",highScore);
	}

	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + score + "\nHigh Score: " + highScore;
	}
}
