using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float fireRate;

    [SerializeField]
    float speedX = 5;

    [SerializeField]
    float speedY = 5;

    float health = 1;
    bool canShoot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
        //(-9.3,5), (-9.3, -5)
        //if enemy intersect with box then shoot
        rb.velocity = new Vector2(speedX, speedY*-1);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }
    }

    public void Damage()
    {
        health--;
        if(health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
    private void Shoot()
    {
        //ADD SHOOTING PATTERN
    }
}
