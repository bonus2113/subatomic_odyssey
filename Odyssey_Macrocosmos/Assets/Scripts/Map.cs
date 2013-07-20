using UnityEngine;
using System.Collections;

public class Map {
	
	public const int TILE_SIZE = 64;	
	
	int width;
	int height;
	GameObject tilePrefab;
	GameObject worldObj;
	
	Vector2 freePos = Vector2.zero;
	
	Tile[,] tiles;
	
	public static Vector2 TileToWorldPos(Vector2 _tile) {
		return _tile * TILE_SIZE;
	}
	
	public static Vector2 WorldToTilePos(Vector2 _world) {
		return _world / TILE_SIZE;	
	}
	
	public Map(int _width, int _height, GameObject _tilePrefab, GameObject _worldObj) {
		width = _width;
		height = _height;
		tilePrefab = _tilePrefab;
		worldObj = _worldObj;
		FillRandom();
	}
	
	public bool IsTileFree(Vector2 _pos) {
		int x = (int)_pos.x;
		int y = (int)_pos.y;
		if( x < 0 || x >= width || y < 0 || y >= height)
			return false;
		
		return tiles[x, y] == null;	
	}
	
	public Vector2 GetFirstFreeTile() {
		return freePos;
	}
	
	void FillRandom() {
		tiles = new Tile[width, height];
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				if(Random.value < 0.5f) {
					Vector2 pos = new Vector2(x, y) * TILE_SIZE;
					GameObject newTileObj = (GameObject)GameObject.Instantiate(tilePrefab);
					newTileObj.transform.position = pos;
					newTileObj.transform.parent = worldObj.transform;
					Tile newTile = newTileObj.GetComponent<Tile>();
					newTile.SetValues(0);
					tiles[x,y] = newTile;
				} else {
					if(freePos == Vector2.zero)
						freePos = new Vector2(x, y);
					tiles[x,y] = null;	
				}
				
			}
		}
	}
	
}
