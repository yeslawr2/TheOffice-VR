using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DoorController : MonoBehaviour
{
    //[SerializeField] private Transform doorPivot;
    [SerializeField] private GameObject doorWing;
    [SerializeField] private Canvas doorMenu;
    [SerializeField] private Canvas exitMenu;

    private Outline outlineComponent;
    private DoorMenuController doorMenuController;
    private DoorMenuController exitMenuController;
    private PhotonView pvComponent;

    private float minRotateDistance = 0.0f;
    private float maxRotateDistance = 90.0f;

    private float currentRotateDistance;

    // Start is called before the first frame update
    void Start()
    {
        outlineComponent = GetComponentInChildren<Outline>();
        outlineComponent.enabled = false;

        pvComponent = GetComponent<PhotonView>();

        doorMenuController = doorMenu.GetComponent<DoorMenuController>();
        exitMenuController = exitMenu.GetComponent<DoorMenuController>();

        currentRotateDistance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (outlineComponent.enabled)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("js0"))
            {
                doorMenu.gameObject.SetActive(!doorMenu.gameObject.activeInHierarchy);
                exitMenu.gameObject.SetActive(!exitMenu.gameObject.activeInHierarchy);
            }

            if (Input.GetKey(KeyCode.L) || Input.GetButton("js5"))
            {
                if (doorMenuController.GetCurrentMode() == DoorMenuController.DoorMode.PUSH_DOOR
                    || exitMenuController.GetCurrentMode() == DoorMenuController.DoorMode.PUSH_DOOR)
                {
                    if (currentRotateDistance < maxRotateDistance)
                    {
                        //doorWing.transform.Rotate(0.0f, 1.0f, 0.0f);
                        //currentRotateDistance += 1.0f;
                        RotateDoor(1.0f);
                        pvComponent.RPC("SetRotateDistance", RpcTarget.All, 1.0f);
                    }
                }
                else if (doorMenuController.GetCurrentMode() == DoorMenuController.DoorMode.PULL_DOOR
                    || exitMenuController.GetCurrentMode() == DoorMenuController.DoorMode.PULL_DOOR)
                {
                    if (currentRotateDistance > minRotateDistance)
                    {
                        //doorWing.transform.Rotate(0.0f, -1.0f, 0.0f);
                        //currentRotateDistance -= 1.0f;
                        RotateDoor(-1.0f);
                        pvComponent.RPC("SetRotateDistance", RpcTarget.All, -1.0f);
                    }
                }
            }
        }
    }

    public void turnOnDoorOutline()
    {
        outlineComponent.enabled = true;
    }

    public void turnOffDoorOutline()
    {
        outlineComponent.enabled = false;
    }

    void RotateDoor(float value)
    {
        pvComponent.RPC("RPC_RotateDoor", RpcTarget.All, value);
    }

    [PunRPC]
    void RPC_RotateDoor(float value)
    {
        doorWing.transform.Rotate(0.0f, value, 0.0f);
    }

    [PunRPC]
    void SetRotateDistance(float value)
    {
        currentRotateDistance += value;
    }
}
