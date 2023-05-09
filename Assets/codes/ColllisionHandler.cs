using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColllisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        tag = collision.gameObject.tag;
        switch (tag)
        {
            case "Freindly":
                Debug.Log("This is freindly");
                break;
            case "Fuel":
                Debug.Log("Fuel add");
                break;
            case "Finish":
                Debug.Log("Level Completed");
                break;
            default:
                LevelLoader();
                break;
        }
    }
    private void LevelLoader()
    {
        int Currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(Currentscene);
    }
}
