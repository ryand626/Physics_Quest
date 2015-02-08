using UnityEngine;
using System.Collections;

public class Polarity : MonoBehaviour {
	public bool state;       // True = Positive, False = Negative
	public float strength;   // Degree to which the object repels/attracts


	void Start () {
		state = true;
		strength = 1f;
	}
	
	// Change the Polarity of the object
	public void ChangePolarity(){
		state = !state;
	}

	// Set Polarity of Object
	public void SetPolarity(bool newPolarity){
		state = newPolarity;
	}

	// Set the strength of the object
	public void SetStrength(float newStrength){
		strength = newStrength;
	}
}
