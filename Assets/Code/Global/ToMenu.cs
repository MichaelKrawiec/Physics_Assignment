using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToMenu : MonoBehaviour
{
    public Score score;

    // Update is called once per frame
    void Update()
    {
        if (score.scoreValue == 2000)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
