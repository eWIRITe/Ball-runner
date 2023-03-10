using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D _rb;

    public float Speed;

    public GameObject BulletPref;

    private float Timer;
    public float RechargeTime;

    public Transform EndPos;
    public Transform StartPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Loose();
        }
    }


    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(Speed*-1, _rb.velocity.y);

        if(transform.position.x <= EndPos.transform.position.x)
        {
            Destroy(gameObject);
        }

        if(BulletPref != null)
        {
            Timer += Time.deltaTime;
            if (Timer >= RechargeTime)
            {
                Shot();
                Timer = 0;
            }
        }
    }

    void Shot()
    {
        GameObject H = Instantiate(BulletPref, transform.position, BulletPref.transform.rotation);

        H.GetComponent<BulletScript>().EndPos = EndPos;
        H.GetComponent<BulletScript>().StartPos = StartPos;
    }


    private void Update()
    {
        if (GameManager.Loosed) Destroy(gameObject);
    }
}
