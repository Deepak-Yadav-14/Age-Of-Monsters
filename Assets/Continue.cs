using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    private SceneTransition Transition;
    public string sceneName;

    void Start() {
        Transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<SceneTransition>();
    }
    public void Update(){
        
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Transition.LoadScene(sceneName);
        }
    }

}
