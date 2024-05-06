using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingBoard : MonoBehaviour
{
    public struct TileData
    {
        public Vector2 position; // Location Of Tile
        public Color color;// Color of Tile
        public Vector2 size; // And Size of the tile
    }
    public List<TileData> tileDataList= new List<TileData>();
    public List<List<GameObject>> drawingBoard = new List<List<GameObject>>();

    public void InitializeDrawingBoard(int width,int height) 
    {

        drawingBoard.Clear();
        drawingBoard.Resize(width);
        
        for (int i = 0; i < width; i++) 
        {
            drawingBoard[i] = new List<GameObject>();
            drawingBoard[i].Resize(height);
        }
    }
    public void AddTileData(Vector2 position, Color color,Vector2 size)
    {
        TileData tileData;
        tileData.position = position;
        tileData.color = color; 
        tileData.size = size;
        tileDataList.Add(tileData);
    }

    public List<TileData>GetTileDataList()
    {
        return tileDataList;
    }

    public List<List<GameObject>> GetDrawingBoard() 
    {
        return drawingBoard;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
