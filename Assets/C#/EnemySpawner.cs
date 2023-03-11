using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float TimeToNextSpawn;
    private float Timer;

    public GameObject EnemyPrefab;

    public Transform EndPos;
    public Transform StartPos;

    private void FixedUpdate()
    {
        if (GameManager.Loosed) return;

        Timer += Time.deltaTime;
        if (Timer >= TimeToNextSpawn)
        {
            GameObject H = Instantiate(EnemyPrefab, transform.position, transform.rotation);
            H.GetComponent<EnemyScript>().StartPos = StartPos;
            H.GetComponent<EnemyScript>().EndPos = EndPos;

            Timer = 0;
        }
    }
}
