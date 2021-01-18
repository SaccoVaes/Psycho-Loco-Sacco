using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class LockOpen : InteractablePickup
{
    public enum LockColor { Golden, Silver, Rusty }
    public LockColor lockcolor;
    public UnityEvent OnLockOpen;
    //Overrides the method
    protected override void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
            hand.HoverLock(interactable);

            // Attach this object to the hand
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
        else if (isGrabEnding)
        {
            // Detach this object from the hand
            hand.DetachObject(gameObject);

            // Call this to undo HoverLock
            hand.HoverUnlock(interactable);
        }  
    }
    private void OnAttachedToHand(Hand hand)
    {
        OnLockOpen.Invoke();
        Destroy(this.gameObject);
        manager.AddLock(this.gameObject, lockcolor);
    }
}
