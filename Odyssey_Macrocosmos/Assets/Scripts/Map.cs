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
		DepthSorter.MAX_Y = height * TILE_SIZE;
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
		PerlinNoise noise = new PerlinNoise(1);
		tiles = new Tile[width, height];
		float widthDivisor = 10.0f / (float)width;
    	float heightDivisor = 10.0f / (float)height;
		
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				
				float val =
	                // First octave
	                (noise.Noise(2 * x * widthDivisor, 2 * y * heightDivisor, -0.5f) + 1) / 2 * 0.7f +
	                // Second octave
	                (noise.Noise(4 * x * widthDivisor, 4 * y * heightDivisor, 0) + 1) / 2 * 0.2f +
	                // Third octave
	                (noise.Noise(8 * x * widthDivisor, 8 * y * heightDivisor, +0.5f) + 1) / 2 * 0.1f;
					
				if(val < 0.47f) {
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
