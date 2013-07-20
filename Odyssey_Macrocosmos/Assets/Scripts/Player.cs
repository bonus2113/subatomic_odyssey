using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	Vector2 tilePos = Vector2.zero;
	World world;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void SetValues(Vector2 _pos, World _world) {
		SetTilePos(_pos);
		world = _world;
	}
	
	public void SetTilePos(Vector2 _pos) {
		tilePos = _pos;
		transform.position = Map.TileToWorldPos(tilePos);
	}
	
	public void SetTilePos(float _x, float _y) {
		tilePos = new Vector2(_x, _y);
		transform.position = Map.TileToWorldPos(tilePos);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
			MoveUp();
		else if(Input.GetKeyDown(KeyCode.RightArrow))
			MoveRight();
		else if(Input.GetKeyDown(KeyCode.LeftArrow))
			MoveLeft();
		else if(Input.GetKeyDown(KeyCode.DownArrow))
			MoveDown();
	
	}
	
	void MoveUp() {
		SetTilePos(tilePos.x, tilePos.y + 1);	
	}
	
	void MoveRight() {
		SetTilePos(tilePos.x + 1, tilePos.y);	
	}
	
	void MoveLeft() {
		SetTilePos(tilePos.x - 1, tilePos.y);	
	}
	
	void MoveDown() {
		SetTilePos(tilePos.x, tilePos.y - 1);	
	}
	
	
}
