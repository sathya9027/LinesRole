using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FinishUI : MonoBehaviour
{
    public static FinishUI instance;

    [SerializeField] Image[] starDisplay = new Image[3];
    [SerializeField] Sprite emptyStar;
    [SerializeField] AudioClip finishSFX;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject finishScreen;

    string sceneNumber;
    bool isCompleted;
    AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        finishScreen.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        sceneNumber = Regex.Replace(SceneManager.GetActiveScene().name, "[^0-9]", "");
    }

    private void Update()
    {
        GetPlayerPrefsInt();
        SetPlayerPrefsInt();
    }

    private void GetPlayerPrefsInt()
    {
        int boolInt = PlayerPrefs.GetInt(sceneNumber + "Bool");
        if (boolInt == 1)
        {
            isCompleted = true;
        }
        else
        {
            isCompleted = false;
        }
    }

    private void SetPlayerPrefsInt()
    {
        if (isCompleted)
        {
            PlayerPrefs.SetInt(sceneNumber + "Bool", 1);
        }
        else
        {
            PlayerPrefs.SetInt(sceneNumber + "Bool", 0);
        }
    }
    public void SetFinishScreen()
    {
        if (!isCompleted)
        {
            PlayerPrefs.SetInt(sceneNumber + "Bool", 1);
            PlayerPrefs.SetInt("TotalLevel", PlayerPrefs.GetInt("TotalLevel") + 1);
        }
        finishScreen.SetActive(true);
        audioSource.clip = finishSFX;
        audioSource.Play();
        levelText.text = "Level " + sceneNumber + "\nCompleted";
        scoreText.text = "Score: " + (LinesDrawer.instance.linesPointCount * 25).ToString();
        if (CoreGameUI.instance.emptyStar1)
        {
            starDisplay[0].sprite = emptyStar;
        }
        if (CoreGameUI.instance.emptyStar2)
        {
            starDisplay[1].sprite = emptyStar;
        }
    }
}
