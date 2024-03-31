using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandingPageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject panel1;
    public void PanelToggle()
    {
        if (panel1.activeInHierarchy == false)
        {
            panel1.SetActive(true);
        }
        else
        {
            panel1.SetActive(false);
        }
        //bool toggle = true;
        //toggle = !toggle;
        //if (toggle)
        //    panel.SetActive(true);
    }
}
