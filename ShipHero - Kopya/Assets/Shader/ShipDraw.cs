using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDraw : MonoBehaviour
{
    public Shader _drawShader;
    public GameObject terrain;
    public List<Transform> shipBottom = new List<Transform>();
    RaycastHit _groundHit;
    int layerMask;
    private RenderTexture _splatMap;
    private Material _snowMaterial, _drawMaterial;
    [Range(1,500)]public float _brushSize;
    [Range(0,1)]public float _brushStrength;


    void Start()
    {
        terrain = GameObject.FindWithTag("Floor");
        layerMask = LayerMask.GetMask("Sea");
        _drawMaterial = new Material(_drawShader);
        _snowMaterial = terrain.GetComponent<MeshRenderer>().material;
        _snowMaterial.SetTexture("_Splat",_splatMap = new RenderTexture(1024,1024,0,RenderTextureFormat.ARGBFloat));
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag("obstacle"))
        {
            shipBottom.Add(obs.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < shipBottom.Count; i++){
            if(Physics.Raycast(shipBottom[i].position,-Vector3.up,out _groundHit,1f,layerMask)){
                _drawMaterial.SetVector("_Coordinate", new Vector4(_groundHit.textureCoord.x,_groundHit.textureCoord.y,0,0));
                _drawMaterial.SetFloat("_Strength",_brushStrength);
                _drawMaterial.SetFloat("_Size",_brushSize);
                RenderTexture temp = RenderTexture.GetTemporary(_splatMap.width,_splatMap.height,0,RenderTextureFormat.ARGBFloat);
                Graphics.Blit(_splatMap,temp);
                Graphics.Blit(temp,_splatMap,_drawMaterial);
                RenderTexture.ReleaseTemporary(temp);
            }
        }
    }
}
