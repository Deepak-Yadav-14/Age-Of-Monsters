using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{

    private Button but;
    private Image img;
        // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
        img = GameObject.FindGameObjectWithTag("Lock").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.totalScore >= 1)
        {
            but.interactable = true;
            img.color  = Color.clear;
        }
        
        
        
    }
}
