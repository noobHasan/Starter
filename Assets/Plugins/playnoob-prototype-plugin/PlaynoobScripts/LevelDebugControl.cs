using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDebugControl : MonoBehaviour
{
    public bool permitDebugging;
    public TMP_InputField levelInput;

    public GameObject bottomPanel;

    public void OnPanelActivateButtonPressed()
    {
        if (!permitDebugging) return;

        if (bottomPanel.activeSelf) bottomPanel.SetActive(false);
        else bottomPanel.SetActive(true);
    }

    public void OnLevelLoadButtonPressed()
    {
        int levelNumber;
        if (int.TryParse(levelInput.text, out levelNumber))
        {
            PlayerPrefs.SetInt(PlaynoobConstants.CurrentLevel, levelNumber);
            LevelLoader.Instance.LoadLevel();
        }
        else
        {
            //load the same level
            LevelLoader.Instance.LoadLevel();

        }
    }
}
