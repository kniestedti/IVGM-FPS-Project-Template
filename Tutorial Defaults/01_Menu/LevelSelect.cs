using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    // This script talks to the LoadOrderManager and sets the level to be loaded.
    // DO NOT CHANGE THIS SCRIPT!
    int sceneIndex;
    private TextMeshProUGUI text;
    private LoadOrderManager loadOrderManager;

    void Start()
    {
        loadOrderManager = GameObject.Find("LoadOrderManager").GetComponent<LoadOrderManager>();
        text = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        sceneIndex = int.Parse(text.text);
    }

    public void ChangeSceneToLoad()
    {
        loadOrderManager.ChangeSceneToLoadIndex(sceneIndex);
    }
}
