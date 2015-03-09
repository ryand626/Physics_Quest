using TouchScript;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotateLaser : MonoBehaviour {
	public GameObject button;
	public GameObject laser;
	// Use this for initialization
	void Start () {
		GetComponent<TapGesture>().StateChanged += tapHandler;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void tapHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs) {
		if (button.name == "Left Rotate") {
			laser.transform.Rotate(0,0,1);
		}
		if (button.name == "Right Rotate") {
			laser.transform.Rotate(0,0,-1);
		}
	}
}
