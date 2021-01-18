using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

/// <summary>
/// Class responsible for the behaviour of the flashlight
/// </summary>
public class VR_Player_Flashlight : MonoBehaviour
{
    public SteamVR_Behaviour_Pose pose;
    public SteamVR_Action_Boolean ActivateFlashlight = SteamVR_Input.GetBooleanAction("InteractUI");
    public SteamVR_Input_Sources hand;
    public GameObject VLight;

    //TODO: CHANGE THIS TO OnActivate!
    void Start()
    {
        if (pose == null)
            pose = this.GetComponent<SteamVR_Behaviour_Pose>();
        if (pose == null)
            Debug.LogError("No SteamVR_Behaviour_Pose component found on this object");
        if (ActivateFlashlight == null)
            Debug.LogError("No ui interaction action has been set on this component.");
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions.default_InteractUI.GetState(hand))
        {
            VLight.SetActive(true);
        }
        else
        {
            VLight.SetActive(false);
        }
    }
}
