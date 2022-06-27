using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLaserController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject laserHit;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        // tex.text = "Points: "+points.ToString();
        transform.position = new Vector3(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y,
            transform.position.z
            );
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player laser collided with " +other.tag);
        //set particle system 'stop action' to Destroy to destroy effect after
        Instantiate(laserHit, transform.position, transform.rotation);
        Destroy(gameObject); //laser
        //Add Rigidboyd and Colider to Asteroid and Tag 'asteroid'
        if(other.tag == "Asteroid")
        {
            //Destroy (collision.gameObject);
            //Get the location(transform) where the collision occured and
            Instantiate(laserHit, transform.position, transform.rotation);
            Destroy(gameObject);
            //Set Particle Systme to "Stop Action" to Destroy to destroy effects

        }
        //Add TriggerCollier and RigidBody to Enemy Ship and add tag 'Enenmy'
        if(other.tag == "Enemy")
        {
            //Destroy(collision.gameObject); // Destroy th other game object
            //Get the location (transform) where the collision occured
            Instantiate(laserHit, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
    }
}