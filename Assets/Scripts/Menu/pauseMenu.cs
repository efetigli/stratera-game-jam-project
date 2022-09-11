using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : menuParent
{
    private int i;
    public override void Start()
    {
        base.Start();
    }
    public void BackToMainMenu(){
        Invoke("WaitMM",0.2f);
    }
    private void WaitMM(){
        SceneManager.LoadScene(0);
    }
    public void WaitSfx(){
        if (i<1){   
            i++;
            Invoke("WaitSfx",0.2f);
        }
        else{
            i--;
            gameObject.SetActive(false);
        }
    }
}
