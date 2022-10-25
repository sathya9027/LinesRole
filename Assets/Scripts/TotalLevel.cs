using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalLevel;

    int contentCount;

    private void Start()
    {
        contentCount = GetComponentsInChildren<StageUI>().Length;
        totalLevel.text = "Level Completed: " + PlayerPrefs.GetInt("TotalLevel") + "/" + contentCount;
    }
}
