using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;

    public Rigidbody2D _rb;

    public GameObject HitAnimPref;

    public bool PlayerShot;

    public Transform EndPos;
    public Transform StartPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerShot)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                if(HitAnimPref != null) Instantiate(HitAnimPref, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerScript>().Loose();
                if (HitAnimPref != null) Instantiate(HitAnimPref, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {

        if (transform.position.x <= EndPos.transform.position.x || transform.position.x >= StartPos.transform.position.x)
        {
            Destroy(gameObject);
        }

        _rb.velocity = new Vector2(Speed * -1, _rb.velocity.y);
    }

    private void Update()
    {
        if (GameManager.Loosed) Destroy(gameObject);
    }
}
