using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FlappyButton : MonoBehaviour
{
    public string playScene;
    void OnMouseDown()
    {
        transform.position += new Vector3(0, -0.1f, 0);
    }
    void OnMouseUp()
    {
        transform.position += new Vector3(0, 0.1f, 0);
        if (playScene != "")
        {
            SceneManager.LoadScene(playScene);
        }
    }

}
