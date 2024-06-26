#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScenesEditorMenu
{
    [MenuItem("Scenes/Splash &s")]
    private static void Splash()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Splash.unity");
    }
   [MenuItem("Scenes/inGame &g")]
   private static void inGame()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/inGame.unity");
    }
    [MenuItem("Scenes/Main Menu &M")]
   private static void Menu()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Main Menu.unity");
    }
}
#endif
