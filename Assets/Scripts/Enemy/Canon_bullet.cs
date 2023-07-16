using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_bullet : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;
    private Vector2 direction;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
       
        if (transform.parent.GetComponent<Canon>().isRigth)
            direction = new Vector2(speed, rigidbody.velocity.y);
        else if (transform.parent.GetComponent<Canon>().isLeft)
            direction = new Vector2(-speed, rigidbody.velocity.y);
        else if (transform.parent.GetComponent<Canon>().isUp)
            direction = new Vector2(rigidbody.velocity.x, speed);
        else if (transform.parent.GetComponent<Canon>().isDown)
            direction = new Vector2(rigidbody.velocity.x, -speed);
    }

    void Update()
    {
        rigidbody.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy" && collision.tag != "Enemy_coll")
        {
            Destroy(gameObject);
        }
    }
}
