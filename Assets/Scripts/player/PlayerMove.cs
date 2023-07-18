using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;
    public float jump;
    public GameObject weapon;

    private bool isJump;

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
        weapon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Weapon/" + Convert.ToString(PlayerInfo.Instance.ActiveWeapon()));
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            directionIsRigth = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity); 
    }
}
