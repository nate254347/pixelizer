using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private DrawingBoard _drawingBoard;
    [SerializeField]private int gridSizeX;
    [SerializeField] private int gridSizeY;
    [SerializeField] int tileCount;

    [SerializeField] private RectTransform drawingBoardPanel;
    float cellWidth;
    float cellHeight;

    void Start()
    {
        _drawingBoard.InitializeDrawingBoard(gridSizeX, gridSizeY);
        GenerateGrid();
    }

    void GenerateGrid()
    { 
        CalculateCellSize();

        Vector3 bottomLeftCorner = drawingBoardPanel.rect.min;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 position = bottomLeftCorner + new Vector3( x * cellWidth, y * cellHeight,0);
              
                GameObject tileObject = Instantiate(_tilePrefab,position, Quaternion.identity);
                Tile tile = tileObject.GetComponent<Tile>();

                tile.Position = new Vector2(x * cellWidth, y * cellHeight);
                tile.Color = Color.white;
                tile.Size = new Vector2(cellWidth, cellHeight);

                _drawingBoard.AddTileData(tile.Position, tile.Color,tile.Size);
                tileObject.transform.SetParent(drawingBoardPanel,false);
                     ++tileCount;

            }

        }

    }

    void CalculateCellSize() 
    {
        cellWidth = drawingBoardPanel.rect.width / gridSizeX;
        cellHeight = drawingBoardPanel.rect.height / gridSizeY;
    }
    public void SetGridSize(int width , int height)
    {
        gridSizeX = width;
        gridSizeY = height;
        _drawingBoard.InitializeDrawingBoard(gridSizeX,gridSizeY);
        GenerateGrid();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // Calculate the clicked tile's position in the grid
        Vector2 clickPosition = eventData.position;
        int xIndex = Mathf.FloorToInt((clickPosition.x / drawingBoardPanel.rect.width) * gridSizeX);
        int yIndex = Mathf.FloorToInt((clickPosition.y / drawingBoardPanel.rect.height) * gridSizeY);
        
        yIndex = gridSizeY - 1 - yIndex;

        //change color // Add Color 
        _drawingBoard.GetDrawingBoard()[xIndex][yIndex].TryGetComponent<SpriteRenderer>(out SpriteRenderer sr);
        sr.color = Color.black;

        // Update the drawing board
        GameObject currentValue = _drawingBoard.GetDrawingBoard()[xIndex][yIndex];
        _drawingBoard.GetDrawingBoard()[xIndex][yIndex] = currentValue;

        GenerateGrid();
    }

    void Update()
    {
       if (drawingBoardPanel.hasChanged) 
        {
            CalculateCellSize();
            GenerateGrid();
            drawingBoardPanel.hasChanged = false;
          
        }

    }
 
}