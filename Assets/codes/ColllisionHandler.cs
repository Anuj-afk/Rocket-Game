using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Debug.Log("you have hit a obstacle");
                break;
        }
    }
}
