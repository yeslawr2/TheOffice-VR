using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveRoomButton : MonoBehaviour
{
    [SerializeField] private Canvas reserveRoomMenu;

    private MeshRenderer rendererComponent;
    private ReserveRoomMenuController reserveRoomMenuController;
    private Outline outlineComponent;

    private bool roomReserved;
    // Start is called before the first frame update
    void Start()
    {
        rendererComponent = gameObject.GetComponent<MeshRenderer>();
        reserveRoomMenuController = reserveRoomMenu.gameObject.GetComponent<ReserveRoomMenuController>();
        outlineComponent = gameObject.GetComponent<Outline>();

        reserveRoomMenu.gameObject.SetActive(false);

        roomReserved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (outlineComponent.enabled)
        {
            if (Input.GetKeyDown(KeyCode.L) || Input.GetButtonDown("js5"))
            {
                reserveRoomMenu.gameObject.SetActive(!reserveRoomMenu.gameObject.activeInHierarchy);
            }
        }

        if (reserveRoomMenuController.IsRoomReserved())
        {
            rendererComponent.material.color = Color.red;
        }
        else
        {
            rendererComponent.material.color = Color.green;
        }
    }
}
