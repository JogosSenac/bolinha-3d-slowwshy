using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
   public void play()
   {
      SceneManager.LoadScene("Fase1");
   }
   public void Quit()
   {
      Application.Quit();
   }
   public void VitóriaRE()
   {
      SceneManager.LoadScene(0);
   }
   public void Reviver()
   {
      SceneManager.LoadScene(1);
   }

}
