using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public TMP_Text textTimer;

    private float Timer;

    public static bool Loosed = false;

    public TMP_Text MaxTimeEver;
    public TMP_Text TimeNow;

    private void Start()
    {
        Loosed = false;
    }

    public void FixedUpdate()
    {
        if(!Loosed) Timer += Time.deltaTime;
    }

    private void Update()
    {
        if (Loosed)
        {
            MaxTimeEver.text = "Max time ever:" + PlayerPrefs.GetFloat("MaxTimeEver").ToString();
            TimeNow.text = "Your time:" + Timer.ToString();

            if(PlayerPrefs.GetFloat("MaxTimeEver") < Timer) PlayerPrefs.SetFloat("MaxTimeEver", Timer);

            textTimer.gameObject.SetActive(false);
        }

        textTimer.text = ((Timer - (Timer % 60)) / 60).ToString() + "." + Math.Round((Timer % 60), 0).ToString();
    }
}
