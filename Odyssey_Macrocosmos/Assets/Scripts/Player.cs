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
	
	public Vector2 GetTilePos() {
		return tilePos;	
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
		Vector2 newPos = new Vector2(tilePos.x, tilePos.y + 1);
		if(world.Map.IsTileFree(newPos))
			SetTilePos(newPos);	
	}
	
	void MoveRight() {
		Vector2 newPos = new Vector2(tilePos.x + 1, tilePos.y);
		if(world.Map.IsTileFree(newPos))
			SetTilePos(newPos);	
	}
	
	void MoveLeft() {
		Vector2 newPos = new Vector2(tilePos.x - 1, tilePos.y);
		if(world.Map.IsTileFree(newPos))
			SetTilePos(newPos);	
	}
	
	void MoveDown() {
		Vector2 newPos = new Vector2(tilePos.x, tilePos.y - 1);
		if(world.Map.IsTileFree(newPos))
			SetTilePos(newPos);	
	}
	
	
}
