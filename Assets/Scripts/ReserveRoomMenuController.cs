using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ReserveRoomMenuController : MonoBehaviour
{
    [SerializeField] private Button YesButton;
    [SerializeField] private Button NoButton;

    private PhotonView pvComponent;

    private bool reserveRoom;

    // Start is called before the first frame update
    void Start()
    {
        reserveRoom = false;
        YesButton.onClick.AddListener(reserveTheRoom);
        NoButton.onClick.AddListener(unreserveTheRoom);

        pvComponent = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void reserveTheRoom()
    {
        //reserveRoom = true;
        pvComponent.RPC("RPC_ReserveRoom", RpcTarget.All, true);
    }

    private void unreserveTheRoom()
    {
        //reserveRoom = false;
        pvComponent.RPC("RPC_ReserveRoom", RpcTarget.All, false);
    }

    [PunRPC]
    void RPC_ReserveRoom(bool reserved)
    {
        reserveRoom = reserved;
    }

    public bool IsRoomReserved()
    {
        return reserveRoom;
    }
}
