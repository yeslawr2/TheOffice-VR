using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitRoomTrigger : MonoBehaviour
{
    private BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "VR_Player")
        {
            Debug.Log("Collision detected");
            SceneManager.LoadScene("officecabin");
        }
    }
}
