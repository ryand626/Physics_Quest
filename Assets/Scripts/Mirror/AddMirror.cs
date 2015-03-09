using TouchScript;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddMirror : MonoBehaviour {
	public GameObject uitray;
	public Sprite mirrorSprite;
	private bool mirrorExists;
	// Use this for initialization
	void Start () {
		GetComponent<TapGesture>().StateChanged += tapHandler;
		mirrorExists = false;
		//GetComponent<PanGesture>().StateChanged += panHandler;
		//GetComponent<RotateGesture>().StateChanged += rotateHandler;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void tapHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs) {
		if (!mirrorExists) {
			GameObject newMirror = new GameObject ("Mirror");
			newMirror.AddComponent ("Rigidbody");
			newMirror.AddComponent ("BoxCollider");
			newMirror.AddComponent ("SpriteRenderer");
			//newMirror.AddComponent("Rotate Gesture");
			//newMirror.AddComponent("Pan Gesture");
			SpriteRenderer s = newMirror.GetComponent<SpriteRenderer> ();
			newMirror.rigidbody.useGravity = false;
			newMirror.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			s.sprite = mirrorSprite;
			newMirror.transform.position = new Vector3 (0, 0, 0);
			newMirror.transform.localScale = new Vector3 (1.5f, 1f, 1f);
			BoxCollider b = newMirror.GetComponent<BoxCollider> ();
			b.size = new Vector3 (1.1f, 0.15f, 0.2f);
			mirrorExists = true;
		}
	}

	private void panHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs) {
	}

	private void rotateHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs) {
	}
}
