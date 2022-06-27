using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameController gc;
    Rigidbody2D rb;
    public float speed = 8.0f;
    public Transform upperLeftLimit;
    public Transform lowerRightLimit;
    Animator anim;
    public GameObject laserShot; // Prefab player laser to instantiate
    public Transform firePoint; // where to create the player laser
    public GameObject LaserHit;

    public float shotDelay = 0.4f;
    float shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shotTimer = shotDelay;
        gc = FindObjectOfType<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2( Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        rb.velocity = moveInput *speed;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, upperLeftLimit.position.x, lowerRightLimit.position.x),
            Mathf.Clamp(transform.position.y, lowerRightLimit.position.y, upperLeftLimit.position.y));
        anim.SetFloat("PlayerMovement", Input.GetAxisRaw("Vertical"));

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserShot, firePoint.position, firePoint.rotation);
        }
        if(Input.GetButton("Fire1"))
        {
            shotTimer-= Time.deltaTime;
            if(shotTimer<=0)
            {
                Instantiate(laserShot, firePoint.position, firePoint.rotation);
                shotTimer = shotDelay;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player hit by "+other.gameObject.tag);
        if(other.gameObject.tag == "EnemyLaser"){
            //decrease health/life
            gc.loseLife();
            //destroy other
            Destroy(other.gameObject);
        }
    }
}
