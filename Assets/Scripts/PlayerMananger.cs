using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMananger : MonoBehaviour
{
    PhotonView PV;

    private float minX = -1;
    private float maxX = 0;

    private float minZ = -3;
    private float maxZ = -1;

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
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 1.0f, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate("Character", randomPosition, Quaternion.identity);
    }
}
