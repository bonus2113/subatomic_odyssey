using UnityEngine;
using System.Collections;

public class DepthSorter : MonoBehaviour {
	public static float MAX_Y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y / MAX_Y);
	}
}
