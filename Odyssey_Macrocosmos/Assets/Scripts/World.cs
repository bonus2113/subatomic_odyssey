using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {
	
	class MapNode {
		public int Seed;
		public List<MapNode> Children;
		public MapNode Parent;
	}
	
	public GameObject TilePrefab;
	public GameObject BoxPrefab;
	public GameObject PlayerObj;
	
	public Player Player;
	public Map Map;
	
	private MapNode current;
	
	// Use this for initialization
	void Start () {
		Map = new Map(50, 50, gameObject, this);
		GoDown();
	}
	
	public void GoDown() {
		Random.seed = (int)(Time.renderedFrameCount * System.DateTime.Now.Ticks);
		int newSeed = (int)(Random.value * int.MaxValue);
		
		MapNode last = current;
		current = new MapNode();
		current.Seed = newSeed;
		current.Parent = last;
		current.Children = new List<MapNode>();
		if(last != null)
			last.Children.Add(current);
		
		Map.Reset(current.Seed);
		
		Player = PlayerObj.GetComponent<Player>();
		Player.SetValues(Map.GetFirstFreeTile(), this);
	}
	
	public void GoUp() {
		if(current.Parent != null) {
			current = current.Parent;
			Map.Reset(current.Seed);	
			Player = PlayerObj.GetComponent<Player>();
			Player.SetValues(Map.GetFirstFreeTile(), this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Map.IsBoxPos(Player.GetTilePos()))
			GoDown();
	}
}
