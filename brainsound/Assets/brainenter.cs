using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brainenter : MonoBehaviour
{

    public GameObject uiElement; // Reference to the UI element you want to show

    public void ShowUI()
    {
        uiElement.SetActive(true);
    }
}
