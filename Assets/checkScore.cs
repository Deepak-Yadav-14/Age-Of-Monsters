using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class checkScore : MonoBehaviour
{

    public void check()
    {
        for (var i = 0; i < 1; i++)
        {
            Score.totalScore += 1;
        }
        
    }

}
