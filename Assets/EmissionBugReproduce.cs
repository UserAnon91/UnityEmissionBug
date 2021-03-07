using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionBugReproduce : MonoBehaviour
{
    public Material newNewGridMaterial;

    public Texture2D gridTexture;
    public Renderer ourRenderer;

    // I've originally split this into awake or start,
    // then update the texture every 0.1 seconds with the same result
    void Awake() 
    {
        gridTexture = new Texture2D(100, 100);

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                if (i % 2 == 0 && j % 2 == 0)
                {
                    gridTexture.SetPixel(i, j, Color.magenta);
                }
                else
                {
                    gridTexture.SetPixel(i, j, Color.black);
                }
            }
        }
        gridTexture.filterMode = FilterMode.Point;

        gridTexture.Apply();

        ourRenderer.material.SetTexture("_EmissiveColorMap", gridTexture);

        /*******************************/

        /*
        Additionally, i've attempted to use:

        newNewGridMaterial.EnableKeyword("_EMISSION");
        newNewGridMaterial.EnableKeyword("_Emission");
        newNewGridMaterial.EnableKeyword("_Emissive");
        newNewGridMaterial.SetTexture("_BaseColorMap", gridTexture);

        ourRenderer.material = newNewGridMaterial;

        DynamicGI.SetEmissive(ourRenderer, Color.white);
        ourRenderer.UpdateGIMaterials();
        */
    }
}