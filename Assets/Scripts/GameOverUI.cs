using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Image[] starDisplay = new Image[3];
    [SerializeField] Sprite emptyStar;
    [SerializeField] Animator anim;
    [SerializeField] AudioClip gameOverSFX;

    AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverScreen.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerGameOver()
    {
        gameOverScreen.SetActive(true);
        audioSource.clip = gameOverSFX;
        audioSource.Play();
        anim.SetTrigger("Trigger");
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
