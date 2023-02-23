using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivateLever : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;

    public GameObject leverHandle;

    public bool fadeToBlack = false;

    public KeyCode useKey = KeyCode.E;

    bool playerInTrigger = false;

    private void Start()
    {
        myUIGroup.alpha = 0;
    }

    private void Update()
    {
        if (myUIGroup.alpha < 1 && fadeToBlack)
        {
            myUIGroup.alpha += Time.deltaTime;
        }

        if (playerInTrigger)
        {
            if (Input.GetKeyDown(useKey))
            {
                leverHandle.transform.Rotate(0f, 0f, -40f);

                playerInTrigger = false;

                fadeToBlack = true;

                StartCoroutine(LoadingScene());
            }
        }
    }

    IEnumerator LoadingScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("End Scene");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = false;
        }
    }
}