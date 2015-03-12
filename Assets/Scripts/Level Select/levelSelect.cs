using UnityEngine;
using System.Collections;

public class levelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (mouseRay, out hit, 300)) {
			if(hit.collider.name == "car"){
				print("CAR");
				if(Input.GetMouseButtonDown(0)){
					Application.LoadLevel (1);
				}
			}
			if(hit.collider.name == "magnet"){
				print("MAGNET");
				if(Input.GetMouseButtonDown(0)){
					Application.LoadLevel (0);
				}
			}
			if(hit.collider.name == "mirror"){
				print("MIRROR");
				if(Input.GetMouseButtonDown(0)){
					Application.LoadLevel (2);
				}
			}
		}
	}
}
