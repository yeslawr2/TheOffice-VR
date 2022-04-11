using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMenuController : MonoBehaviour
{
    [SerializeField] private Button pushDoorButton;
    [SerializeField] private Button pullDoorButton;
    [SerializeField] private Button noneButton;

    private Image pushDoorButtonImage;
    private Image pullDoorButtonImage;
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

        pullDoorButton.onClick.AddListener(changeToPullMode);
        pushDoorButton.onClick.AddListener(changeToPushMode);
        noneButton.onClick.AddListener(changeToNoneMode);

        pushDoorButtonImage = pushDoorButton.GetComponent<Image>();
        pullDoorButtonImage = pullDoorButton.GetComponent<Image>();
        noneButtonImage = noneButton.GetComponent<Image>();

        defaultColor = pushDoorButtonImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDoorMode == DoorMode.PULL_DOOR)
        {
            pullDoorButtonImage.color = Color.green;
        }
        else
        {
            pullDoorButtonImage.color = defaultColor;
        }

        if (currentDoorMode == DoorMode.PUSH_DOOR)
        {
            pushDoorButtonImage.color = Color.green;
        }
        else
        {
            pushDoorButtonImage.color = defaultColor;
        }

        if (currentDoorMode == DoorMode.NONE)
        {
            noneButtonImage.color = Color.green;
        }
        else
        {
            noneButtonImage.color = defaultColor;
        }
    }

    public DoorMode GetCurrentMode()
    {
        return currentDoorMode;
    }

    private void changeToPullMode()
    {
        currentDoorMode = DoorMode.PULL_DOOR;
    }

    private void changeToPushMode()
    {
        currentDoorMode = DoorMode.PUSH_DOOR;
    }

    private void changeToNoneMode()
    {
        currentDoorMode = DoorMode.NONE;
    }
}
