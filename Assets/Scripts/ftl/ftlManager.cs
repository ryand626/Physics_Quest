using UnityEngine;
using System.Collections;

public class ftlManager : MonoBehaviour 
{
	public static GUIStyle textStyle;

	void Start()
	{
		textStyle = new GUIStyle ();
		textStyle.font = (Font)Resources.Load("PAPYRUS");
		textStyle.fontSize = 24;
		textStyle.normal.textColor = new Color (1f, 1f, 1f, 1f);
	}

	public Vector3 transformToObject (Vector3 _vertex, GameObject _object)
	{
		var ratio = new Vector2 (_object.GetComponent<Collider>().bounds.size.x / Screen.width , _object.GetComponent<Collider>().bounds.size.y / Screen.height);
		_vertex.x = _object.GetComponent<Collider>().bounds.center.x + (ratio.x * _vertex.x) - _object.GetComponent<Collider>().bounds.size.x / 2;
		_vertex.y = -_object.GetComponent<Collider>().bounds.center.y + (ratio.y * _vertex.y) - _object.GetComponent<Collider>().bounds.size.y / 2;
		_vertex = Camera.main.WorldToScreenPoint (_vertex);		
		return _vertex;
	}

	public Color GetColor (int _Id , float _brightness , float _alpha)
	{
		var rFactor = 3f;
		var gFactor = 1f;
		var bFactor = 1f;
		var _color = new Color ((Mathf.Sin ((_Id * 71f) + 17)), (Mathf.Sin ((_Id * 19f) - 25)), (Mathf.Sin ((_Id + 5) * 23f)), 1f);
		_color = new Color (rFactor * _brightness * _color.r , gFactor * _brightness * _color.g , bFactor * _brightness * _color.b , _alpha);
		
		return _color;
	}
}
