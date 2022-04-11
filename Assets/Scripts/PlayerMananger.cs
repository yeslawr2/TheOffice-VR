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
        if (SceneManager.GetActiveScene().name == "Spawn-room")
        {
            position = new Vector3(-0.91976f, 7.98f, -11.04f);
        }
        else if (SceneManager.GetActiveScene().name == "Hallway")
        {
            position = new Vector3(4.95431f, 15.44126f, -28.7538f);
        }
        else if (SceneManager.GetActiveScene().name == "Scene1")
        {
            //position = new Vector3(Random.Range(minX, maxX), 1.0f, Random.Range(minZ, maxZ));
            position = new Vector3(-20.63f, 1.0f, 1.22f);
        }
        else if (SceneManager.GetActiveScene().name == "C room")
        {
            position = new Vector3(16.66f, 11.45f, 8.14f);
        }
        PhotonNetwork.Instantiate("Character", position, Quaternion.identity);
    }
}
