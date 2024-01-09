using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] bool playerState;
    CheckBallController checkBallController;
    float fingerPosX;

    void Start()
    {
        playerState = true;
        checkBallController = gameObject.GetComponentInChildren<CheckBallController>();
    }

    public void PlayerMoveOn()
    {
        playerState = true;
    }
    public void PlayerDontMove()
    {
        playerState = false;
    }

    void Update()
    {
        if (playerState)
        {
            transform.position += transform.forward * 5f * Time.deltaTime;
            if (Time.timeScale != 0)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            fingerPosX = touchPosition.x - transform.position.x;
                            break;
                        case TouchPhase.Moved:
                            if (touchPosition.x - fingerPosX > -1.15 && touchPosition.x - fingerPosX < 1.15)
                            {
                                transform.position = Vector3.Lerp(transform.position, new Vector3(touchPosition.x - fingerPosX, transform.position.y, transform.position.z), 3f);
                            }
                            break;

                    }
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), 0.01f);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), 0.01f);
                }
            }
        }
    }
    public void BoundryActive() // toplari bosaltcagim yere geldigimde 
    {
        var gameManager = GameManager.Instance;
        gameManager.CollectorPaletOff();
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

}
