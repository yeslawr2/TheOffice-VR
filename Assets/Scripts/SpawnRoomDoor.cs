using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoomDoor : MonoBehaviour
{
    [SerializeField] private Canvas enterRoomMenu;

    private Outline outlineComponent;

    // Start is called before the first frame update
    void Start()
    {
        outlineComponent = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (outlineComponent.enabled)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("js0"))
            {
                enterRoomMenu.gameObject.SetActive(!enterRoomMenu.gameObject.activeInHierarchy);
            }
        }
    }
}
