using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float speed = 20;

    // Start is called before the first frame update
    float health = 3;

    GameObject g1, g2, g3, g4, g5, g6, g7;
    public GameObject bullet;

    float firerate = 0.2f;
    int reloadTime;
    int delay;


    private void Awake()
    {
        reloadTime = (int)(1f / firerate);
        delay = reloadTime;
        rb = GetComponent<Rigidbody2D>();

        g1 = transform.Find("gun1").gameObject;
        g2 = transform.Find("gun2").gameObject;
        g3 = transform.Find("gun3").gameObject;
        g4 = transform.Find("gun4").gameObject;
        g5 = transform.Find("gun5").gameObject;
        g6 = transform.Find("gun6").gameObject;
        g7 = transform.Find("gun7").gameObject;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") *  speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));


        delay++;
        if (Input.GetKey(KeyCode.Space) && delay> reloadTime)
        {
            Shoot();
            delay = 0;
        }
    }


    public void Damage()
    {
        health--;

        Die();
        if (health == 0)
        {
            //gameover
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Shoot()
    {
        //ADD SHOOTING PATTERN
        GameObject inst = Instantiate(bullet, g1.transform.position, Quaternion.identity);
        inst.transform.GetComponent<Bullet>().playerBullets = true;
    }

    
}


