using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : menuParent
{
    public override void Start()
    {
        base.Start();
    }
    public void BackToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
