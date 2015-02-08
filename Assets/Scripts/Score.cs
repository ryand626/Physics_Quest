using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public float score; // score of the player (can later be expanded into an list of scores)
	public Text text;   // text object that displays player score (ditto to above)

	// Start the score at zero
	void Start () {
		score = 0f;
	}
	// Update the player score
	void Update () {
		text.text = "" + score;
	}
	// Add to the score when the ball goes into the goal
	void OnTriggerEnter(Collider target){
		score += 1;
	}
}
