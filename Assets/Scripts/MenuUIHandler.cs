using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameField;
    public MainManager Manager;

    public void Start()
    {
        Manager = FindObjectOfType<MainManager>().GetComponent<MainManager>();
        MainManager.Instance.LoadNameAndScore();
        if(MainManager.Instance.YourName != " ")
        {
            NameField.text = Manager.YourName;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SelectName()
    {
        MainManager.Instance.YourName = NameField.text;
    }
    public void Exit()
    {
        MainManager.Instance.SaveNameAndScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}