using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_player : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (!PlayerMove.Instance.directionIsRigth)
            speed = -speed;
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag != "Player" && collision.tag != "Enemy_coll" && collision.tag != "Player_bullet")
        {
            Destroy(gameObject);
        }
    }
}
