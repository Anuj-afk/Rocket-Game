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
                level += 1;
                LevelLoader();
                break;
            default:
                LevelLoader();
                break;
        }
    }
    private void LevelLoader()
    {
        int Currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(Currentscene + level);
    }
}
