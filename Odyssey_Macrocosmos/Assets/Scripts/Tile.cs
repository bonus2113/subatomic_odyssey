using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	int type;
	Vector2 pos;
	tk2dSprite sprite;
	
	public void SetValues(int _type) {
		type = _type;
	}
	
	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<tk2dSprite>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
