using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftXrController : MonoBehaviour
{
    public LeftHandController LeftHandController;
    // Start is called before the first frame update

    public AudioClip EquipMagazine_sfx;


    public void Grab()
    {

        if (LeftHandController != null)
        {

            LeftHandController.GrabGranade();
        }
        else if (LeftHandController == null)
        {
            LeftHandController = GetComponentInChildren<LeftHandController>();
            LeftHandController.GrabGranade();
        }
        Manager.SOUNDMANAGER.Play_Position(transform.position, EquipMagazine_sfx, 1.2f);
    }

    public void Drop()
    {

        LeftHandController.DropGranade();
    }
}
