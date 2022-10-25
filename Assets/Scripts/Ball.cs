using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip[] collisionSFX;

    [HideInInspector] public bool isPortalUsed;

    AudioSource audioSource;
    Transform triggerTransform;
    Rigidbody2D rb2D;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
        isPortalUsed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //int randomIndex = Random.Range(0, collisionSFX.Length);
        //audioSource.clip = collisionSFX[randomIndex];
        //audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tutorial":
                triggerTransform = collision.gameObject.transform;
                Destroy(collision);
                break;
            case "Key":
                FinishingPoint.instance.SetUnlockBool();
                Destroy(collision.gameObject);
                break;
            case "Barrier":
                if (SceneManager.GetActiveScene().name == "Tutorial")
                {
                    transform.position = triggerTransform.position;
                    break;
                }
                GameOverUI.instance.TriggerGameOver();
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    public IEnumerator TriggerPortalUse()
    {
        rb2D.velocity = Vector2.zero;
        isPortalUsed = true;
        yield return new WaitForSeconds(1f);
        isPortalUsed = false;
    }
}
