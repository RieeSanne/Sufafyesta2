using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);}

    public void Main (){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);}

    public void Town(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);}

     public void Retry (){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);}

    public void Town1(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);}

    public void Game(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);}


    public void QuitGame(){
        Debug.Log ("Quit!");
        Application.Quit();
    }
}
