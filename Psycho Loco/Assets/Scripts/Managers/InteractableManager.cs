using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

/// <summary>
/// This Class is responsible for holding all information of the found collectables.
/// </summary>
public class InteractableManager : MonoBehaviour
{
    public List<GameObject> pages = new List<GameObject>();
    public List<GameObject> keys = new List<GameObject>();
    public List<GameObject> locks = new List<GameObject>();

    //References to the locks
    public GameObject GoldenLock;
    public GameObject SilverLock;
    public GameObject RustyLock;

    public UnityEvent hasCompletedLevel;

    public int AmountOfPages = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    ///     1. Checks which page is collected.
    ///     2. Destroys the collected page.
    ///     3. Enables the page on the progression wall.
    ///     4. Checks if player has completed the level.
    /// </summary>
    /// <param name="page"></param>
    public void AddPage(GameObject page,PagePickup.PageType pageType)
    {
        Destroy(page);
        ActivatePage(pageType);
        AmountOfPages++;
        if(AmountOfPages == pages.Count())
        {
            hasCompletedLevel.Invoke();
        }
    }

    public void AddLock(GameObject theLock,LockOpen.LockColor color)
    {
        Destroy(theLock);
        ActivateLock(color);
    }


    /// <summary>
    ///     1. Checks which key is collected
    ///     2. Disables the collected keys.
    ///     3. Enables the key objects on the progression wall.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="color"></param>
    public void AddKey(GameObject key, KeyPickup.KeyColor color)
    {
        switch(color)
        {
            case KeyPickup.KeyColor.Golden:
                GoldenLock.GetComponentInChildren<LockOpen>().enabled = true;
                Destroy(key);
                ActivateKey(color);
                break;
            case KeyPickup.KeyColor.Silver:
                SilverLock.GetComponentInChildren<LockOpen>().enabled = true;
                Destroy(key);
                ActivateKey(color);
                break;
            case KeyPickup.KeyColor.Rusty:
                RustyLock.GetComponentInChildren<LockOpen>().enabled = true;
                Destroy(key);
                ActivateKey(color);
                break;
        }
    }

    public void ActivateKey(KeyPickup.KeyColor color)
    {
        var key = keys.Where(x => x.GetComponent<KeyPickup>().keycolor == color)
                    .Select(x => x).First();
        key.SetActive(true);
    }

    public void ActivatePage(PagePickup.PageType PageType)
    {
        var page = pages.Where(x => x.GetComponent<PagePickup>().pageType == PageType)
                    .Select(x => x).First();
        page.SetActive(true);
        page.GetComponent<PagePickup>().enabled = false;
    }

    public void ActivateLock(LockOpen.LockColor color)
    {
        var theLock = locks.Where(x => x.GetComponentInChildren<LockOpen>().lockcolor == color)
                    .Select(x => x).First();
        theLock.SetActive(true);
    }

}
