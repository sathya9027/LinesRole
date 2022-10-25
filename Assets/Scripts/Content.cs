using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    GridLayoutGroup contentLayout;
    RectTransform rectTransform;
    int contentCount;

    private void Start()
    {
        contentLayout = GetComponent<GridLayoutGroup>();
        contentCount = GetComponentsInChildren<StageUI>().Length;
        Debug.Log(contentCount);
    }

    private void Update()
    {
        
    }
}
