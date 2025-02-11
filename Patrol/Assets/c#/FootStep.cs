using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class FootStep : MonoBehaviour
{

    public AudioClip footset_sfx;

    public float current_value_foot=0;
    public float add_foot_value;

    public float maxvalue_foot;

    public InputActionReference Axis_move;


    // Start is called before the first frame update
    void Start()
    {
        Axis_move.action.performed += Active_Footsfx;
    }

    void Active_Footsfx(InputAction.CallbackContext context) {


        current_value_foot += add_foot_value;

        if (current_value_foot > maxvalue_foot) {

            Manager.SOUNDMANAGER.Play_Position(transform.position, footset_sfx, 1.2f);
            current_value_foot = 0;
        }

    }

}
