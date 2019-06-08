using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
        Utilities.LoadScene(sceneName);
    }

    public void Exit()
    {
        Utilities.ExitGame();
    }
}
