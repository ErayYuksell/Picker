using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class BallZone
{
    public Animator animator;
    public TextMeshProUGUI numberText;
    public int ballToThrow;
    public GameObject[] phaseBalls;
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int NumberOfBallScored = 0;
    [SerializeField] public List<BallZone> BallZones = new List<BallZone>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        BallZones[0].numberText.text = NumberOfBallScored + "/" + BallZones[0].ballToThrow;
    }

    public void BallCountAndWrite()
    {
        NumberOfBallScored += 1;
        BallZones[0].numberText.text = NumberOfBallScored + "/" + BallZones[0].ballToThrow;
    }
    public void PhaseControl()
    {
        if (NumberOfBallScored >= BallZones[0].ballToThrow)
        {
            Debug.Log("Falan true");

            foreach (var item in BallZones[0].phaseBalls)
            {
                item.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Falan else");
        }
    }

}
