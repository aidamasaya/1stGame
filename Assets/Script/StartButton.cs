using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //public void Continue()
    //{
    //    SceneManager.LoadScene(1);//続きからゲームを再開するスコアは0コインは半分減る
    //}
    public void End()
    {
        SceneManager.LoadScene(0);
    }
}
