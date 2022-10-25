using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public static PauseUI instance;

    [SerializeField] GameObject pauseScreen;
    [SerializeField] Image[] starDisplay = new Image[3];
    [SerializeField] Sprite emptyStar;
    [SerializeField] Animator anim;
    [SerializeField] float animDelay;

    [HideInInspector] public bool isPaused;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pauseScreen.SetActive(false);
    }

    public void PauseGame()
    {
        SceneLoader.instance.TriggerSFX();
        if (CoreGameUI.instance.emptyStar1)
        {
            starDisplay[0].sprite = emptyStar;
        }
        if (CoreGameUI.instance.emptyStar2)
        {
            starDisplay[1].sprite = emptyStar;
        }
        Invoke(nameof(SetBool), 0.5f);
        pauseScreen.SetActive(true);
        StartCoroutine(AnimDelay());
    }

    public void ResumeGame()
    {
        SceneLoader.instance.TriggerSFX();
        Time.timeScale = 1;
        anim.SetTrigger("Trigger");
        Invoke(nameof(SetBool), 0.5f);
        //pauseScreen.SetActive(false);
    }

    private void SetBool()
    {
        isPaused = !isPaused;
    }

    private IEnumerator AnimDelay()
    {
        anim.SetTrigger("Trigger");
        yield return new WaitForSeconds(animDelay);
        Time.timeScale = 0;
    }
}
