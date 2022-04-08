using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Camera childCamera;

    private CharacterController characterControllerComponent;
    private PhotonView photonViewComponent;

    // Start is called before the first frame update
    void Start()
    {
        characterControllerComponent = GetComponent<CharacterController>();
        photonViewComponent = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonViewComponent.IsMine)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical);
            Vector3 velocity = direction * 2.0f;
            //velocity = Camera.main.transform.TransformDirection(velocity);
            velocity = childCamera.transform.TransformDirection(velocity);
            velocity.y -= 10.0f;
            characterControllerComponent.Move(velocity * Time.deltaTime);
        }
    }
}
