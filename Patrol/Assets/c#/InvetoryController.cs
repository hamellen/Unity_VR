using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InvetoryController : MonoBehaviour
{
    public int Count_Magazine;

    public TextMeshProUGUI Text_Magazine;
    GunController gun_controller;
    // Start is called before the first frame update
    void Start()
    {
        Text_Magazine.text = $"Count_Magazine: {Count_Magazine}";
        gun_controller = FindObjectOfType<GunController>();
    }

    public void Change_Magazine()
    {
        Text_Magazine.text = $"Count_Magazine: {Count_Magazine}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Magazine") {

            Count_Magazine++;
            Change_Magazine();
            Destroy(other.gameObject);
        }
    }

    public void Equip_Magazine() {
        if (Count_Magazine > 0) {
            Count_Magazine--;
            Change_Magazine();
            gun_controller.Reload();
        }
        
    }
}
