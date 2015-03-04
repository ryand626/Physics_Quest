using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {
	// Objects
	public RoadController Road;
	public CarPhysics Car;
	public GameObject Ball;
	public Sprite basket;
	public Sprite bowl;
	public Sprite beach;
	public int ball_type;

	private int score;
	public Text text;

	// Constants
	public float acceleration_factor;
	public float brake_factor;
	public float top_speed;

	// Variables
	public float playerSpeed;
	private float playerDirection;
	
	private float offset;


	void Start () {
		ball_type = 0;
		playerSpeed = 0f;
		playerDirection = -1f;
		score = 0;
	}
	
	// Move the car according to the road speed, and the car speed
	void Update () {

		if (Input.GetKey("escape")) { Application.Quit(); } 


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
		Car.velocity = playerSpeed * playerDirection; //Road.backgroundDirection; // same here
		text.text = score.ToString();
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
	void OnCollisionEnter(Collision wall) {
		print ("walls");
		if (wall.collider.tag == "right") {
			score++;
			ball_type++;
			if (ball_type == 3) {
				ball_type = 0;
			}
			if (ball_type == 0) {
				Ball.GetComponent<SpriteRenderer>().sprite = basket;
				Ball.GetComponent<CarBall>().mass = 3;
			}
			if (ball_type == 1) {
				Ball.GetComponent<SpriteRenderer>().sprite = bowl;
				Ball.GetComponent<CarBall>().mass = 10;
			}
			if (ball_type == 2) {
				Ball.GetComponent<SpriteRenderer>().sprite = beach;
				Ball.GetComponent<CarBall>().mass = 1;
			}
		}
		playerSpeed = playerSpeed/2;
		playerDirection = -playerDirection;
	}
	public void BallFell() {
		score -= 2;
	}
}
