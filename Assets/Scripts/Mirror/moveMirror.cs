using System;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;

public class moveMirror : MonoBehaviour {
	// Add the gestures
	private void OnEnable()
	{
		GetComponent<PanGesture> ().Panned += panHandle;
		GetComponent<PanGesture> ().PanCompleted += panStop;
	}
	private void OnDisable()
	{
		if (this.enabled) {
			GetComponent<PanGesture>().Panned -= panHandle;
			GetComponent<PanGesture> ().PanCompleted += panStop;
		}
	}


	// Move the mirror using the pan gesture
	private void panHandle(object sender, EventArgs e){
		PanGesture pan = (PanGesture)sender;
		transform.position = transform.position + pan.LocalDeltaPosition;
	}

	// Ensure the player can only move the mirror once
	private void panStop(object sender, EventArgs e){
		Destroy (this.GetComponent<PanGesture> ());
		Destroy (this);
	}
}
