using System;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;

public class AddMirror : MonoBehaviour {
	public GameObject uitray;
	public Sprite mirrorSprite;

	private bool mirrorExists;
	private GameObject mirror;
	
	void Start () {
		if (!uitray) {
			uitray = transform.parent.gameObject;
		}
		mirrorExists = false;
	}

	// Add the events for tap creation and rotating of the mirror
	private void OnEnable()
	{
		GetComponent<TapGesture> ().Tapped += tappedHandler;
		GetComponent<RotateGesture> ().Rotated += rotateHandler;
	}
	private void OnDisable()
	{
		if (this.enabled) {
			GetComponent<TapGesture> ().Tapped -= tappedHandler;
			GetComponent<RotateGesture> ().Rotated -= rotateHandler;
		}
	}

	// Create a mirror when tapped (and a mirror doesn't already exist)
	private void tappedHandler(object sender, EventArgs e) {
		if (!mirrorExists) {
			mirrorExists = true;
			GameObject newMirror = (GameObject)Instantiate(Resources.Load("Prefabs/Mirror/Mirror"));

			// Update the sprite depending on the player's mirror sprite
			SpriteRenderer s = newMirror.GetComponent<SpriteRenderer> ();
			s.sprite = mirrorSprite;

			// Set the position and names
			if(uitray.name == "UITray Pink") {
				newMirror.transform.position = new Vector3 (-4.7f, -2f, 0);
				newMirror.name = "Pink Mirror";
			}
			else if(uitray.name == "UITray Yellow") {
				newMirror.transform.position = new Vector3 (3f, 4f, 0);
				newMirror.name = "Yellow Mirror";
			}
			else if(uitray.name == "UITray Purple") {
				newMirror.transform.position = new Vector3 (5f, 1.5f, 0);
				newMirror.name = "Purple Mirror";
			}
			else {
				newMirror.transform.position = new Vector3 (-4.7f, 4f, 0);
				newMirror.name = "Orange Mirror";
			}

			newMirror.transform.rotation = transform.rotation;
			mirror = newMirror;
		}
	}

	// Apply rotation to UI and Mirror
	private void rotateHandler(object sender, EventArgs e) {
		RotateGesture rotation = (RotateGesture)sender;
		if (mirror) {
			transform.Rotate(0,0,rotation.DeltaRotation);
			mirror.transform.Rotate(0,0,rotation.DeltaRotation);
		} else {
			print ("No Mirror!");
		}
	}
}
