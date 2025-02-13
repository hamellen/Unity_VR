using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XrController : MonoBehaviour
{

    public GameObject LeftDirect;
    public GameObject RightDirect;
    public GameObject LeftRay;
    public GameObject Inventory_go;
    public GameObject End_go;
    public bool isShowUI = false;
    public bool IsShowRay = true;
    public InputActionReference ChangeHand;

    public InputActionReference ViewInventory;

    int total_count;
    public int Total_Count {
        set {
            total_count = value;
            if (total_count <= 0) { EndGame(); } }
        get { return total_count; }
    }



    // Start is called before the first frame update
    void Start()
    {
        LeftDirect.SetActive(false);
        RightDirect.SetActive(true);
        LeftRay.SetActive(true);
        Inventory_go.SetActive(false);
        End_go.SetActive(false);
        ChangeHand.action.started += ChangeLeftController;
        ViewInventory.action.started += Show_Inventory;
    }

    public void ChangeController() {

        LeftDirect.SetActive(true);

        LeftRay.SetActive(false);

    }

    public void ChangeLeftController(InputAction.CallbackContext context) {

        if (IsShowRay)
        {
            LeftDirect.SetActive(true);
            LeftRay.SetActive(false);
        }
        else if (!IsShowRay) {
            LeftDirect.SetActive(false);
            LeftRay.SetActive(true);
        }

        IsShowRay = !IsShowRay;
    }

    public void Show_Inventory(InputAction.CallbackContext context) {

        if (isShowUI)
        {
            Inventory_go.SetActive(false);
        }
        else if (!isShowUI) {

            Inventory_go.SetActive(true);
        }
        isShowUI = !isShowUI;
    }

    public void EndGame() {

        Inventory_go.SetActive(false);
        End_go.SetActive(true);
    }
}
