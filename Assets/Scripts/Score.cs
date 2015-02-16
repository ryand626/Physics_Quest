using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public float score; // score of the player (can later be expanded into an list of scores)
	public List<Text> texts;   // text object that displays player score (ditto to above)

	// Start the score at zero
	void Start () {
		score = 0f;
	}
	// Update the player score
	void Update () {
		foreach (Text t in texts) {
			t.text = "" + score;
		}
	}
	// Add to the score when the ball goes into the goal
	void OnTriggerEnter(Collider target){
		Vector3 temp = new Vector3 (Random.Range (-5.75f, 5.75f), Random.Range (-2.3f, 4.15f), 0);
		transform.position = temp;
		if (target.tag == "snake") {
			score += 1;
		}
	}
}
