using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class char_color : MonoBehaviour
{
    // Start is called before the first frame update
    public SkinnedMeshRenderer[] renderer;

    private PhotonView pvComponent;
    
    void Start()
    {
        Color newColor = new Color(Random.Range(0f,1f),
                                            Random.Range(0f,1f),
                                            Random.Range(0f,1f));
        
        pvComponent = GetComponent<PhotonView>();

        ApplyColor(newColor,0);

    }
    // Update is called once per frame
    void ApplyColor(Color color, int targetMaterialIndex)
    {
        if (pvComponent.IsMine)
        {
            pvComponent.RPC("RPC_SetColor", RpcTarget.AllBuffered, new Vector3(color.r, color.g, color.b));
        }

        /*
        Material generatematerial = new Material(Shader.Find("Standard"));
        generatematerial.SetColor("_Color",color);
        for (int i = 0;i<renderer.Length;i++){
            renderer[i].material = generatematerial;
        }
        */
        
        
    }

    [PunRPC]
    void RPC_SetColor(Vector3 values)
    {
        Color color = new Color(values.x, values.y, values.z);
        Material generatematerial = new Material(Shader.Find("Standard"));
        generatematerial.SetColor("_Color", color);
        for (int i = 0; i < renderer.Length; i++)
        {
            renderer[i].material = generatematerial;
        }
    }
}
