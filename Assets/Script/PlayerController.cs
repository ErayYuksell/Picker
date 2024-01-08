using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] bool playerState;
    CheckBallController checkBallController;

    void Start()
    {
        playerState = true;
        checkBallController = gameObject.GetComponentInChildren<CheckBallController>();
    }


    void Update()
    {
        if (playerState)
        {
            transform.position += transform.forward * 5f * Time.deltaTime;
            if (Time.timeScale != 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), 0.05f);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), 0.05f);
                }
            }
        }
    }
    public void BoundryActive() // toplari bosaltcagim yere geldigimde 
    {
        playerState = false;
        StartCoroutine(PhaseControlDelayed());
        checkBallController.AddForceBall();
    }
    IEnumerator PhaseControlDelayed()
    {
        yield return new WaitForSeconds(2);
        var gameManager = GameManager.Instance;
        gameManager.PhaseControl();
    }
    public void PlayerMoveOn()
    {
        playerState = true;
    }
}
