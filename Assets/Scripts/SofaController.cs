using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaController : MonoBehaviour
{
    [SerializeField] private Canvas sofaMenu;

    private Outline outlineComponent;
    // Start is called before the first frame update
    void Start()
    {
        sofaMenu.gameObject.SetActive(false);

        outlineComponent = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (outlineComponent.enabled)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("js0"))
            {
                sofaMenu.gameObject.SetActive(!sofaMenu.gameObject.activeInHierarchy);
            }
        }
    }
}
