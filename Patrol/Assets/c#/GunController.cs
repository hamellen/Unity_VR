using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public ParticleSystem muzzleflash_vfx;

    public Animator gun_animator;
    public AudioClip fire_sfx;

    // Start is called before the first frame update
    void Start()
    {
        gun_animator = GetComponent<Animator>();
    }


    public void Fire() {

        Manager.SOUNDMANAGER.Play_Position(transform.position, fire_sfx, 1.0f);
        muzzleflash_vfx.Play();
        //gun_animator.Play("Fire");
    }

}
