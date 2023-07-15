using UnityEngine;

public class bomb_move : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy" && collision.tag != "Enemy_coll")
        {
            Destroy(gameObject);
        }
    }
}

