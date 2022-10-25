using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    [SerializeField] float delay;
    [SerializeField] AudioClip sfx;
    [SerializeField] Animator anim;

    AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private IEnumerator AnimationDelay(int sceneNum)
    {
        TriggerSFX();
        anim.SetTrigger("Trigger");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneNum);
    }

    private IEnumerator AnimationDelay(string sceneName)
    {
        TriggerSFX();
        anim.SetTrigger("Trigger");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        StartCoroutine(AnimationDelay(SceneManager.GetActiveScene().buildIndex));
    }
    public void LoadNextScene()
    {
        Time.timeScale = 1;
        StartCoroutine(AnimationDelay(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(AnimationDelay(0));
    }

    public void LoadStageScene(GameObject obj)
    {
        StartCoroutine(AnimationDelay(obj.name));
    }

    public void LoadStageScene()
    {
        StartCoroutine(AnimationDelay(1));
    }

    public void LoadTutorialScene()
    {
        StartCoroutine(AnimationDelay("Tutorial"));
    }

    public void TriggerSFX()
    {
        audioSource.clip = sfx;
        audioSource.Play();
    }
}
