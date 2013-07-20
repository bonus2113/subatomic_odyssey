using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	public GameObject TilePrefab;
	
	public GameObject PlayerObj;
	
	Player player;
	Map map;
	
	// Use this for initialization
	void Start () {
		map = new Map(50, 50, TilePrefab, gameObject);
		player = PlayerObj.GetComponent<Player>();
		player.SetValues(map.GetFirstFreeTile(), this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
