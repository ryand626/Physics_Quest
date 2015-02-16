using TouchScript;
using TouchScript.Gestures;
using UnityEngine;
using System.Collections.Generic;

//This script does nothing except the OnGUI function, which just shows the name of the game object centered on it.
//To use Scale Gesture, just attach some kind of Collider (Box Collider, Sphere Collider, etc.) to a game object, along
//with the TouchScript "Scale Gesture" and "Transformer2D" components.

//Always make sure that your scene contains an Empty Game Object named "TouchScript", with the components 
//"TUIO Input" and "Mouse Input" attached. Without this, TouchScript will not recognize input.

public class ftlScale : ftlManager
{

	private void Start()
	{
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
}