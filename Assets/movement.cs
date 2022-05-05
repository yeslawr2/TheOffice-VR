using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class movement : MonoBehaviour
{
    [SerializeField] private Camera childCamera;

    private PhotonView photonViewComponent;

    private bool isControllable;

    [SerializeField] private float movespeed;
    [SerializeField] private float walkspeed;

    private Vector3 movedirection;
    private Vector3 velocity;
    private Animator animator;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDist;
    [SerializeField] private LayerMask groundmask;
    [SerializeField] private float gravity;

    private CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        photonViewComponent = GetComponent<PhotonView>();

        if (isControllable)
        {
            childCamera.gameObject.SetActive(true);
        }
        else
        {
            childCamera.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonViewComponent.IsMine)
        {
            Move();
        }
    }

    private void Move()
    {
        bool sitting = Input.GetButtonDown("Jump") || Input.GetButtonDown("js10");
        
        isGrounded = Physics.CheckSphere(transform.position,groundCheckDist,groundmask);
        if (isGrounded && velocity.y<0)
        {   velocity.y = -2f;   }
        float movez = Input.GetAxis("Vertical");
        movedirection = new Vector3(0,0,movez);
        movedirection = transform.TransformDirection(movedirection);

        if (movedirection != Vector3.zero && movez > 0)
        {
            animator.SetBool("isWalking",true);
            
            movedirection *= walkspeed;

        }
        else
        {
            animator.SetBool("isWalking",false);
        }


        if (movedirection != Vector3.zero && movez < 0)
        {
            animator.SetBool("backwards",true);
            movedirection *= walkspeed;

        }
        else
        {
            animator.SetBool("backwards",false);
        }

        
        if (movedirection == Vector3.zero &&  sitting)
        {
            animator.SetTrigger("sitting");
        }
        if (movedirection == Vector3.zero &&  !sitting)
        {
            animator.ResetTrigger("sitting");
        }

        controller.Move(movedirection*Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * 75.0f * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    public void setControllable(bool value)
    {
        isControllable = value;
    }
}
