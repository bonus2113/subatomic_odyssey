using UnityEngine;
using System.Collections;

public class Map {
	
	public const int TILE_WIDTH = 50;
	public const int TILE_HEIGHT = 50;
	
	
	int width;
	int height;
	GameObject tilePrefab;
	GameObject worldObj;
	
	Tile[,] tiles;
	
	public Map(int _width, int _height, GameObject _tilePrefab, GameObject _worldObj) {
		width = _width;
		height = _height;
		tilePrefab = _tilePrefab;
		worldObj = _worldObj;
		FillRandom();
	}
	
	void FillRandom() {
		tiles = new Tile[width, height];
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				if(Random.value < 0.5f) {
					Vector2 pos = new Vector2(x * TILE_WIDTH, y * TILE_HEIGHT);
					GameObject newTileObj = (GameObject)GameObject.Instantiate(tilePrefab);
					newTileObj.transform.position = pos;
					newTileObj.transform.parent = worldObj.transform;
					Tile newTile = newTileObj.GetComponent<Tile>();
					newTile.SetValues(0);
					tiles[x,y] = newTile;
				} else {
					tiles[x,y] = null;	
				}
				
			}
		}
	}
	
}
