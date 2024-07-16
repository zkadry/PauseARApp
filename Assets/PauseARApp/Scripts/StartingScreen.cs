using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartingScreen : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // check for screen tap
        if (Input.GetMouseButtonDown(0))
        {
            // load experience select screen
            SceneManager.LoadScene("ChooseYourExperience");
        }
    }
}
