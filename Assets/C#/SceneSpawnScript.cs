using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpawnScript : MonoBehaviour
{
    public List<GameObject> FirstLoc = new List<GameObject>();

    public Transform StartPos;
    public Transform EndPos;

    private GameObject H;

    public void SpawnNextPlatform()
    {
        
            H = Instantiate(FirstLoc[Random.Range(0, FirstLoc.Count)], StartPos.position, StartPos.rotation);
        

        H.GetComponent<PlatformsMoover>().EndPos = EndPos;
        H.GetComponent<PlatformsMoover>().StartPos = StartPos;
    }
}
