using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandController : MonoBehaviour
{

    public Animator RightHand_animator;


    // Start is called before the first frame update
    void Start()
    {
        RightHand_animator = GetComponent<Animator>();    
    }

    public void GrabGun() {

        RightHand_animator.SetTrigger("GrabGun");
    }

    public void DropGun() {

        RightHand_animator.SetTrigger("DropGun");

    }

    public void Fire() {


        RightHand_animator.SetTrigger("FireGun");
    }

}
