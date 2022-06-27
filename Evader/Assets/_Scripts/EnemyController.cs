using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyLaser;
    public Transform firePoint;
    public float shotDelay= 0.5f;
    float shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        shotTimer = shotDelay;
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer-=Time.deltaTime;
        if(shotTimer< 0.0f){
            shotTimer = shotDelay;
            Instantiate(enemyLaser, firePoint.position, firePoint.rotation);
        }
        
    }
}
