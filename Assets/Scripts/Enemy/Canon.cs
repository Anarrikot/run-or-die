using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public GameObject bullet;
    private float time;
    public bool isRigth;
    public bool isLeft;
    public bool isUp;
    public bool isDown;
    public float time_delay_attack;

    private static Canon _instance;
    public static Canon Instance
        => _instance ??= new Canon();

    public Canon()
    {
        _instance = this;
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > time_delay_attack)
        {
            time = 0.0f;
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        go.transform.SetParent(transform, false);
    }
}
