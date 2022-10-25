using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] bool portal1;
    [SerializeField] bool portal2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                if (collision.gameObject.GetComponent<Ball>().isPortalUsed) { break; }
                if (portal1)
                {
                    TeleportToPortal2(collision);
                }
                if (portal2)
                {
                    TeleportToPortal1(collision);
                }
                StartCoroutine(collision.gameObject.GetComponent<Ball>().TriggerPortalUse());
                break;
            default:
                break;
        }
    }

    private void TeleportToPortal2(Collider2D collider)
    {
        Transform transform = GameObject.Find("Portal2").transform;
        collider.gameObject.transform.position = transform.position;
    }
    private void TeleportToPortal1(Collider2D collider)
    {
        Transform transform = GameObject.Find("Portal1").transform;
        collider.gameObject.transform.position = transform.position;
    }
}
