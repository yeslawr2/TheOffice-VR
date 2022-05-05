using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class ReserveRoomButton : MonoBehaviour
{
    [SerializeField] private Canvas reserveRoomMenu;
    private PhotonView pvComponent;

    private MeshRenderer rendererComponent;
    private ReserveRoomMenuController reserveRoomMenuController;
    private Outline outlineComponent;

    private bool roomReserved;

    private const byte COLOR_CHANGE_EVENT = 0;
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
            if (pvComponent.IsMine)
            {
                ReserveRoom();
            }    
        }
        else
        {
            // Use a RPC for this later
            //rendererComponent.material.color = Color.green;
            if (pvComponent.IsMine)
            {
                UnreserveRoom();
            }
        }
        
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if (obj.Code == COLOR_CHANGE_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            float r = (float)datas[0];
            float g = (float)datas[1];
            float b = (float)datas[2];
            float a = (float)datas[3];

            rendererComponent.material.color = new Color(r, g, b, a);
        }
    }

    void ReserveRoom()
    {
        //pvComponent.RPC("RPC_ChangeButtonColor", RpcTarget.All, true);
        pvComponent.RPC("RPC_ChangeButtonColor", RpcTarget.All, new Vector3(Color.red.r, Color.red.g, Color.red.b));
        //ChangeColor(Color.red);
    }

    void UnreserveRoom()
    {
        //pvComponent.RPC("RPC_ChangeButtonColor", RpcTarget.All, false);
        pvComponent.RPC("RPC_ChangeButtonColor", RpcTarget.All, new Vector3(Color.green.r, Color.green.g, Color.green.b));
        //ChangeColor(Color.green);
    }

    private void ChangeColor(Color color)
    {
        float r = color.r;
        float g = color.g;
        float b = color.b;
        float a = color.a;

        rendererComponent.material.color = new Color(r, g, b, a);

        object[] datas = new object[] { r, g, b, a };

        PhotonNetwork.RaiseEvent(COLOR_CHANGE_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }

    [PunRPC]
    void RPC_ChangeButtonColor(Vector3 color)
    {
        Color newColor = new Color(color.x, color.y, color.z);
        rendererComponent.material.color = newColor;
    }
}
