using System;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;



public class RotateLaser : MonoBehaviour {

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
	private void rotateHandler(object sender, EventArgs e) {
		RotateGesture rotation = (RotateGesture)sender;
		transform.Rotate (0, 0, rotation.DeltaRotation);
	}
}
