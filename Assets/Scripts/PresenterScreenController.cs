using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Photon.Pun;

public class PresenterScreenController : MonoBehaviour
{
    private VideoPlayer videoPlayerComponent;
    private PhotonView pvComponent;

    // Start is called before the first frame update
    void Start()
    {
        pvComponent = GetComponent<PhotonView>();

        videoPlayerComponent = GetComponent<VideoPlayer>();
        videoPlayerComponent.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseVideo()
    {
        videoPlayerComponent.Pause();
    }

    public void PlayVideo()
    {
        videoPlayerComponent.Play();
    }

    public void GoBack()
    {
        double newTime = videoPlayerComponent.time - 5.0;
        if (newTime < 0)
        {
            newTime = 0;
        }
        //videoPlayerComponent.time = newTime;
        pvComponent.RPC("RPC_SetTime", RpcTarget.All, newTime);
    }

    public void GoForward()
    {
        double newTime = videoPlayerComponent.time + 5.0;
        //videoPlayerComponent.time = newTime;
        pvComponent.RPC("RPC_SetTime", RpcTarget.All, newTime);
    }

    public void PlayOrPause()
    {
        if (videoPlayerComponent.isPaused)
        {
            //PlayVideo();
            pvComponent.RPC("RPC_PlayVideo", RpcTarget.All);
        }
        else
        {
            //PauseVideo();
            pvComponent.RPC("RPC_PauseVideo", RpcTarget.All);
        }
    }

    [PunRPC]
    void RPC_SetTime(double newTime)
    {
        videoPlayerComponent.time = newTime;
    }

    [PunRPC]
    void RPC_PlayVideo()
    {
        videoPlayerComponent.Play();
    }

    [PunRPC]
    void RPC_PauseVideo()
    {
        videoPlayerComponent.Pause();
    }
}
