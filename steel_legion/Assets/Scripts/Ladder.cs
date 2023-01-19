using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    GameObject playerObj;

    public bool canClimb;
    public float climbSpeed;

    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;

    private void Start()
    {
        canClimb = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canClimb = true;
            playerObj = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canClimb = false;
            playerObj = null;
        }
    }

    private void Update()
    {
        if (canClimb == true)
        {
            if (Input.GetKey(upKey))
            {
                playerObj.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * climbSpeed);
            }
        }
        if (canClimb == true)
        {
            if (Input.GetKey(downKey))
            {
                playerObj.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * climbSpeed);
            }
        }
    }
}
