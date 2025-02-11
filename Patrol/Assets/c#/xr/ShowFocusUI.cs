using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFocusUI : MonoBehaviour
{

    public GameObject focus_ui;

    private void Start()
    {
        focus_ui.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Magazine") {

            focus_ui.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Magazine")
        {

            focus_ui.SetActive(false);
        }
    }

    public void DeActive() {

        focus_ui.SetActive(false);
    }

   
}
