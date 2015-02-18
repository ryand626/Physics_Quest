using UnityEngine;
using System.Collections;

// Used for physics data on the car
public class CarPhysics : MonoBehaviour {
	public float mass; // car mass
	public float acceleration; // car acceleration
	public float velocity;
	void Start(){
		acceleration = 0;
	}
}
