using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public static bool doorShouldBeOpen = false;

    void Start()
    {
        if (doorShouldBeOpen)
        {
            OpenDoor();
            doorShouldBeOpen = false; // Reset the flag
        }
    }

    void OpenDoor()
    {
        Animator doorAnimator = GetComponent<Animator>();
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Door_Open");
        }
        else
        {
            Debug.LogWarning("Animator component not found on the door.");
        }
    }
}
