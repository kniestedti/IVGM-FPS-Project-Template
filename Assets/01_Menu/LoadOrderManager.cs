using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadOrderManager : MonoBehaviour
{
    // The LoadOrderManager takes care of loading in the levels that are including in the build settings.
    // DO NOT CHANGE THIS SCRIPT!
    private int defaultIndex = 1;
    public int sceneToLoadIndex;
    string sceneToLoadName;
    TextMeshProUGUI selectedSceneDisplayText;
    
    void Start()
    {
        ChangeSceneToLoadIndex(defaultIndex);
    }

    void SetSelectedSceneText()
    {
        if (selectedSceneDisplayText ==  null) selectedSceneDisplayText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        selectedSceneDisplayText.text = "Level: " + sceneToLoadName;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoadIndex);
    }

    public void ChangeSceneToLoadIndex (int _input)
    {
        if (_input > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("Index out of bounds. Add more levels to the build settings. LevelToLoadIndex was not changed.");
        } else if (_input == 0)
        {
            Debug.Log("Index of 0 refers to Main Menu. LevelToLoadIndex was not changed.");
        } else {
            Debug.Log("Valid index. LevelToLoadIndex was set to " + _input);
            sceneToLoadIndex = _input;
            string path = SceneUtility.GetScenePathByBuildIndex(sceneToLoadIndex);
            sceneToLoadName = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);
            SetSelectedSceneText();
        }
    }
}
