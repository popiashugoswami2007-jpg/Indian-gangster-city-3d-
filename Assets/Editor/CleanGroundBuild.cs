using UnityEditor;
using UnityEngine;
using UnityEditor.Build;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class CleanGroundBuild : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(UnityEditor.Build.Reporting.BuildReport report)
    {
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/World.unity");

        foreach (var root in scene.GetRootGameObjects())
            Object.DestroyImmediate(root);

        var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Clean Ground";
        ground.transform.position = Vector3.zero;
        ground.transform.localScale = new Vector3(10f, 1f, 10f);

        var camObj = new GameObject("Camera");
        var cam = camObj.AddComponent<Camera>();
        cam.transform.position = new Vector3(0f, 12f, -18f);
        cam.transform.rotation = Quaternion.Euler(28f, 0f, 0f);
        cam.fieldOfView = 60f;
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = new Color(0.55f, 0.75f, 0.95f);

        var lightObj = new GameObject("Directional Light");
        var light = lightObj.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.2f;
        light.transform.rotation = Quaternion.Euler(50f, -30f, 0f);

        SceneManager.SetActiveScene(scene);
        EditorSceneManager.SaveScene(scene);
    }
}
