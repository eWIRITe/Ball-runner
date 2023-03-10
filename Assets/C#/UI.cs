using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.RemoteConfig;

public class UI : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public int PlaySceneNumber;
    public int InetSceneNumber;

    void Awake()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene(PlaySceneNumber);
    }
}