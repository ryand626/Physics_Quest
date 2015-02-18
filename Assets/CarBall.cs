using UnityEngine;
using System.Collections;

public class CarBall : MonoBehaviour {
	public float mass; // mass of ball
	public float mu; // frictional coefficient
	public float velocity; // velocity of ball

	public CarPhysics Car; // car the ball is on

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
		if (velocity > 0) {
			velocity -= slow_factor;
		}
		if (velocity < 0) {
			velocity += slow_factor;
		}
		// Need to check if the ball is on the car
		if(Car.transform.GetChild(0).renderer.bounds.Intersects(renderer.bounds)){//this doesn't work, should just make a rectangle, or do ray casting
			print("IN BOUNDS");
			if (mass * (Physics.gravity.y * -1f) * mu > Car.mass * Car.acceleration) {
				velocity = Car.velocity;
			}
		}
		transform.Translate(velocity * Time.deltaTime,0f,0f);
	}
}
