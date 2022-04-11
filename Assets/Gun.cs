using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 80f;
    public Camera fpscam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position,fpscam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
