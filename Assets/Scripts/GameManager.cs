using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class GameManager : MonoBehaviour
{

    public GameObject panel;
    public PlatformerCharacter2D platformerCharacter2DScript;
    [Range(0f, 10f)]
    public float timeToDeath;

    void Start ()
    {        

        //sets timescale to normal everytime the scene is reloaded
        Time.timeScale = 1;

        //turn the game panel off if leaved on editor
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
	}
	
	void Update ()
    {
        if (platformerCharacter2DScript.GetIsDead())
        {
            panel.SetActive(true);
            StartCoroutine(waitToDeath(timeToDeath));
        }
	}

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator waitToDeath(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
    }
}
