using System;
using TouchScript;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
// TODO: split this into two different scripts, one that handles the on/off, and the other that handles the game logic


public class OnOffLaser : MonoBehaviour {
	public GameObject uitray;
	public Sprite onLaser;
	public Sprite offLaser;
	private Image currImage;
	public bool isOn;

	public GameObject laser;
	public GameObject laserParent;
	private GameObject source;
	private GameObject target;
	public LineRenderer line;
	public Vector3 nextPosition;
	public int bounceNumber;
	private int i;
	private ArrayList boxLocations;
	private ArrayList boxSprites;
	private int config;
	private int failedAttempts;
	
	// Use this for initialization
	void Start () {
		i = 1;
		failedAttempts = 0;
		createBoxConfigurations ();
		config = UnityEngine.Random.Range(0, boxLocations.Count);
		loadBoxConfig (config);
		////GetComponent<TapGesture>().StateChanged += tapHandler;
		currImage = uitray.GetComponent<Image>();
		isOn = false;
		//line = gameObject.AddComponent<LineRenderer> ();
		gameObject.AddComponent<LineRenderer> ();
		line = gameObject.GetComponent<LineRenderer> ();
		bounceNumber = 1;
		source = laser;
		target = new GameObject ("");
	}

	private void createBoxConfigurations() {
		boxLocations = new ArrayList ();
		boxSprites = new ArrayList ();

		Vector3[] boxConfig1 = new Vector3[5];
		boxConfig1 [0] = new Vector3 (-1.980841f, -3.295459f, -2.755306f); //Box1 -2.755306f
		boxConfig1 [1] = new Vector3 (0.1980841f, -1.790368f, -2.755306f); //Box2
		boxConfig1 [2] = new Vector3 (2.37701f, -0.5115336f, -2.755306f); //Box3
		boxConfig1 [3] = new Vector3 (-1.980841f, 3.292453f, -2.755306f); //Box4
		boxConfig1 [4] = new Vector3 (5.5f, 3.7f, 0); //last vector3 is where target goes

		string[] boxSprites1 = new string[5];
		boxSprites1 [0] = "BOX1"; //Box1
		boxSprites1 [1] = "BOX2"; //Box2
		boxSprites1 [2] = "BOX1"; //Box3
		boxSprites1 [3] = "BOX4"; //Box4
		boxSprites1 [4] = "TARGET"; //Target

		Vector3[] boxConfig2 = new Vector3[5];
		boxConfig2 [0] = new Vector3 (-3f, 0, -2.755306f);
		boxConfig2 [1] = new Vector3 (-1.3f, 1f, -2.755306f);
		boxConfig2 [2] = new Vector3 (2.37701f, -0.5115336f, -2.755306f);
		boxConfig2 [3] = new Vector3 (2f, 2f, -2.755306f);
		boxConfig2 [4] = new Vector3 (0f, -1.7f, 0); //last vector3 is where target goes

		string[] boxSprites2 = new string[5];
		boxSprites2 [0] = "BOX1"; //Box1
		boxSprites2 [1] = "BOX2"; //Box2
		boxSprites2 [2] = "BOX1"; //Box3
		boxSprites2 [3] = "BOX4"; //Box4
		boxSprites2 [4] = "TARGET"; //Target

		Vector3[] boxConfig3 = new Vector3[5];
		boxConfig3 [0] = new Vector3 (-4f, 3f, -2.755306f);
		boxConfig3 [1] = new Vector3 (2f, 0.8f, -2.755306f);
		boxConfig3 [2] = new Vector3 (4f, -3f, -2.755306f);
		boxConfig3 [3] = new Vector3 (-1f, 1f, -2.755306f);
		boxConfig3 [4] = new Vector3 (0, 0, 0); //last vector3 is where target goes

		string[] boxSprites3 = new string[5];
		boxSprites3 [0] = "BOX1"; //Box1
		boxSprites3 [1] = "BOX2"; //Box2
		boxSprites3 [2] = "BOX1"; //Box3
		boxSprites3 [3] = "BOX4"; //Box4
		boxSprites3 [4] = "TARGET"; //Target

		Vector3[] boxConfig4 = new Vector3[5];
		boxConfig4 [0] = new Vector3 (-5f, -1f, -2.755306f);
		boxConfig4 [1] = new Vector3 (2f, 2.8f, -2.755306f);
		boxConfig4 [2] = new Vector3 (-1f, 0f, -2.755306f);
		boxConfig4 [3] = new Vector3 (2f, -3f, -2.755306f);
		boxConfig4 [4] = new Vector3 (-5.7f, -2.3f, 0); //last vector3 is where target goes

		string[] boxSprites4 = new string[5];
		boxSprites4 [0] = "BOX1"; //Box1
		boxSprites4 [1] = "BOX2"; //Box2
		boxSprites4 [2] = "BOX1"; //Box3
		boxSprites4 [3] = "BOX4"; //Box4
		boxSprites4 [4] = "TARGET"; //Target

		Vector3[] boxConfig5 = new Vector3[5];
		boxConfig5 [0] = new Vector3 (-3f, 2f, -2.755306f);
		boxConfig5 [1] = new Vector3 (5f, 1f, -2.755306f);
		boxConfig5 [2] = new Vector3 (1f, 2.4f, -2.755306f);
		boxConfig5 [3] = new Vector3 (2f, -1f, -2.755306f);
		boxConfig5 [4] = new Vector3 (0f, 1f, 0); //last vector3 is where target goes
		
		string[] boxSprites5 = new string[5];
		boxSprites5 [0] = "BOX1"; //Box1
		boxSprites5 [1] = "BOX2"; //Box2
		boxSprites5 [2] = "BOX5"; //Box3
		boxSprites5 [3] = "BOX4"; //Box4
		boxSprites5 [4] = "TARGET"; //Target

		boxLocations.Add (boxConfig1);
		boxLocations.Add (boxConfig2);
		boxLocations.Add (boxConfig3);
		boxLocations.Add (boxConfig4);
		boxLocations.Add (boxConfig5);

		boxSprites.Add (boxSprites1);
		boxSprites.Add (boxSprites2);
		boxSprites.Add (boxSprites3);
		boxSprites.Add (boxSprites4);
		boxSprites.Add (boxSprites5);
	}

	private void loadBoxConfig(int config) {
		// Remove old box config if it exists
		if (GameObject.Find ("Box1") != null) {
			Destroy(GameObject.Find ("Box1"));
		}
		if (GameObject.Find ("Box2") != null) {
			Destroy(GameObject.Find ("Box2"));
		}
		if (GameObject.Find ("Box3") != null) {
			Destroy(GameObject.Find ("Box3"));
		}
		if (GameObject.Find ("Box4") != null) {
			Destroy(GameObject.Find ("Box4"));
		}

		// Load new box/target config
		Vector3[] boxConfig = (Vector3[])boxLocations [config];
		string[] boxTypes = (string[])boxSprites [config];
		for (int i = 0; i < boxConfig.Length; i++) {
			if(boxTypes[i] == "BOX1") {
				GameObject box = (GameObject)Instantiate(Resources.Load("Prefabs/Mirror/Box1"));
				box.transform.parent = GameObject.Find("Background").transform;
				box.transform.localScale = new Vector3(1f,1f,1f);
				box.transform.localPosition = boxConfig[i];
				int boxNum = i + 1;
				box.name = "Box" + boxNum;
			}
			if(boxTypes[i] == "BOX2") {
				GameObject box = (GameObject)Instantiate(Resources.Load("Prefabs/Mirror/Box2"));
				box.transform.parent = GameObject.Find("Background").transform;
				box.transform.localPosition = boxConfig[i];
				box.transform.localScale = new Vector3(1f,1f,1f);
				int boxNum = i + 1;
				box.name = "Box" + boxNum;
			}
			if(boxTypes[i] == "BOX4") {
				GameObject box = (GameObject)Instantiate(Resources.Load("Prefabs/Mirror/Box4"));
				box.transform.parent = GameObject.Find("Background").transform;
				box.transform.localPosition = boxConfig[i];
				box.transform.localScale = new Vector3(1f,1f,1f);
				int boxNum = i + 1;
				box.name = "Box" + boxNum;
			}
			if(boxTypes[i] == "BOX5") {
				GameObject box = (GameObject)Instantiate(Resources.Load("Prefabs/Mirror/Box5"));
				box.transform.parent = GameObject.Find("Background").transform;
				box.transform.localPosition = boxConfig[i];
				box.transform.localScale = new Vector3(1f,1f,1f);
				int boxNum = i + 1;
				box.name = "Box" + boxNum;
			}
			if(boxTypes[i] == "TARGET") {
				GameObject target = GameObject.Find ("Target");
				target.transform.position = boxConfig[i];
			}
		}
	}

	private void OnEnable()
	{
		GetComponent<TapGesture> ().Tapped += tapHandler;
	}
	private void OnDisable()
	{
		if (this.enabled) {
			GetComponent<TapGesture> ().Tapped -= tapHandler;
		}
	}

	private void tapHandler(object sender, EventArgs e)
	{
		if (!isOn) {
			isOn = true;
			currImage.sprite = onLaser;
			laser = GameObject.Find ("Pink Laser Tip");
			laser.transform.parent = laserParent.transform;
			laser.transform.localPosition = new Vector3(0,.37f,0);
			source = laser;
			source.transform.position = laser.transform.position;
			laserParent = GameObject.Find ("Pink Laser");
			//target = new GameObject ("");
			target.transform.position = laserParent.transform.position;
			line.SetVertexCount (i+1); //2
			line.SetPosition (0, laser.transform.position);
			line.SetWidth (.05f, .05f);
			laser.transform.LookAt (target.transform);
			shootLine ();
		}
		else {
			isOn = false;
			currImage.sprite = offLaser;
			i = 1;
			line.SetVertexCount (i);
		}
	}

	void shootLine(){
		nextPosition = Vector3.Lerp (source.transform.position, target.transform.position, Time.deltaTime);
		//line.SetPosition (i, target.transform.position);
		line.SetPosition (i, nextPosition); //potentially can be deleted, not positive
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
			
			if (collisionName == "Target") {
				print ("you win");
				line.SetVertexCount(i+2);
				line.SetPosition (i+1, hit.point);
				SpriteRenderer s = hit.collider.gameObject.GetComponent<SpriteRenderer>();
				s.color = Color.green;

				failedAttempts = 0;
				Application.LoadLevel(2); //temporary
				//config = UnityEngine.Random.Range(0, boxLocations.Count);
				//loadBoxConfig(config);
				//i = 1;
				//isOn = false;
				// load new box config and switch players
			}
			else if(collisionName == "Right Wall" || collisionName == "Left Wall" || collisionName == "Top Wall" ||
			   collisionName == "Bottom Wall" || collisionName == "Box1" || collisionName == "Box2" ||
			        collisionName == "Box3" || collisionName == "Box4"){
				print (collisionName);
				print ("you lose");
				line.SetVertexCount(i+2);
				line.SetPosition (i+1, hit.point);
				failedAttempts++;
				if(failedAttempts == 3) {
					//move to next player
					failedAttempts = 0;
					config = UnityEngine.Random.Range(0, boxLocations.Count);
					loadBoxConfig(config);
					i = 1;
					//line.SetVertexCount(i); if you have this line in, the last attempt laser won't show
					isOn = false;
					currImage.sprite = offLaser;
					Application.LoadLevel(2);
				}
				else {
					//keep mirrors in their places
				}
			}
			else {
				i++;
				source.transform.LookAt (target.transform);
				shootLine ();
			}
		}
	}	
}
