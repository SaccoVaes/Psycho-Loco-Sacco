using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_GUI_Manager : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();
    public List<GameObject> InventoryItems = new List<GameObject>();
    public GameObject MainMenuPanel;
    public GameObject AudioPanel;
    public GameObject ObjectsPanel;
    public GameObject EnemiesPanel;

    void Start()
    {
        ActivateHotkeys();
    }

    void Update()
    {
        //Check if List is not empty
        if (InventoryItems.Count != 0)
        {
            for (int i = 0; i < InventoryItems.Count; i++)
            {
                if (Input.GetKeyDown((i + 1).ToString()))
                {
                    OnMainMenuButtonClicked();
                }
            }
        }
    }

        public void NavigateToSubMenu(GameObject panel)
    {
        MainMenuPanel.SetActive(false);
        panel.SetActive(true);
    }

    public void ActivateHotkeys()
    {
        if (InventoryItems.Count != 0)
        {
            //For x items in the list.
            for (int i = 0; i < InventoryItems.Count; i++)
            {
                //Get the required text components in the children.
                var text = InventoryItems[i].GetComponentInChildren<Text>();
                text.text = (i + 1).ToString();

                var button = InventoryItems[i].GetComponent<Button>();
                button.onClick.AddListener(delegate {
                    OnMainMenuButtonClicked();
                });

            }
        }
    }

    public void OnBackButtonClicked()
    {
        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
        MainMenuPanel.SetActive(true);
    }

    public void OnMainMenuButtonClicked()
    {

    }
}
