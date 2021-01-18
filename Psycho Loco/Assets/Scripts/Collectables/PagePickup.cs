using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PagePickup : InteractablePickup
{
    public enum PageType {Always_Watching,Cant_Run, Dont_Look_Or_It_Takes_You,Follows,Forest,Help_Me,Leave_Me_Alone,No_No_No_No}
    public PageType pageType;
    private void OnAttachedToHand(Hand hand)
    {
        manager.AddPage(this.gameObject, pageType);
    }
}
