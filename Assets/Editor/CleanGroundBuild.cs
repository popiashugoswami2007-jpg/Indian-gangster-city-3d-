using UnityEditor;
using UnityEngine;
using UnityEditor.Build;
using UnityEditor.SceneManagement;

public class CleanGroundBuild : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(UnityEditor.Build.Reporting.BuildReport report)
    {
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/World.unity");

        foreach (var root in scene.GetRootGameObjects())
        {
            string n = root.name.ToLowerInvariant();

            bool keep =
                n.Contains("ground") ||
                n.Contains("road") ||
                n.Contains("plant") ||
                n.Contains("tree") ||
                n.Contains("vegetation") ||
                n.Contains("pole") ||
                n.Contains("lamp") ||
                n.Contains("streetlight") ||
                n.Contains("street_light") ||
                n.Contains("light pole") ||
                n.Contains("lightpole") ||
                n == "camera" ||
                n == "directional light" ||
                n == "global volume" ||
                n.Contains("sky");

            if (!keep)
                Object.DestroyImmediate(root);
        }

        EditorSceneManager.SaveScene(scene);
    }
}
