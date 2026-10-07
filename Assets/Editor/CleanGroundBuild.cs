using UnityEditor;
using UnityEngine;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;

public class CleanGroundBuild : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/World.unity");

        string[] keep = {
            "Grounds","Plants","Road","Mountains","Directional Light",
            "Global Volume","Camera","SideWalk","Sky"
        };

        foreach (var root in scene.GetRootGameObjects())
        {
            string n = root.name.ToLowerInvariant();
            bool ok = false;

            foreach (var k in keep)
                if (n.Contains(k.ToLowerInvariant())) { ok = true; break; }

            if (!ok)
                root.SetActive(false);
        }

        EditorSceneManager.SaveScene(scene);
    }
}
