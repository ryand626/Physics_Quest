using TouchScript;
using TouchScript.Gestures;
using UnityEngine;
using System.Collections;

public class Plus : MonoBehaviour {
	public GameObject player;
	
	// Use this for initialization
	void Start () {
		GetComponent<TapGesture>().StateChanged += tapHandler;
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	
	private void tapHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
	{
		player.SendMessage ("AddStrength");
	}
}
