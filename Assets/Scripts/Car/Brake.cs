using TouchScript;
using TouchScript.Gestures;
using UnityEngine;
using System.Collections;

public class Brake : MonoBehaviour {
	public GameObject player;
	public bool pressed;
	
	// Use this for initialization
	void Start () {
		pressed = false;
		GetComponent<PressGesture>().StateChanged += pressHandler;
		GetComponent<ReleaseGesture>().StateChanged += releaseHandler;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed) {
			player.SendMessage ("Brake");
		}
	}
	
	private void pressHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
	{
		pressed = true;
	}
	private void releaseHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
	{
		if (pressed)
		{
			pressed = false;
		}
	}	
	
}
