using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChairSittingController : MonoBehaviour
{
    [SerializeField] private Transform animationPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SitDown()
    {
        GameObject character = GameObject.Find("Character1");
        PhotonView pv = character.GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            character.transform.position = animationPos.position;
            character.transform.rotation = animationPos.rotation;
        }
    }
}
