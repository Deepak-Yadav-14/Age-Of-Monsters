using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weaponpc : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float TimeBtwShots;
    private float ShotTime;
    Animator cameraAnim;

    void Start() {
        cameraAnim = GameObject.FindGameObjectWithTag("Camera").GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;   

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= ShotTime)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation );
                cameraAnim.SetTrigger("Shake");
                ShotTime = Time.time + TimeBtwShots ;
            }
        }
    }

}
