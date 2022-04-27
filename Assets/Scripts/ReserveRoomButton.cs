using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ReserveRoomButton : MonoBehaviour
{
    [SerializeField] private Canvas reserveRoomMenu;
    private PhotonView pvComponent;

    private MeshRenderer rendererComponent;
    private ReserveRoomMenuController reserveRoomMenuController;
    private Outline outlineComponent;

    private bool roomReserved;
    // Start is called before the first frame update
    void Start()
    {
        rendererComponent = gameObject.GetComponent<MeshRenderer>();
        reserveRoomMenuController = reserveRoomMenu.gameObject.GetComponent<ReserveRoomMenuController>();
        outlineComponent = gameObject.GetComponent<Outline>();

        pvComponent = GetComponent<PhotonView>();

        reserveRoomMenu.gameObject.SetActive(false);

        roomReserved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (outlineComponent.enabled)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("js0"))
            {
                reserveRoomMenu.gameObject.SetActive(!reserveRoomMenu.gameObject.activeInHierarchy);
            }
        }

        if (reserveRoomMenuController.IsRoomReserved())
        {
            // Use a RPC for this later
            //rendererComponent.material.color = Color.red;
            ReserveRoom();
        }
        else
        {
            // Use a RPC for this later
            //rendererComponent.material.color = Color.green;
            UnreserveRoom();
        }
    }

    void ReserveRoom()
    {
        //pvComponent.RPC("RPC_ChangeButtonColor", RpcTarget.All, true);
        pvComponent.RPC("RPC_ChangeButtonColor", RpcTarget.All, new Vector3(Color.red.r, Color.red.g, Color.red.b));
    }

    void UnreserveRoom()
    {
        //pvComponent.RPC("RPC_ChangeButtonColor", RpcTarget.All, false);
        pvComponent.RPC("RPC_ChangeButtonColor", RpcTarget.All, new Vector3(Color.green.r, Color.green.g, Color.green.b));
    }

    [PunRPC]
    void RPC_ChangeButtonColor(Vector3 color)
    {
        Color newColor = new Color(color.x, color.y, color.z);
        rendererComponent.material.color = newColor;
    }
}
