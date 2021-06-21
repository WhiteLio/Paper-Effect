using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class TextureSwapper : MonoBehaviour
{
    // Material Info
    public Material material;
    public int textureFrameId;
    
    private int lastTextureFrameId = 0;

    // Lists of textures
    public Texture[] baseTextureList;
    public Texture[] metallicTextureList;
    public Texture[] normalTextureList;

    // Call this method to set textures
    public void SetTextureFrame(int frameId)
    {
        textureFrameId = frameId;

        if (material != null && baseTextureList != null && baseTextureList.Length > frameId)
        {
            material.mainTexture = baseTextureList[frameId];
        }

        if (material != null && metallicTextureList != null && metallicTextureList.Length > frameId)
        {
            material.EnableKeyword("_METALLICGLOSSMAP");
            material.SetTexture("_MetallicGlossMap", metallicTextureList[frameId]);
        }

        if (material != null && normalTextureList != null && normalTextureList.Length > frameId)
        {
            material.EnableKeyword("_NORMALMAP");
            material.SetTexture("_BumpMap", normalTextureList[frameId]);
        }
    }

    // Update textures in inspector
    void Update()
    {
        if (textureFrameId == lastTextureFrameId) return;
        lastTextureFrameId = textureFrameId;

        if (baseTextureList.Length == 0)
        {
            textureFrameId = 0;
            return;
        }

        if (textureFrameId < 0) textureFrameId = 0;
        if (textureFrameId >= baseTextureList.Length) textureFrameId = baseTextureList.Length - 1;

        SetTextureFrame(textureFrameId);
    }
}
