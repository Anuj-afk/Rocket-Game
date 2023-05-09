using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColllisionHandler : MonoBehaviour
{
    int level = 0;

    private void OnCollisionEnter(Collision collision)
    {
        tag = collision.gameObject.tag;
        switch (tag)
        {
            case "Freindly":
                Debug.Log("This is freindly");
                break;
            case "Finish":
                level = 1;
                LevelLoader();
                break;
            default:
                level = 0;
                LevelLoader();
                break;
        }
    }
    private void LevelLoader()
    {
        int Currentscene = SceneManager.GetActiveScene().buildIndex;
        if (Currentscene + level == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(Currentscene + level);
        }
    }
}
