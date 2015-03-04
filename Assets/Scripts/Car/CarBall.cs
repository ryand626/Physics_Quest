using UnityEngine;
using System.Collections;

public class CarBall : MonoBehaviour {
	public float mass; // mass of ball
	public float mu; // frictional coefficient
	public float velocity; // velocity of ball


	public GameObject Car; // car the ball is on

	public float slow_factor; // factor by which the ball slows down when it falls off the car

	void Start(){
		velocity = 0f;
		slow_factor = .5f;
	}

	// Keep the ball on the car if there is enough frictional force
	void Update () {
//		print ("FRICTION: " + mass * Physics.gravity.y * mu);
//		print("CAR: " + Car.mass * Car.acceleration);

		// Have the ball slow down when it falls off
		/*if (velocity > 0) {
			velocity -= slow_factor;
		}
		if (velocity < 0) {
			velocity += slow_factor;
		}*/
		// Need to check if the ball is on the car

		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); } 

		if (Car.transform.GetChild (0).renderer.bounds.Intersects (renderer.bounds)) {//this doesn't work, should just make a rectangle, or do ray casting
			if (Car.GetComponent<CarPhysics> ().acceleration >= 0 && mass * (Physics.gravity.y * -1f) * mu > Car.GetComponent<CarPhysics> ().mass * Car.GetComponent<CarPhysics> ().acceleration) {
				velocity = Car.GetComponent<CarPhysics> ().velocity;
			} 
			if (Car.GetComponent<CarPhysics> ().acceleration < 0 && mass * (Physics.gravity.y * -1f) * mu > Car.GetComponent<CarPhysics> ().mass * Car.GetComponent<CarPhysics> ().acceleration) {
				velocity = Car.GetComponent<CarPhysics> ().velocity;
			}

		} else {
			Vector3 temp = transform.position;
			temp.x = Car.transform.position.x;
			transform.position = temp;
			velocity = (Car.GetComponent<CarPhysics>().velocity)/2f;
			Car.GetComponent<PlayerControls>().SendMessage("BallFell");

		}

		transform.Translate(velocity * Time.deltaTime,0f,0f);
	}
	
}
