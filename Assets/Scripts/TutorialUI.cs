using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    public static TutorialUI instance;

    [SerializeField] GameObject tutorialUI;
    [SerializeField] TextMeshProUGUI tutorialText;
    [SerializeField] TutorialSO[] tutorialDesc;
    [SerializeField] GameObject[] tutorialObj;

    int index;
    bool isTutorialCompleted;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tutorialUI.SetActive(true);
        index = 0;
        SetGameObjectInActive();
        DisplayTutorial();
    }

    public void NextTutorial()
    {
        if (isTutorialCompleted)
        {
            SceneLoader.instance.LoadMainMenu();
            return;
        }
        tutorialUI.SetActive(false);
        SetGameObjectInActive();
        tutorialObj[index].SetActive(true);
        if (index + 1 == tutorialDesc.Length) { return; }
        index++;
        DisplayTutorial();
    }

    private void SetGameObjectInActive()
    {
        for (int i = 0; i < tutorialObj.Length; i++)
        {
            tutorialObj[i].SetActive(false);
        }
    }

    private void DisplayTutorial()
    {
        tutorialText.text = tutorialDesc[index].GetTutorialDesc();
    }

    public void TutorialCompleted()
    {
        isTutorialCompleted = true;
        tutorialUI.SetActive(true);
        tutorialText.text = "Tutorial Completed";
    }

    public void SetTutorial()
    {
        tutorialUI.SetActive(true);
        Time.timeScale = 0;
    }
}
