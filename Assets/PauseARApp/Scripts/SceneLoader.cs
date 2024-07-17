using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public enum SceneRefrence
{
    None,
    StartScene,
    ChooseYourExperience,
    WalkSelect,
    ActivitySelect,
    AnywhereSelect,
    BYOSelect,
    ForestRoute,
}

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    public UnityEngine.UI.RawImage transitionImage;

    private SceneRefrence _currentScene;

    private void Awake()
    {
        instance = this;
    }

    public void LoadScene(SceneRefrence toLoad)
    {
        // cant transition to same scene
        if (toLoad == _currentScene) return;

        // get scene names
        string from = _currentScene.ToString();
        string to = toLoad.ToString();

        // get current camera render and display on screen
        transitionImage.texture = _GetCameraScreenshot();

        // async load & unload
        AsyncOperation op = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        op.completed += (_) =>
        {
            Scene s = SceneManager.GetSceneByName(from);
            if (s != null && s.IsValid())
                SceneManager.UnloadSceneAsync(s);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(to));
        };

        // state update
        _currentScene = toLoad;
    }

    private Texture2D _GetCameraScreenshot()
    {
        //get camera view dimensions
        Camera cam = Camera.main;
        int w = cam.pixelWidth;
        int h = cam.pixelHeight;

        // prep RenderTexture
        RenderTexture rt = new RenderTexture(w, h, 24, RenderTextureFormat.ARGB32);
        rt.antiAliasing = 2; // for smooth image

        // capture camera view
        cam.targetTexture = rt;
        cam.Render();

        // copy pixels to image
        RenderTexture.active = rt;
        Texture2D output = new Texture2D(w, h, TextureFormat.RGB24, false);
        output.ReadPixels(new Rect(0, 0, w, h), 0, 0, false);
        output.Apply();

        // clean up
        RenderTexture.active = null;
        cam.targetTexture = null;
        rt.DiscardContents();
        rt.Release();

        return output;
    }

}
