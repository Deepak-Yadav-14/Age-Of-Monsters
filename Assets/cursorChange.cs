using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorChange : MonoBehaviour
{
    private Image changecursor;
    public Sprite cursorIdle;
    public Sprite cursorShoot;

    void Start() {
        changecursor = GetComponent<Image>();
    }

    void Update() {

        if (Input.GetMouseButtonDown(0))
        {
            changecursor.sprite = cursorShoot;
        }else if (Input.GetMouseButtonUp(0))
        {
            changecursor.sprite = cursorIdle;
        }
    
    }
}
