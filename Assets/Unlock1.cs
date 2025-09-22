using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock1 : MonoBehaviour
{

    private Button but;
    private Image img;
    private Image img1;

    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
        img = GameObject.FindGameObjectWithTag("Lock1").GetComponent<Image>();
        img1 = GameObject.FindGameObjectWithTag("Lock").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.totalScore >= 2)
        {
            but.interactable = true;
            img.color  = Color.clear;
            img1.color = Color.clear;
        }
        
        
        
    }
}
