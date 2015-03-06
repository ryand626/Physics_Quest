using UnityEngine;
using System.Collections;

// Adapted from http://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/2d-scrolling-backgrounds

public class BackgroundParallax : MonoBehaviour {
	public float scrollSpeed;
	public int scrollDirection;

	private float tile_width;
	private float left_border;
	private float right_border;
	
	private Vector3 offset;
	
	void Start ()
	{
		tile_width = GetComponent<Renderer>().bounds.size.x;
		left_border = tile_width * -1f;
		right_border = tile_width;
	}
	
	void Update ()
	{
		offset = Vector3.right * scrollDirection * scrollSpeed * Time.deltaTime;
		transform.position = transform.position + offset;

		if (transform.position.x < left_border) {
			transform.position = new Vector3(right_border,transform.position.y,transform.position.z);
		}
		if (transform.position.x > right_border) {
			transform.position = new Vector3(left_border, transform.position.y,transform.position.z);
		}
	}
}
