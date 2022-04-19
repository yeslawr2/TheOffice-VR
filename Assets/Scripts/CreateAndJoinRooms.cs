using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    // For creating room codes
    [SerializeField] private InputField createInput;
    [SerializeField] private InputField joinInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("b");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("b");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("CombinedRooms");
    }
}
