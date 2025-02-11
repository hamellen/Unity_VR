using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using System.Threading;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public GameObject go_muzzle;

    public Animator gun_animator;
    public AudioClip fire_sfx;
    public AudioClip empty_sfx;

    public float valid_length;

    public int full_ammo;
    public int current_ammo;

    public float damage;

    public Transform gun_fire_transform;

    public TextMeshProUGUI current_ammo_text;
    // Start is called before the first frame update
    void Start()
    {
        gun_animator = GetComponent<Animator>();
       
        current_ammo_text.text = $"{current_ammo}/{full_ammo}";
        
    }

    private void Update()
    {
        OnDrawGizmo();
    }
    void UpdateText() {

        current_ammo_text.text = $"{current_ammo}/{full_ammo}";
    }
    public void Fire() {

        if (current_ammo > 0)
        {
           
            current_ammo--;
            UpdateText();
            BulletCast();
            Manager.SOUNDMANAGER.Play_Position(transform.position, fire_sfx, 1.0f);
            StartCoroutine(ShowMuzzle());
            //gun_animator.Play("Fire");
        }
        else if (current_ammo == 0) {

            Manager.SOUNDMANAGER.Play_Position(transform.position, empty_sfx, 1.0f);
        }

        
    }

    public void OnDrawGizmo()
    {
        Debug.DrawRay(gun_fire_transform.position, gun_fire_transform.forward * valid_length, Color.yellow);
    }


    public void BulletCast() {


        Debug.Log("น฿ป็ ");
        RaycastHit hit;
        
        if (Physics.Raycast(gun_fire_transform.position, gun_fire_transform.forward, out hit, valid_length,LayerMask.GetMask("Monster")))
        {
            MonsterController monster_controller = hit.collider.gameObject.GetComponent<MonsterController>();
            if (monster_controller) {

                monster_controller.TakeDamage(damage);
            }
        }
       
    }

    IEnumerator ShowMuzzle()
    {
        go_muzzle.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        go_muzzle.SetActive(false);
    }


    public void Reload() {

        current_ammo = full_ammo;
        UpdateText(); 
        
    }

}
