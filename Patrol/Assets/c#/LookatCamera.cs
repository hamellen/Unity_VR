using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCamera : MonoBehaviour
{

    Camera player_camera;

    // Start is called before the first frame update
    void Start()
    {
        player_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + player_camera.transform.rotation * Vector3.forward, player_camera.transform.rotation * Vector3.up);
    }
}
