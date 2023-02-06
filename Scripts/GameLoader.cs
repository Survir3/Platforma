using UnityEngine;
using IJunior.TypedScenes;
using UnityEditor.Animations;

public class GameLoader : MonoBehaviour
{    public void LoadMenu()
    {
        Menu.Load();
        Time.timeScale = 1;
    }
}
