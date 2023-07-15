using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_box_fly : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;
    public GameObject bomb;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(Attack());
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            yield return new WaitForSeconds(2);
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bomb, transform.position, Quaternion.identity);
    }
}
