using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour {

	public BackgroundParallax First;
	public BackgroundParallax Second;

	public float backgroundSpeed;
	public int backgroundDirection;
	public float road_width;


	void Awake () {
		// Set initial conditions
		backgroundSpeed = 4f;
		backgroundDirection = 1;

		// Grab the parallaxing background
		First = transform.GetChild (0).gameObject.GetComponent<BackgroundParallax> ();
		Second = transform.GetChild (1).gameObject.GetComponent<BackgroundParallax> ();

		UpdateBackground ();
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			backgroundDirection *= -1;
			UpdateBackground();
		}
	}

	void UpdateBackground(){
		//First.scrollSpeed = backgroundSpeed;
		//Second.scrollSpeed = backgroundSpeed;

		//First.scrollDirection = backgroundDirection;
		//Second.scrollDirection = backgroundDirection;
	}
}
