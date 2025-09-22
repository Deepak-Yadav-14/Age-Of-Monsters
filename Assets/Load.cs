using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public void Start()
    {
        Score.totalScore = ES3.Load<int>("score");
        
    }
}
