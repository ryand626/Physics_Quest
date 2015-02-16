using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Polarity : MonoBehaviour {
	public bool state;       // True = Positive, False = Negative
	public int strength;   // Degree to which the object repels/attracts
	public Text text;


	void Start () {
		if (state) 
			strength = 1;
		else {
			strength = -1;
		}
		//Vector3 temp = new Vector3 (Random.Range (-5.75f, 5.75f), Random.Range (-2.3f, 4.15f), 0);
		//transform.position = temp;
	}

	void Update(){
		if (state) {
			text.text = "+" + strength.ToString();
		}
		else {
			text.text = strength.ToString ();
		}
	}

	// Change the Polarity of the object
	public void ChangePolarity(){
		state = !state;
	}

	// Set Polarity of Object
	public void AddStrength(){
		if (strength <= 4 && strength> 0) {
			strength++;
		}
		if (strength < -1) {
			strength++;
		}
	}

	public void SubtractStrength(){
		if (strength > 1) {
			strength--;
		}
		if (strength >= -4 && strength < 0) {
			strength--;
		}
	}

	// Set the strength of the object
	public void SetStrength(int newStrength){
		strength = newStrength;
	}
}
