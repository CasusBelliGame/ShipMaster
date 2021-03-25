using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaNoice : MonoBehaviour
{
    public Shader seaNoiceShader;
    private Material seaNoiceMat;
    MeshRenderer meshRenderer;
    [Range(0.001f,0.1f)]public float flakeAmount;
    [Range(0f,1f)]public float flakeOpacity;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        seaNoiceMat = new Material(seaNoiceShader);
    }

    // Update is called once per frame
    void Update()
    {
        seaNoiceMat.SetFloat("_flakeAmount",flakeAmount);
        seaNoiceMat.SetFloat("_flakeOpacity",flakeOpacity);
        RenderTexture sea = (RenderTexture) meshRenderer.material.GetTexture("_Splat");
        RenderTexture temp = RenderTexture.GetTemporary(sea.width,sea.height,0,RenderTextureFormat.ARGBFloat);
        Graphics.Blit(sea,temp,seaNoiceMat);
        Graphics.Blit(temp,sea);
        meshRenderer.material.SetTexture("_Splat",sea);
        RenderTexture.ReleaseTemporary(temp);
    }
}
