using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	public GameObject TilePrefab;
	
	Map map;
	// Use this for initialization
	void Start () {
		map = new Map(50, 50, TilePrefab, gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
