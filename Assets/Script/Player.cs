using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator animator;
    public SceneTransition Transition;
    public string sceneName;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Animator hurtAnim;
    public GameObject dead;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(joystick.Horizontal,joystick.Vertical);
        moveAmount = moveInput.normalized * speed;

        //Run Animation
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("canRun", true);

        }else
        {
            animator.SetBool("canRun" , false);
        }
    }
    void FixedUpdate() {
        
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int DamageAmount)
    {
        health -= DamageAmount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("Hurt");
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(dead, transform.position, transform.rotation);
            Transition.LoadScene(sceneName);

        }
    }

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, transform.position, transform.rotation, transform);
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if (health + healAmount > 5)
        {
            health = 5;
        }else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }
}
