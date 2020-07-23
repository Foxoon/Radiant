using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 12f;

    Rigidbody2D rb;
    int direction = 1;

    public bool playerBullets;
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
        float calc = speed * direction;
        rb.velocity = new Vector2(0, speed * direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.gameObject.tag == "Enemy" && playerBullets)
        {
            collision.gameObject.GetComponent<Enemy>().Damage();
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player" && !playerBullets)
        {
            collision.gameObject.GetComponent<Spaceship>().Damage();
            Destroy(gameObject);
        }
    }

    public void Change()
    {
        direction *= -1;
    }

}
