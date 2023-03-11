using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D _rb;
    public float JumpForce;

    public bool isGroun;

    public Animator _anim;

    public GameObject LooseCanv;
    public GameObject MainCanv;

    public GameObject BulletPref;

    public float RechangeTime;
    private float Timer;

    public Transform EndPos;
    public Transform StartPos;

    private void Start()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGroun = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGroun = false;
        }
    }

    // Update is called once per frame
    public void OnJumpButton()
    {
        if (GameManager.Loosed) return;
        if (isGroun) _rb.AddForce(new Vector2(0, JumpForce));
    }

    public void OnShiftButton()
    {
        if (GameManager.Loosed) return;
        _anim.SetTrigger("isShift");
    }

    public void Loose()
    {

        GameManager.Loosed = true;
        LooseCanv.SetActive(true);
        MainCanv.SetActive(false);
    }

    public void Shoot()
    {
        if (GameManager.Loosed) return;
        if (Timer >= RechangeTime)
        {
            GameObject H = Instantiate(BulletPref, transform.position, transform.rotation);
            H.GetComponent<BulletScript>().EndPos = EndPos;
            H.GetComponent<BulletScript>().StartPos = StartPos;

            Timer = 0;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Loosed)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        Timer += Time.deltaTime;
    }
}

