using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

/// <summary>
/// This class is responsible for the VR-Player input, attached to the left controller of the player.
/// </summary>
public class VR_Player_CameraMovement : MonoBehaviour
{
    public SteamVR_Behaviour_Pose pose;
    public SteamVR_Action_Boolean ActivateMovement = SteamVR_Input.GetBooleanAction("InteractUI");
    public SteamVR_Input_Sources hand;//gives us a way to select what hand our script is attached to.
    public GameObject player;
    //public float speed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        if (pose == null)
            pose = this.GetComponent<SteamVR_Behaviour_Pose>();
        if (pose == null)
            Debug.LogError("No SteamVR_Behaviour_Pose component found on this object");
        if (ActivateMovement == null)
            Debug.LogError("No ui interaction action has been set on this component.");
    }

    //Things to check every update:
    //-Check if ActivateMovement is enabled (if the player should move)
    void Update()
    {
        //Check if player movement is enabled
        if (SteamVR_Actions.default_InteractUI.GetState(hand))
        {
            //Check the localrotation of the controller
            Quaternion controllerRotation = this.transform.localRotation;
            player.transform.Translate(VR_Player_CameraMovement.getForwardXZ(3.0f * Time.deltaTime, controllerRotation));
        }
    }

    // Returns a Vector3 with only the X and Z components (Y is 0'd)
    public static Vector3 vector3XZOnly(Vector3 vec)
    {
        return new Vector3(vec.x, 0f, vec.z);
    }

    // Returns a forward vector given the distance and direction
    public static Vector3 getForwardXZ(float forwardDistance, Quaternion direction)
    {
        Vector3 forwardMovement = direction * Vector3.forward * forwardDistance;
        return vector3XZOnly(forwardMovement);
    }
}
