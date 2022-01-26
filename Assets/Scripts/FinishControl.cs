using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishControl : MonoBehaviour
{
    public GameObject FinishPanel;
    GameManager gm;

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            FinishPanel.SetActive(true);

        }
    }

    public void NextLevel()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        gm.InitGame();
    }
}
