using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public GameObject myStage;
    public GameObject nextStage;
    // Start is called before the first frame update
    public void ExitGame()
    {
        Application.Quit();
    }
    public void HideUI()
    {
        myStage.SetActive(false);
        nextStage.SetActive(false);
    }
    public void setNewStage()
    {
        myStage.SetActive(false);
        nextStage.SetActive(true);
    }
}
