using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChairMenuController : MonoBehaviour
{
    [SerializeField] private Button MoveButton;
    [SerializeField] private Button RotateButton;
    [SerializeField] private Button SitButton;

    private bool moveMode;
    private bool rotateMode;
    private bool sitMode;

    private bool moveForward;
    private bool rotateRight;

    private Image moveButtonImage;
    private Image rotateButtonImage;

    private Text moveButtonText;
    private Text rotateButtonText;

    private Color originalButtonColor;

    // Start is called before the first frame update
    void Start()
    {
        moveButtonImage = MoveButton.gameObject.GetComponent<Image>();
        rotateButtonImage = RotateButton.gameObject.GetComponent<Image>();
        originalButtonColor = moveButtonImage.color;

        moveButtonText = MoveButton.GetComponentInChildren<Text>();
        rotateButtonText = RotateButton.GetComponentInChildren<Text>();

        moveMode = false;
        rotateMode = false;
        sitMode = false;

        moveForward = false;
        rotateRight = false;

        MoveButton.onClick.AddListener(changeMoveMode);
        RotateButton.onClick.AddListener(changeRotateMode);
        SitButton.onClick.AddListener(changeSitMode);
    }

    // Update is called once per frame
    void Update()
    {

        if (moveMode)
        {
            moveButtonImage.color = Color.green;
        }
        else
        {
            moveButtonImage.color = originalButtonColor;
        }

        if (rotateMode)
        {
            rotateButtonImage.color = Color.green;
        }
        else
        {
            rotateButtonImage.color = originalButtonColor;
        }

        if (moveForward)
        {
            moveButtonText.text = "Move: Forward";
        }
        else
        {
            moveButtonText.text = "Move: Backward";
        }

        if (rotateRight)
        {
            rotateButtonText.text = "Rotate: Right";
        }
        else
        {
            rotateButtonText.text = "Rotate: Left";
        }
    }

    private void changeMoveMode()
    {
        if (moveMode && moveForward)
        {
            moveMode = false;
            moveForward = false;
        }
        else if (moveMode && !moveForward)
        {
            moveForward = true;
        }
        else
        {
            moveMode = true;
        }
        rotateMode = false;
        sitMode = false;
    }

    private void changeRotateMode()
    {
        if (rotateMode && rotateRight)
        {
            rotateMode = false;
            rotateRight = false;
        }
        else if (rotateMode && !rotateRight)
        {
            rotateRight = true;
        }
        else
        {
            rotateMode = true;
        }
        moveMode = false;
        sitMode = false;
    }

    private void changeSitMode()
    {
        sitMode = !sitMode;
        moveMode = false;
        rotateMode = false;
    }

    public bool IsMoveMode()
    {
        return moveMode;
    }

    public bool IsRotateMode()
    {
        return rotateMode;
    }

    public bool IsSitMode()
    {
        return sitMode;
    }

    public bool IsMoveForward()
    {
        return moveForward;
    }

    public bool IsRotateRight()
    {
        return rotateRight;
    }
}
