using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public ParticleSystem muzzleflash_vfx;

    public Animator gun_animator;


    // Start is called before the first frame update
    void Start()
    {
        gun_animator = GetComponent<Animator>();
    }


    public void Fire() {

        //muzzleflash_vfx.Play();
        gun_animator.SetTrigger("Fire");
    }

}
