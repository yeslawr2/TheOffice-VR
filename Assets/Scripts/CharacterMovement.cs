using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController characterControllerComponent;

    // Start is called before the first frame update
    void Start()
    {
        characterControllerComponent = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * 2.0f;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= 10.0f;
        characterControllerComponent.Move(velocity * Time.deltaTime);
    }
}
