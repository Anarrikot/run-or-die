using UnityEngine;

public class bullet_move : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (rigidbody.position.x - player.gameObject.transform.position.x >= 0)
            speed = -speed;
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy" && collision.tag != "Enemy_coll")
        {
            Destroy(gameObject);
        }   
    }
}

