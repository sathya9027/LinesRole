using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBlock : MonoBehaviour
{
    [SerializeField] float spinSpeed;

    private void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime * Vector3.forward);
    }
}
