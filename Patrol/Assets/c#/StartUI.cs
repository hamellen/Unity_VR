using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public Slider Zombie_count_slider;
    
    public float Zombie_count;
    
    public List<GameObject> Zombie_Spawners = new List<GameObject>();
    public AudioClip value_sfx;
   

    public TextMeshProUGUI Text_Zombie_Count;
    XrController xr_controller;
    private void Start()
    {
        xr_controller = FindObjectOfType<XrController>();
       
        Text_Zombie_Count.text = $"Zombie_Spawn : {(int)Zombie_count}";
        Refresh_Count();
        
    }

    public void Change_Spawn_Zombie_Count() {
        Manager.SOUNDMANAGER.Play_Position(transform.position, value_sfx, 1.2f);
        Zombie_count = Zombie_count_slider.value;
        Refresh_Count();
        Text_Zombie_Count.text = $"Zombie_Spawn : {(int)Zombie_count}";
    }

    public void Refresh_Count() {

        foreach (GameObject go in Zombie_Spawners) {

            go.GetComponent<Auto_Gen>().max_object = (int)Zombie_count;
        }
    }

    public void Start_Game() {

        foreach (GameObject go in Zombie_Spawners)
        {

            go.GetComponent<Auto_Gen>().GameStart();
        }
    }

    public void GameStart() {

        Start_Game();
        gameObject.SetActive(false);
        xr_controller.Total_Count = (int)Zombie_count * Zombie_Spawners.Count;
    }
}
