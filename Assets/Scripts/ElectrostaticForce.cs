using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElectrostaticForce : MonoBehaviour {
	public float k;
	public float q1;
	public float q2;
	public float str;
	public bool state;
	public List<GameObject> Players;
	
	
	void Start () {
		k = 1f; // Constant
		q1 = 1f;
		q2 = 1f;
	}
	
	void Update () {
		// Recalculate the force on the ball
		constantForce.force = Vector3.zero; // Get rid of the previous force calculations
		
		// For every player, calculate the force applied to the ball
		foreach (GameObject player in Players){
			// Check the polarity and alter the magnitude accordingly
			Polarity polarity = player.GetComponent<Polarity>(); 
			/*if(!polarity.state){
				q2 = -1f;
			}else{
				q2 = 1f;
			}*/
			if(state) {
				q2 = -1f;
			}
			else {
				q2 = 1f;
			}
			q2 *= polarity.strength;

			// Calculate the magnitude and direction
			float magnitude = (k * q1 * q2) / Mathf.Sqrt(Vector3.SqrMagnitude(player.transform.position - gameObject.transform.position));
			Vector3 direction = player.transform.position - gameObject.transform.position;

			
			// Add the force to the overall force
			constantForce.force = (constantForce.force + (magnitude * direction))/1.5f;
		}
	}


}
