using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazineController : MonoBehaviour
{

    GunController gunController;

    ShowFocusUI showFocusUI;

    public AudioClip Reload_sfx;
    // Start is called before the first frame update
    void Start()
    {
        gunController = GetComponentInParent<GunController>();
        showFocusUI = GetComponentInParent<ShowFocusUI>();
    }

    public void Reload() {

        gunController.Reload();
        Manager.SOUNDMANAGER.Play_Position(transform.position, Reload_sfx, 1.0f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magazine") {
            Reload();
            showFocusUI.DeActive();

            Destroy(other.gameObject);

        }
      
    }
}
