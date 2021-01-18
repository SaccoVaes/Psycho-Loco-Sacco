using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject AudioMenuPanel;
    public GameObject ObjectsMenuPanel;
    public GameObject EnemiesMenuPanel;
    [HideInInspector]
    public GameObject ActivePanel;

    public void BackToMainMenu()
    {
        MainMenuPanel.SetActive(true);
        AudioMenuPanel.SetActive(false);
        ObjectsMenuPanel.SetActive(false);
        EnemiesMenuPanel.SetActive(false);
    }
    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DisableAllMenus()
    {
        MainMenuPanel.SetActive(false);
        AudioMenuPanel.SetActive(false);
        ObjectsMenuPanel.SetActive(false);
        EnemiesMenuPanel.SetActive(false);
    }
}
