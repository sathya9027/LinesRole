using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [SerializeField] bool isHorizontal;
    [SerializeField] bool isVertical;
    [SerializeField] float moveVector;
    [SerializeField] float moveSpeed;

    Vector3 startingPosition;
    float movementFactor; 
    
    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (moveSpeed == 0) { return; }
        if(!isHorizontal && !isVertical) { return; }
        float cycles = Time.time / moveSpeed;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1) / 2;

        if (isVertical)
        {
            isHorizontal = false;
            Vector3 offset = new Vector3(0, moveVector, 0) * movementFactor;
            transform.position = startingPosition + offset;
        }
        if (isHorizontal)
        {
            isVertical = false;
            Vector3 offset = new Vector3(moveVector, 0, 0) * movementFactor;
            transform.position = startingPosition + offset;
        }
    }
}
