using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] AudioMixer masterAudio;
    [SerializeField] Image audioImage;
    [SerializeField] Sprite[] audioSprite = new Sprite[2];

    private void Start()
    {
        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            audioImage.sprite = audioSprite[1];
        }
        else
        {
            audioImage.sprite = audioSprite[0];
        }
    }

    public void Audio()
    {
        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            audioImage.sprite = audioSprite[0];
            masterAudio.SetFloat("MasterVol", -80);
            PlayerPrefs.SetInt("Audio", -80);
        }
        else
        {
            audioImage.sprite = audioSprite[1];
            masterAudio.SetFloat("MasterVol", 0);
            PlayerPrefs.SetInt("Audio", 0);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        ResetPlayerKey();
    }

    private void ResetPlayerKey()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Reset Successful");
        }
    }
}
