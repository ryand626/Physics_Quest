using System;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;

public class RotateLaser : MonoBehaviour {
	// Add Rotation Gesture Handle
	private void OnEnable()
	{
		GetComponent<RotateGesture> ().Rotated += rotateHandler;
	}
	private void OnDisable()
	{
		if (this.enabled) {
			GetComponent<RotateGesture> ().Rotated -= rotateHandler;
		}
	}

	// Apply rotation via the Rotation Gesture
	private void rotateHandler(object sender, EventArgs e) {
		RotateGesture rotation = (RotateGesture)sender;
		transform.Rotate (0, 0, rotation.DeltaRotation);
	}
}
