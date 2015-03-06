using TouchScript;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnOffLaser : MonoBehaviour {
	public GameObject uitray;
	public Sprite onLaser;
	public Sprite offLaser;
	private Image currImage;
	
	// Use this for initialization
	void Start () {
		GetComponent<TapGesture>().StateChanged += tapHandler;
		currImage = uitray.GetComponent<Image>();
		
	}
	// Update is called once per frame
	void Update () {
	}
	
	private void tapHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
	{
		print (currImage.sprite);

		// Switch sprite to laser on sprite
		if (currImage.sprite == offLaser) {
			print ("switch to on");
			currImage.sprite = onLaser;
		}
		// Switch sprite to laser off sprite
		else {
			print ("switch to off");
			currImage.sprite = offLaser;
		}
	}
}
