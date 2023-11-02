using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renderer : MonoBehaviour
{
    public RenderTexture color;
    public RenderTexture normal;
    public RenderTexture height;
    public RenderTexture result;

    public ComputeShader shader;

    public GameObject camera;

    private float time = 0;

    void Update()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        time++;
        shader.SetTexture(0, "Color", color);
        shader.SetTexture(0, "Normal", normal);
        shader.SetTexture(0, "Height", height);
        shader.SetTexture(0, "Result", result);
        shader.SetFloat("Time", time);
        shader.Dispatch(0, 1920 / 8, 1080 / 4, 1);

        Graphics.Blit(result, destination);
    }
}
