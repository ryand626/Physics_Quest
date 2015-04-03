using System;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;

public class RotateLaser : MonoBehaviour {
	public GameObject button;
	public GameObject laser;

	// Add Rotation Gesture Handle
	private void OnEnable()
	{
		//GetComponent<RotateGesture> ().Rotated += rotateHandler;
		GetComponent<TapGesture> ().Tapped += tapHandler;
	}
	private void OnDisable()
	{
		if (this.enabled) {
			//GetComponent<RotateGesture> ().Rotated -= rotateHandler;
			GetComponent<TapGesture> ().Tapped -= tapHandler;
		}
	}

	// Apply rotation via the Rotation Gesture
	private void rotateHandler(object sender, EventArgs e) {
		RotateGesture rotation = (RotateGesture)sender;
		transform.Rotate (0, 0, rotation.DeltaRotation);
	}

	private void tapHandler(object sender, EventArgs e) {
		if(button.name == "Left Rotate") {
			laser.transform.Rotate(0,0,1);
		}
		if(button.name == "Right Rotate") {
			laser.transform.Rotate(0,0,-1);
		}
	}
}
