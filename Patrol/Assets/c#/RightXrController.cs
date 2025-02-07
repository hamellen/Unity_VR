using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightXrController : MonoBehaviour
{

    public  RightHandController rightHandController;
    // Start is called before the first frame update
    void Start()
    {
        //rightHandController = GetComponentInChildren<RightHandController>();
    }

    public void Grab() {

        if (rightHandController != null)
        {

            rightHandController.GrabGun();
        }
        else if (rightHandController == null) {
            rightHandController = GetComponentInChildren<RightHandController>();
            rightHandController.GrabGun();
        }
       
    }

    public void Drop() {
        
        rightHandController.DropGun();
    }

    
}
