using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StageUI : MonoBehaviour
{
    [SerializeField] Image[] starDisplay = new Image[3];
    [SerializeField] Button nextLevel;
    [SerializeField] Sprite fullStar;
    [SerializeField] GameObject objName;
    [SerializeField] GameObject stageLock;
    [SerializeField] TextMeshProUGUI levelName;
    [SerializeField] bool isDefault;

    bool isReady;
    bool isCompleted;
    string sceneNumber;
    string prevSceneNumber;
    int num;

    private void Start()
    {
        GetPlayerPrefs();
        SetBool();
        StarDisplay();
    }

    private void GetPlayerPrefs()
    {
        sceneNumber = Regex.Replace(objName.name, "[^0-9]", "");
        int.TryParse(sceneNumber, out num);
        levelName.text = sceneNumber;
        prevSceneNumber = (num - 1).ToString();
    }

    private void SetBool()
    {
        if (PlayerPrefs.GetInt(prevSceneNumber + "Bool") == 1)
        {
            isReady = true;
        }
        if (PlayerPrefs.GetInt(sceneNumber + "Bool") == 1)
        {
            isCompleted = true;
        }
        if (isDefault || isReady)
        {
            nextLevel.interactable = true;
            stageLock.SetActive(false);
        }
        else
        {
            nextLevel.interactable = false;
        }
    }

    private void StarDisplay()
    {
        if (isCompleted)
        {
            if (PlayerPrefs.GetInt(sceneNumber + "Star") == 3)
            {
                starDisplay[0].sprite = fullStar;
                starDisplay[1].sprite = fullStar;
                starDisplay[2].sprite = fullStar;
            }
            if (PlayerPrefs.GetInt(sceneNumber + "Star") == 2)
            {
                starDisplay[1].sprite = fullStar;
                starDisplay[2].sprite = fullStar;
            }
            if (PlayerPrefs.GetInt(sceneNumber + "Star") == 1)
            {
                starDisplay[2].sprite = fullStar;
            }
        }
    }
}
