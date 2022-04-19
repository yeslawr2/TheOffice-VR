using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerMananger : MonoBehaviour
{
    PhotonView PV;

    private float minX = -1;
    private float maxX = 0;

    private float minZ = -3;
    private float maxZ = -1;

    private GameObject currentPlayer;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Debug.Log("Instantiated Player Controller");
        //Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 1.0f, Random.Range(minZ, maxZ));
        Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
        if (SceneManager.GetActiveScene().name == "CombinedRooms")
        {
            position = new Vector3(-0.91976f, 7.98f, -11.04f);
        }
        currentPlayer = PhotonNetwork.Instantiate("Character", position, Quaternion.identity);
        currentPlayer.GetComponent<CharacterMovement>().setControllable(true);
    }
}
