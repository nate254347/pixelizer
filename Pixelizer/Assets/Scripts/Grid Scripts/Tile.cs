using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    public Color Color { get; set; }
    public Vector2 Size { get; set; }
    public Vector2 Position { get; set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = gameObject.AddComponent<BoxCollider2D>();
    }
    void Start()
    {
        transform.position = new Vector3(Position.x, Position.y, 0);
        transform.localScale = new Vector3(Size.x, Size.y, 1f);
        GetComponent<SpriteRenderer>().color = Color;
    }

    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeColor(Color.black);
        Debug.Log("Tile Clicked!");
    }
    public void ChangeColor(Color color)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = color;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
