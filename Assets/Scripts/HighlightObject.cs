using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    private Outline outlineComponent;

    // Start is called before the first frame update
    void Start()
    {
        outlineComponent = gameObject.GetComponent<Outline>();
        outlineComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOnOutline()
    {
        outlineComponent.enabled = true;
    }

    public void turnOffOutline()
    {
        outlineComponent.enabled = false;
    }
}
