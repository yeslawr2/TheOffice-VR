using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChairController : MonoBehaviour
{
    [SerializeField] private Canvas originalChairMenu;

    private Canvas thisChairMenu;
    private Outline outlineComponent;
    private ChairMenuController menuControllerComponent;
    private PhotonView pvComponent;

    private float maxMoveDistance;
    private float maxRotateDistance;
    private float minRotateDistance;

    private float currentMoveDistance;
    private float currentRotateDistance;
    // Start is called before the first frame update
    void Start()
    {
        thisChairMenu = Instantiate(originalChairMenu, new Vector3(transform.position.x + 0.35f, transform.position.y + 1.39f, transform.position.z), originalChairMenu.transform.rotation);
        thisChairMenu.gameObject.SetActive(false);

        outlineComponent = gameObject.GetComponent<Outline>();
        menuControllerComponent = thisChairMenu.gameObject.GetComponent<ChairMenuController>();
        pvComponent = GetComponent<PhotonView>();

        maxMoveDistance = 1.0f;
        maxRotateDistance = 30.0f;
        minRotateDistance = -30.0f;

        currentMoveDistance = 0.0f;
        currentRotateDistance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (outlineComponent.enabled)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("js0"))
            {
                thisChairMenu.gameObject.SetActive(!thisChairMenu.gameObject.activeInHierarchy);
            }

            if (Input.GetKey(KeyCode.L) || Input.GetButton("js5"))
            {
                if (menuControllerComponent.IsMoveMode())
                {
                    if (menuControllerComponent.IsMoveForward())
                    {
                        if (currentMoveDistance > 0)
                        {
                            //gameObject.transform.Translate(0.0f, 0.0f, -0.01f);
                            MoveChair(-0.01f);
                            currentMoveDistance -= 0.01f;
                        }
                    }
                    else
                    {
                        if (currentMoveDistance < maxMoveDistance)
                        {
                            //gameObject.transform.Translate(0.0f, 0.0f, 0.01f);
                            MoveChair(0.01f);
                            currentMoveDistance += 0.01f;
                        }
                    }
                }
                else if (menuControllerComponent.IsRotateMode())
                {
                    if (menuControllerComponent.IsRotateRight())
                    {
                        if (currentRotateDistance > minRotateDistance)
                        {
                            gameObject.transform.Rotate(0.0f, 0.5f, 0.0f);
                            currentRotateDistance -= 0.5f;
                        }
                    }
                    else
                    {
                        if (currentRotateDistance < maxRotateDistance)
                        {
                            gameObject.transform.Rotate(0.0f, -0.5f, 0.0f);
                            currentRotateDistance += 0.5f;
                        }
                    }
                }
            }
        }
    }

    void MoveChair(float distance)
    {
        pvComponent.RPC("RPC_MoveChair", RpcTarget.All, distance);
    }

    void RotateChair(float angle)
    {

    }

    [PunRPC]
    void RPC_MoveChair(float distance)
    {
        gameObject.transform.Translate(0.0f, 0.0f, distance);
    }
}
