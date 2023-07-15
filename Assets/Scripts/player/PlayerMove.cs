using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;
    public float jump;

    private bool isJump;
    public Transform GroundCheck;
    private float checkRodius = 0.1f;
    public LayerMask Ground;

    public GameObject bullet;
    private float time;

    private static PlayerMove _instance;
    public static PlayerMove Instance
        => _instance ??= new PlayerMove();

    public bool directionIsRigth = true;

    public PlayerMove()
    {
        _instance = this;
    }
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        time += Time.deltaTime;
        CheckingGround();
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            directionIsRigth = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            directionIsRigth = false;
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            rigidbody.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.W))  
        {
            if (time > 0.5f)
            {
                time = 0.0f;
                Shoot();
            }
        }
    }

    void CheckingGround()
    {
        isJump = Physics2D.OverlapCircle(GroundCheck.position, checkRodius, Ground);
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity); 
    }
}
