using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMoover : MonoBehaviour
{
    public static float Speed = 3;

    public Transform StartPos;
    public Transform EndPos;

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
    }

    private void Update()
    {
        if(transform.position.x <= EndPos.position.x)
        {
            GameObject.Find("Scenes").GetComponent<SceneSpawnScript>().SpawnNextPlatform();

            Destroy(gameObject);
        }

        if (GameManager.Loosed) Speed = 0;
    }
}
