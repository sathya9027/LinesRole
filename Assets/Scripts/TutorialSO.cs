using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Tutorial SO")]
[System.Serializable]
public class TutorialSO : ScriptableObject
{
    [TextArea(10, 20)]
    [SerializeField] string tutorialDesc;

    public string GetTutorialDesc()
    {
        return tutorialDesc;
    }
}
