using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSkyboxChanger : MonoBehaviour
{
    public Material[] skyboxMaterials; // Array of skybox materials to choose from
    private int currentSkyboxIndex = 0;

    void Start()
    {
        // Set the initial skybox
        if (skyboxMaterials.Length > 0)
        {
            RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];
        }
    }

    void Update()
    {
        // Example: Change the skybox material based on user input or other conditions
        if (Input.GetKeyDown(KeyCode.Space)) // Example condition
        {
            ChangeSkybox();
        }
    }

    void ChangeSkybox()
    {
        currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxMaterials.Length;
        RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];
        DynamicGI.UpdateEnvironment(); // Updates global illumination
    }
}

