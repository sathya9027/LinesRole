using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CoreGameUI : MonoBehaviour
{
    public static CoreGameUI instance;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image keyDisplay;
    [SerializeField] Image pencilDisplay;
    [SerializeField] Sprite[] pencilSprite = new Sprite[2];
    [SerializeField] Image[] starDisplay = new Image[3];
    [SerializeField] Sprite keySprite;
    [SerializeField] Sprite emptyStarSprite;
    [SerializeField] AudioClip switchSFX;
    [SerializeField] int star1Limit;
    [SerializeField] int star2Limit;

    [HideInInspector] public bool emptyStar1;
    [HideInInspector] public bool emptyStar2;
    [HideInInspector] public bool isDynamic;

    string sceneNumber;
    AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isDynamic = true;
        sceneNumber = Regex.Replace(SceneManager.GetActiveScene().name, "[^0-9]", "");
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            levelText.text = "Level " + sceneNumber;
        }
        keyDisplay.gameObject.SetActive(FinishingPoint.instance.GetUnlockBool());
    }

    private void Update()
    {
        if (LinesDrawer.instance.linesPointCount > star1Limit)
        {
            starDisplay[0].sprite = emptyStarSprite;
            emptyStar1 = true;
            PlayerPrefs.SetInt(sceneNumber + "Star", 2);
        }
        if (LinesDrawer.instance.linesPointCount > star2Limit)
        {
            starDisplay[1].sprite = emptyStarSprite;
            emptyStar2 = true;
            PlayerPrefs.SetInt(sceneNumber + "Star", 1);
        }
        if (!emptyStar1 && !emptyStar2)
        {
            PlayerPrefs.SetInt(sceneNumber + "Star", 3);
        }
    }

    public void SetKeyDisplay()
    {
        keyDisplay.sprite = keySprite;
    }

    public void SetPencilMode()
    {
        if (isDynamic)
        {
            pencilDisplay.sprite = pencilSprite[1];
        }
        else
        {
            pencilDisplay.sprite = pencilSprite[0];
        }
        audioSource.clip = switchSFX;
        audioSource.Play();
        isDynamic = !isDynamic;
    }
}
