using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMenuController : MonoBehaviour
{
    [SerializeField] private Button openDoorButton;
    [SerializeField] private Button closeDoorButton;
    [SerializeField] private Button noneButton;

    [SerializeField] private Canvas otherDoorMenu;
    private DoorMenuController otherDoorMenuController;

    private Image openDoorButtonImage;
    private Image closeDoorButtonImage;
    private Image noneButtonImage;

    private Color defaultColor;

    public enum DoorMode
    {
        PULL_DOOR, PUSH_DOOR, NONE
    }

    private DoorMode currentDoorMode;

    // Start is called before the first frame update
    void Start()
    {
        currentDoorMode = DoorMode.NONE;

        closeDoorButton.onClick.AddListener(changeToPullMode);
        openDoorButton.onClick.AddListener(changeToPushMode);
        noneButton.onClick.AddListener(changeToNoneMode);

        otherDoorMenuController = otherDoorMenu.GetComponent<DoorMenuController>();

        /*
        openDoorButtonImage = openDoorButton.GetComponent<Image>();
        closeDoorButtonImage = closeDoorButton.GetComponent<Image>();
        noneButtonImage = noneButton.GetComponent<Image>();

        defaultColor = openDoorButtonImage.color;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (currentDoorMode == DoorMode.PULL_DOOR)
        {
            closeDoorButtonImage.color = Color.green;
        }
        else
        {
            closeDoorButtonImage.color = defaultColor;
        }

        if (currentDoorMode == DoorMode.PUSH_DOOR)
        {
            openDoorButtonImage.color = Color.green;
        }
        else
        {
            openDoorButtonImage.color = defaultColor;
        }

        if (currentDoorMode == DoorMode.NONE)
        {
            noneButtonImage.color = Color.green;
        }
        else
        {
            noneButtonImage.color = defaultColor;
        }
        */
    }

    public DoorMode GetCurrentMode()
    {
        return currentDoorMode;
    }

    private void changeToPullMode()
    {
        currentDoorMode = DoorMode.PULL_DOOR;
        otherDoorMenuController.currentDoorMode = DoorMode.NONE;
    }

    private void changeToPushMode()
    {
        currentDoorMode = DoorMode.PUSH_DOOR;
        otherDoorMenuController.currentDoorMode = DoorMode.NONE;
    }

    private void changeToNoneMode()
    {
        currentDoorMode = DoorMode.NONE;
        otherDoorMenuController.currentDoorMode = DoorMode.NONE;
    }
}
