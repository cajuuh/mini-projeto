using System;
using System.Linq;
using UnityEditor;

public class BuildScript
{

    private static readonly string _versionNumber;
    private static readonly string _buildNumber;

    static BuildScript()
    {
        _versionNumber = Environment.GetEnvironmentVariable("VERSION_NUMBER");
        if (string.IsNullOrEmpty(_versionNumber))
            _versionNumber = "1.0.1";

        _buildNumber = Environment.GetEnvironmentVariable("BUILD_NUMBER");
        if (string.IsNullOrEmpty(_buildNumber))
            _buildNumber = "1";

        PlayerSettings.productName = "Blasterboy";
        PlayerSettings.bundleVersion = _versionNumber;
    }
    static void Android()
    {
        BuildPipeline.BuildPlayer(GetScenes(), "blasterboy.apk", BuildTarget.Android, BuildOptions.None);
    }

    static string[] GetScenes()
    {
        return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
    }
}