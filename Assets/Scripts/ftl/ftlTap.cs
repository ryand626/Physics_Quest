using TouchScript;
using TouchScript.Gestures;
using UnityEngine;
using System.Collections.Generic;

//Attach this component to a Sprite, along with the TouchScript component "Tap Gesture", 
//as well as some kind of Collider (Box Collider, Sphere Collider, etc.)
//Right now it just changes the sprite's color with every Tap, and there is a commented out section to play a sound effect on Tap.
//To use the sound effect, you must first add an "Audio Source" component to the sprite with an audio clip assigned, and then uncomment the block below.
//
//OnGUI just shows the name of the game object centered on it.
//
//Always make sure that your scene contains an Empty Game Object named "TouchScript", with the components 
//"TUIO Input" and "Mouse Input" attached. Without this, TouchScript will not recognize input.

public class ftlTap : ftlManager
{
	private SpriteRenderer button;
	private int _counter;
	
	private void Start()
	{
		GetComponent<TapGesture>().StateChanged += tapHandler;
		button = gameObject.GetComponent<SpriteRenderer>();
		button.color = new Color (1f, 1f, 1f, 1f);	

		textStyle = new GUIStyle ();
		textStyle.font = (Font)Resources.Load("PAPYRUS");
		textStyle.fontSize = 24;
		textStyle.normal.textColor = new Color (1f, 1f, 1f, 1f);
	}

	void OnGUI () 
	{		
		var position = transformToObject (new Vector3 (Screen.width / 2, Screen.height / 2, 0f) , gameObject);
		var labelContent = new GUIContent ();
		labelContent.text = gameObject.name;
		var labelSize = textStyle.CalcSize (labelContent);
		
		GUI.color = new Color (0f, 0f, 0f, 1f);
		GUI.Label (new Rect (position.x - labelSize.x / 2 , position.y - labelSize.y / 2 , labelSize.x , labelSize.y ), gameObject.name , textStyle);	
	}
	
	private void tapHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
	{
		//		var audioSource = GetComponent<AudioSource> ();
		//		var sound = audioSource.clip;
		//		audio.PlayOneShot (sound);		
		button.color = GetColor (_counter, 1, 1);
		_counter++;
	}
	

}