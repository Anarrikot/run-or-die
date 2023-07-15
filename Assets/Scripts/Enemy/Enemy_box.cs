using System.Collections;
using UnityEngine;

public class Enemy_box : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;
    public GameObject bullet;
    private float time;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Run(collision);
            if (time > 2.0f)
            {
                time = 0.0f;
                Shoot();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Run(collision);
            if (time > 2.0f)
            {
                time = 0.0f;
                Shoot();
            }
        }
    }

    public void Run(Collider2D collision)
    {
        if (rigidbody.position.x - collision.gameObject.transform.position.x >= 0)
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
        else
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}

