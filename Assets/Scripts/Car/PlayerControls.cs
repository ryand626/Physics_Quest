using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	public RoadController Road;

	public float acceleration_factor;
	public float brake_factor;
	public float top_speed;

	public float playerSpeed;
	private float playerDirection;
	
	private float offset;


	void Start () {
		playerSpeed = 4f;
		playerDirection = 1f;
	}
	
	// Move the car according to the road speed, and the car speed
	void Update () {
		offset = Road.backgroundSpeed * Road.backgroundDirection + playerSpeed * playerDirection;
		transform.Translate (offset * Time.deltaTime, 0f, 0f);
	}

	// Accelerate the car up to the top_speed
	public void Accelerate(){
		if(playerSpeed + acceleration_factor < top_speed){
			playerSpeed += acceleration_factor;
		}else{
			playerSpeed = top_speed;
		}
	}

	// Deaccelerate the car down to 0
	public void Brake(){
		if(playerSpeed - brake_factor > 0f){
			playerSpeed -= brake_factor;
		}else{
			playerSpeed = 0f;
		}
	}
}
