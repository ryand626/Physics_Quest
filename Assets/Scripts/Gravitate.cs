using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravitate : MonoBehaviour {
	public float G;
	public List<GameObject> Players;


	void Start () {
		G = 1f; // Gravitational Constant
	}

	void Update () {
		// Recalculate the force on the ball
		constantForce.force = Vector3.zero; // Get rid of the previous force calculations

		// For every player, calculate the force applied to the ball
		foreach (GameObject player in Players){
			// Calculate the magnitude and direction
			float magnitude = (G * player.rigidbody.mass * rigidbody.mass) / Vector3.SqrMagnitude(player.transform.position-gameObject.transform.position);
			Vector3 direction = player.transform.position - gameObject.transform.position;

			// Check the polarity and alter the magnitude accordingly
			Polarity polarity = player.GetComponent<Polarity>(); 
			if(!polarity.state){
				magnitude *= -1;
			}
			magnitude *= polarity.strength;

			// Add the force to the overall force
			constantForce.force = constantForce.force + (magnitude * direction);
		}
	}
}
