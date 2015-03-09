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
	private bool isOn;

	public GameObject laser;
	public GameObject laserParent;
	private GameObject source;
	private GameObject target;
	public LineRenderer line;
	public Vector3 nextPosition;
	public int bounceNumber;
	private int i;
	
	// Use this for initialization
	void Start () {
		i = 1;
		GetComponent<TapGesture>().StateChanged += tapHandler;
		currImage = uitray.GetComponent<Image>();
		isOn = false;
		line = gameObject.AddComponent<LineRenderer> ();
		bounceNumber = 1;
		source = laser;
	}
	// Update is called once per frame
	void Update () {
	}

	private void tapHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
	{
		if (!isOn) {
			isOn = true;
			currImage.sprite = onLaser;
			target = new GameObject ("");
			target.transform.position = laserParent.transform.position;
			line.SetVertexCount (i+1); //2
			line.SetPosition (0, laser.transform.position);
			line.SetWidth (.05f, .05f);
			laser.transform.LookAt (target.transform);
			shootLine ();
		}
	}

	void shootLine(){
		nextPosition = Vector3.Lerp (source.transform.position, target.transform.position, Time.deltaTime);
		//line.SetPosition (i, target.transform.position);
		line.SetPosition (i, nextPosition);
		checkHit ();
	}
	
	void checkHit(){
		RaycastHit hit;
		Ray testRay = new Ray(source.transform.position, source.transform.position - target.transform.position);
		if(Physics.Raycast (testRay, out hit, 500)){
			//line.SetPosition(1,hit.point);
			//line.SetVertexCount(3);
			//line.SetPosition(2, (hit.point-Vector3.Reflect(testRay.direction,hit.normal)*-10));
			line.SetPosition(i,hit.point);
			line.SetVertexCount(i+2);
			line.SetPosition(i+1, (hit.point-Vector3.Reflect(testRay.direction,hit.normal)*-10));
			source.transform.position = hit.point;
			target.transform.position = Vector3.Reflect(testRay.direction,hit.normal)*-10;
			string collisionName = hit.collider.gameObject.name;
			print (collisionName);
			
			if (collisionName == "Target") {
				print ("you win");
				line.SetVertexCount(i+2);
				print (i+2);
				line.SetPosition (i+1, hit.point);
				SpriteRenderer s = hit.collider.gameObject.GetComponent<SpriteRenderer>();
				s.color = Color.green;
			}
			else if(collisionName == "Right Wall" || collisionName == "Left Wall" || collisionName == "Top Wall" ||
			   collisionName == "Bottom Wall" || collisionName == "Box1" || collisionName == "Box2" ||
			   collisionName == "Box3" || collisionName == "Box4"){
				print (collisionName);
				print ("you lose");
				line.SetVertexCount(i+2);
				line.SetPosition (i+1, hit.point);
			}
			else {
				i++;
				source.transform.LookAt (target.transform);
				shootLine ();
			}
		}
	}
}
