using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FaceRigManager : MonoBehaviour
{
    [System.Serializable]
    public struct TextureSwapper
    {
        // For each material
        public string materialName;
        public Material material;
        public int textureFrameId;

        // Lists of Textures
        public Texture[] baseTextureList;
        public Texture[] metallicTextureList;
        public Texture[] normalTextureList;

        // call this method to set textures
        public void SetTextureFrame(int frameId)
        {
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
    }

    public TextureSwapper[] textureSwappers;

    private void OnValidate()
    {
        foreach(TextureSwapper swapper in textureSwappers)
        {
            swapper.SetTextureFrame(swapper.textureFrameId);
        }
    }
}
