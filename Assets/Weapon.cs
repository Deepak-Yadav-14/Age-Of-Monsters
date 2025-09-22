using UnityEngine;

public class Weapon : MonoBehaviour
{
	private Joystick joystick;
	public GameObject projectile;
    public Transform shotPoint;
    public float TimeBtwShots;
    private float ShotTime;
    Animator cameraAnim;

	void Start() {
        cameraAnim = GameObject.FindGameObjectWithTag("Camera").GetComponent<Animator>();
		joystick = GameObject.FindGameObjectWithTag("RightJoystick").GetComponent<Joystick>();
    }
	void Update()
	{
		// Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
		// float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		// Quaternion rotation = Quaternion.AngleAxis(angle- 90, Vector3.forward);
		// transform.rotation = rotation;
		Vector3 moveVector = (Vector3.up * joystick.Vertical - Vector3.left * joystick.Horizontal);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }

		if (joystick.Horizontal > 0.2f || joystick.Vertical >= 0.2f || joystick.Horizontal <= -0.2f || joystick.Vertical <= -0.2f)
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
