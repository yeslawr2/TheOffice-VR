using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AvailabilityLabelController : MonoBehaviour
{
    [SerializeField] private ReserveRoomMenuController reserveRoomMenuController;
    [SerializeField] private Material availableMaterial;
    [SerializeField] private Material reservedMaterial;

    private MeshRenderer rendererComponent;
    private PhotonView pvComponent;

    // Start is called before the first frame update
    void Start()
    {
        rendererComponent = GetComponent<MeshRenderer>();
        pvComponent = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reserveRoomMenuController.IsRoomReserved())
        {
            if (pvComponent.IsMine)
            {
                pvComponent.RPC("RPC_ReserveRoom", RpcTarget.All);
            }
        }
        else
        {
            if (pvComponent.IsMine)
            {
                pvComponent.RPC("RPC_UnreserveRoom", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void RPC_ReserveRoom()
    {
        rendererComponent.material = reservedMaterial;
    }

    [PunRPC]
    void RPC_UnreserveRoom()
    {
        rendererComponent.material = availableMaterial;
    }
}
