using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	// Objects
	public RoadController Road;
	public CarPhysics Car;

	// Constants
	public float acceleration_factor;
	public float brake_factor;
	public float top_speed;

	// Variables
	public float playerSpeed;
	private float playerDirection;
	
	private float offset;


	void Start () {
		playerSpeed = 2f;
		playerDirection = 1f;
	}
	
	// Move the car according to the road speed, and the car speed
	void Update () {
		//Road.backgroundSpeed * Road.backgroundDirection * .2f +
		offset =  playerSpeed * playerDirection * Road.backgroundDirection; // player direction doesn't do anything atm, so i'm using the road direction as a placeholder
		transform.Translate (offset * Time.deltaTime, 0f, 0f);

		if (Input.GetKey (KeyCode.A)) {
			Accelerate();
		}
		if (Input.GetKey (KeyCode.B)) {
			Brake();
		}
		if (!Input.anyKey) {
			Car.acceleration = 0f;
		}
		// Update the velocity of the car to be used by the ball script
		Car.velocity = playerSpeed * playerDirection * Road.backgroundDirection; // same here
	}

	// Accelerate the car up to the top_speed
	public void Accelerate(){
		if(playerSpeed + acceleration_factor < top_speed){
			playerSpeed += acceleration_factor;
			Car.acceleration = acceleration_factor;
		}else{
			playerSpeed = top_speed;
		}
	}

	// Deaccelerate the car down to 0
	public void Brake(){
		if(playerSpeed - brake_factor > 0f){
			playerSpeed -= brake_factor;
			Car.acceleration = brake_factor * -1f;
		}else{
			playerSpeed = 0f;
		}
	}
}
