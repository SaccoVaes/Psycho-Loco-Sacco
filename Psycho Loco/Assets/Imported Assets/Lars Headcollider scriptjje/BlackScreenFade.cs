using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class BlackScreenFade : MonoBehaviour
{
    public Animator MyAnimationController;
    private string Tag;

    private void Start()
    {
        Tag = this.tag;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (Tag == "Player")
        {
            if (collision.gameObject.tag == "Wall")
            {
                MyAnimationController.SetBool("fadeIn", true);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (Tag == "Player")
        {
            if (collision.gameObject.tag == "Wall")
            {
                MyAnimationController.SetBool("fadeIn", false);
            }
        }
    }
}
