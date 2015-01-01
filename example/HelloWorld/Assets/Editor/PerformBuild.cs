using UnityEditor;
using UnityEngine;

class PerformBuild
{
    static void BuildAndroid ()
    {
        string[] scenes = {"Assets/MainScene.unity"};
        PlayerSettings.bundleIdentifier = "com.bugsnag.example";
        BuildPipeline.BuildPlayer(scenes, "HelloWorld.apk", BuildTarget.Android, BuildOptions.Development|BuildOptions.AutoRunPlayer);
    }
}
