using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{

    public AudioClip explosion_sfx;
    public AudioClip Starting_sfx;
    public ParticleSystem explosion_vfx;
    public float wait_sec;
    public float explosion_radius;
    public float damage;
    public float impulse_distance;
    public float impulse;
    // Start is called before the first frame update
    void Start()
    {
        explosion_vfx = GetComponentInChildren<ParticleSystem>();
    }

    IEnumerator  Explosion() {

        Manager.SOUNDMANAGER.Play_Position(transform.position, Starting_sfx, 1.2f);
        yield return new  WaitForSeconds(wait_sec);// 지정된 시간 이후 

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosion_radius, LayerMask.GetMask("Monster"));

        explosion_vfx.Play();
        Manager.SOUNDMANAGER.Play_Position(transform.position, explosion_sfx, 1.2f);
        foreach (Collider collider in colliders) {

            collider.gameObject.GetComponent<MonsterController>().TakeDamage(damage);
            
        }

       
        Destroy(gameObject, 3.0f);
    }

    public void StartExplosion() {

        StartCoroutine(Explosion());
    }
}
