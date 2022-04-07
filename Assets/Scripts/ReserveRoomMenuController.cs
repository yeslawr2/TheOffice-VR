using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReserveRoomMenuController : MonoBehaviour
{
    [SerializeField] private Button YesButton;
    [SerializeField] private Button NoButton;

    private bool reserveRoom;

    // Start is called before the first frame update
    void Start()
    {
        reserveRoom = false;
        YesButton.onClick.AddListener(reserveTheRoom);
        NoButton.onClick.AddListener(unreserveTheRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void reserveTheRoom()
    {
        reserveRoom = true;
    }

    private void unreserveTheRoom()
    {
        reserveRoom = false;
    }

    public bool IsRoomReserved()
    {
        return reserveRoom;
    }
}
