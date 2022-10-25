using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingPoint : MonoBehaviour
{
    public static FinishingPoint instance;

    [SerializeField] GameObject lockSprite;
    [SerializeField] Rigidbody2D finishRigidbody;
    [SerializeField] float sceneLoadDelay;
    [SerializeField] bool isLockable;

    Rigidbody2D playerRigidbody;
    bool isPlayerConnected;
    bool isUnlocked;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        lockSprite.SetActive(isLockable);
    }

    private void Update()
    {
        Gameplay();
    }

    private void Gameplay()
    {
        if (isLockable)
        {
            if (!isUnlocked)
            {
                return;
            }
        }
        if (isPlayerConnected)
        {
            playerRigidbody.transform.position = finishRigidbody.position;
        }
    }

    public bool GetUnlockBool()
    {
        return isLockable;
    }

    public void SetUnlockBool()
    {
        isUnlocked = true;
        CoreGameUI.instance.SetKeyDisplay();
        lockSprite.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerTrigger(collision);
        }
    }

    private void PlayerTrigger(Collider2D collision)
    {
        if (isLockable)
        {
            if (!isUnlocked)
            {
                return;
            }
        }
        playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        playerRigidbody.bodyType = RigidbodyType2D.Static;
        isPlayerConnected = true;
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            TutorialUI.instance.TutorialCompleted();
            return;
        }
        FinishUI.instance.SetFinishScreen();
    }
}
