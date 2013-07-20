using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	public GameObject TilePrefab;
	
	public GameObject PlayerObj;
	
	public Player Player;
	public Map Map;
	
	// Use this for initialization
	void Start () {
		Map = new Map(50, 50, TilePrefab, gameObject);
		Player = PlayerObj.GetComponent<Player>();
		Player.SetValues(Map.GetFirstFreeTile(), this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
