using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] bool playerState;
    void Start()
    {
        playerState = true;
    }


    void Update()
    {
        if (playerState)
        {
            player.transform.position += player.transform.forward * 5f * Time.deltaTime;
            if (Time.timeScale != 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z), 0.08f);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), 0.08f);
                }
            }
        }
    }
    public void BoundryActive()
    {
        playerState = false;
    }
}
