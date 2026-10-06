using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class CleanGroundBuild : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(UnityEditor.Build.Reporting.BuildReport report)
    {
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/World.unity");

        foreach (var root in scene.GetRootGameObjects())
        {
            string n = root.name;

            bool keep =
                n == "PlainGround" ||
                n == "Camera" ||
                n == "Directional Light" ||
                n == "Global Volume" ||
                n == "Plants" ||
                n == "Mountains";

            if (!keep)
                Object.DestroyImmediate(root);
        }

        EditorSceneManager.SaveScene(scene);
    }
}
