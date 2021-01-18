using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
///     Script for 
/// </summary>
public class InventoryManager : MonoBehaviour
{
    public List<GameObject> InventoryItems = new List<GameObject>();
    [HideInInspector]
    public GameObject SelectedItem;
    [HideInInspector]
    public MenuNavigator navigator;

    void Awake()
    {
        navigator = GameObject.Find("MenuNavigator").GetComponent<MenuNavigator>();
        ActivateHotkeys();
        ActivateDescriptions();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Check if List is not empty
        if (InventoryItems.Count != 0)
        {
            for(int i = 0; i < InventoryItems.Count; i++)
            {
                if (Input.GetKeyDown((i + 1).ToString()))
                {
                    InventoryItems[i].GetComponent<ButtonManager>().OnButtonSelected(this);
                    //OnItemSelected(InventoryItems[i]);
                }
            }
        }

        //If the user presses left button.
        if (Input.GetMouseButtonDown(0))
        {
            if(SelectedItem != null)
            {
                SpawnItem(SelectedItem);
                SelectedItem.GetComponent<Image>().color = Color.white;
                SelectedItem = null;
            }
        }
    }

    //Method for generating hotkeys.
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
                //button.onClick.AddListener(delegate { OnItemSelected(button.gameObject);});
                button.onClick.AddListener(delegate {
                    button.gameObject.GetComponent<ButtonManager>().OnButtonSelected(this);
            });

            }
        }
    }

    //Method for generating Texts for each item.
    public void ActivateDescriptions()
    {
        if (InventoryItems.Count != 0)
        {
            //For x items in the list.
            for (int i = 0; i < InventoryItems.Count; i++)
            {
                //Get the required text components in the children.
                var buttonmanager = InventoryItems[i].GetComponentInChildren<ButtonManager>();
                var prefab = buttonmanager.PrefabToSpawn;
                if(prefab != null)
                {
                    prefab.GetComponent<SpawnableInfo>().InitiateDescriptionLabel(InventoryItems[i].GetComponentInChildren<TextMeshProUGUI>());
                }
                
            }
        }
    }

    public void SpawnItem(GameObject go)
    {
        var buttonmanager = go.GetComponent<ButtonManager>();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Debug.Log("You selected the " + hit.transform.name);
            Debug.Log("Spawning " + hit.transform);
            Instantiate(buttonmanager.PrefabToSpawn, hit.point,Quaternion.identity);
        }
    }

    public void OnItemSelected(GameObject item)
    {
        //Deselect the old item.
        if (SelectedItem != null)
        {
            //Selecteditem.Deactivate();
            SelectedItem.GetComponent<Image>().color = Color.white;
        }

        //Check if the same item is already selected;
        if (SelectedItem == item)
        {
            //Selecteditem.Deactivate();
            SelectedItem.GetComponent<Image>().color = Color.white;
            SelectedItem = null;
            return;
        }
        //Select new item to green;

        //Selecteditem.activate();
        SelectedItem = item;
            SelectedItem.GetComponent<Image>().color = Color.green;
    }

    public void OnBackButtonClicked()
    {
        navigator.BackToMainMenu();
    }

    public void OnMainMenuButtonClicked(GameObject item)
    {
        Debug.Log(item.name);
        navigator.DisableAllMenus();
        switch (item.name)
        {
            case "AudioMenu":
                navigator.ActivatePanel(navigator.AudioMenuPanel);
                break;
            case "ObjectsMenu":
                navigator.ActivatePanel(navigator.ObjectsMenuPanel);
                break;
            case "EnemiesMenu":
                navigator.ActivatePanel(navigator.EnemiesMenuPanel);
                break;
        }
    }
}
