using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuMgr : MonoBehaviour {

	public void Exit()
    {
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }
}
