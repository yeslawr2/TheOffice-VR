using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    public Animator transition;
    public float transition_time = 1f;

    // Update is called once per frame
    void Update()
    {
            
    }

    public void Loadlevel(string levelName)
    {
        //StartCoroutine(Loadlevel(SceneManager.LoadScene(1)));
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(levelName);
    }

    /*IEnumerator Loadlevel(int levelind)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transition_time);
        SceneManager.LoadScene(levelind);
    }*/
}
