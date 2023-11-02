using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCam : MonoBehaviour
{
    public Shader shader;

    void Start()
    {
        gameObject.GetComponent<Camera>().SetReplacementShader(shader, "");
    }

}
