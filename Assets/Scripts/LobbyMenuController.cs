using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenuController : MonoBehaviour
{
    [SerializeField] private CreateAndJoinRooms createAndJoinRoomsObj;

    [SerializeField] private Button CreateButton;
    [SerializeField] private Button JoinButton;

    private Image createButtonImage;
    private Image joinButtonImage;

    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        createButtonImage = CreateButton.GetComponent<Image>();
        joinButtonImage = JoinButton.GetComponent<Image>();
        defaultColor = createButtonImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            createButtonImage.color = Color.yellow;
            joinButtonImage.color = defaultColor;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            joinButtonImage.color = Color.yellow;
            createButtonImage.color = defaultColor;
        }

        if (Input.GetButtonDown("js5"))
        {
            if (createButtonImage.color == Color.yellow)
            {
                createAndJoinRoomsObj.CreateRoom();
            }
            else if (joinButtonImage.color == Color.yellow)
            {
                createAndJoinRoomsObj.JoinRoom();
            }
        }
    }
}
