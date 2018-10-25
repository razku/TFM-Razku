/** 
 *  @file    SceneChangerForIdiots.cs
 *  @author  Diego Llorens (Gamedyx)
 *  @date    07/10/2018  
 *  @version 1.0 
 *  
 *  @brief This is an ultra basic scene changer, almost for idiots, you just 
 *  need to link the ChangeScene function to a button event, with a parameter
 *  and when you click that button on Play, well.. it will change the scene
 *
 *  
 *  
 */

using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangerForIdiots : MonoBehaviour {

  
	public void ChangeScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}

    public void ExitGame()
    {
        Application.Quit();
    }
  

	void Start () {
		
	}
	
	void Update () {
		
	}
  
}
