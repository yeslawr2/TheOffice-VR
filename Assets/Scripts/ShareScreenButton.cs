using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareScreenButton : MonoBehaviour
{
    [SerializeField] private Canvas shareScreenMenu;

    private Outline outlineComponent;
    // Start is called before the first frame update
    void Start()
    {
        outlineComponent = gameObject.GetComponent<Outline>();
        shareScreenMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (outlineComponent.enabled)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("js0"))
            {
                shareScreenMenu.gameObject.SetActive(!shareScreenMenu.gameObject.activeInHierarchy);
            }
        }
    }
}
