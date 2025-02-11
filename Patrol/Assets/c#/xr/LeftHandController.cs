using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandController : MonoBehaviour
{
    public Animator LeftHand_animator;


    // Start is called before the first frame update
    void Start()
    {
        LeftHand_animator = GetComponent<Animator>();
    }

    public void GrabGranade()
    {

        LeftHand_animator.SetTrigger("GrabGranade");
    }

    public void DropGranade()
    {

        LeftHand_animator.SetTrigger("DropGranade");

    }

   
}
