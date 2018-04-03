using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator myAnimator;
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        if (myAnimator.GetBool("IsOpen"))
	        {
                CloseDoor();
	        }
	        else
	        {
	            OpenDoor();
            }
	    }
	}

    public void OpenDoor()
    {
        myAnimator.SetBool("IsOpen", true);
    }

    public void CloseDoor()
    {
        myAnimator.SetBool("IsOpen", false);
    }
}
