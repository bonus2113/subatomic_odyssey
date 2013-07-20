using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	Vector2 tilePos = Vector2.zero;
	World world;
	
	float walkTimer = 0;
	const float WALK_TIME = 0.5f;
	
	tk2dSpriteAnimator anim;
	
	Vector2 nextTilePos = Vector2.zero;
	
	enum State {
		Standing,
		Walking
	}
	
	State state = State.Standing;
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<tk2dSpriteAnimator>();
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
	
	public void MoveTo(Vector2 _tile) {
		nextTilePos = _tile;
		walkTimer = WALK_TIME;
		if(state != State.Walking)
			anim.Play("Walk");
		state = State.Walking;
	}
	
	public Vector2 GetTilePos() {
		return tilePos;	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(state == State.Standing) {
			CheckKeys();
		} else {
			walkTimer -= Time.deltaTime;
			transform.position = Vector2.Lerp(tilePos * Map.TILE_SIZE, nextTilePos * Map.TILE_SIZE, (WALK_TIME - walkTimer)/WALK_TIME);
			
			if(walkTimer <= 0)
			{
				SetTilePos(nextTilePos);
				CheckKeys();
				if(state == State.Standing)
					anim.Play("Idle");
			}
		}
	
	}
	
	void CheckKeys() {
		if(Input.GetKey(KeyCode.UpArrow))
			MoveUp();
		else if(Input.GetKey(KeyCode.RightArrow))
			MoveRight();
		else if(Input.GetKey(KeyCode.LeftArrow))
			MoveLeft();
		else if(Input.GetKey(KeyCode.DownArrow))
			MoveDown();
		else
			state = State.Standing;
	}
	
	
	void MoveUp() {
		Vector2 newPos = new Vector2(tilePos.x, tilePos.y + 1);
		if(world.Map.IsTileFree(newPos))
			MoveTo(newPos);	
	}
	
	void MoveRight() {
		Vector2 newPos = new Vector2(tilePos.x + 1, tilePos.y);
		if(world.Map.IsTileFree(newPos))
			MoveTo(newPos);	
	}
	
	void MoveLeft() {
		Vector2 newPos = new Vector2(tilePos.x - 1, tilePos.y);
		if(world.Map.IsTileFree(newPos))
			MoveTo(newPos);	
	}
	
	void MoveDown() {
		Vector2 newPos = new Vector2(tilePos.x, tilePos.y - 1);
		if(world.Map.IsTileFree(newPos))
			MoveTo(newPos);	
	}
	
	
}
