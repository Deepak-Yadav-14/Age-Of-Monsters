using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;
    private int halfHealth;
    private Animator anim;
    public int damage;
    public GameObject crack;
    public float crackoffset;
    public GameObject bossSplash;
    public GameObject bossDeath;
    private Slider healthbar;
    private Animator cameraAnim;
    private SceneTransition Transition;

    



    private void Start() {
        halfHealth =health / 2;
        anim = GetComponent<Animator>();
        healthbar = FindObjectOfType<Slider>();
        healthbar.maxValue = health;
        healthbar.value = health;
        cameraAnim = GameObject.FindGameObjectWithTag("Camera").GetComponent<Animator>();
        Transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<SceneTransition>();
        
    }

    public void TakeDamage(int DamageAmount)
    {
        health -= DamageAmount;
        healthbar.value = health;
        if (health <= 0)
        {
            Instantiate(bossDeath, transform.position, Quaternion.identity);
            Instantiate(bossSplash, transform.position, Quaternion.identity);
            Destroy(gameObject);
            healthbar.gameObject.SetActive(false);
            cameraAnim.SetBool("Quake", false);
            Transition.LoadScene("You Win");
            
        }
        if (health <= halfHealth)
        {
            anim.SetTrigger("Stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0,enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset,spawnOffset,0), transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

    public void Crack()
    {
        Instantiate(crack, transform.position + new Vector3(0,crackoffset,0), transform.rotation);
        cameraAnim.SetBool("Quake", true);
    }


}
