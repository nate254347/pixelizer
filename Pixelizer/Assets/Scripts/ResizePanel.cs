using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizePanel : MonoBehaviour
{
    // Reference to the panel RectTransform
    [SerializeField] private RectTransform panelRect;

    public void SetPanelSize(Vector2 newSize) 
    {
        panelRect.sizeDelta = newSize;
        Refresh();
    }

    private void Refresh() 
    {
        panelRect.gameObject.SetActive(false);
        panelRect.gameObject.SetActive(true);
    }

    
}
    

