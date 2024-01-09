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
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject[] collectorPalets;
    bool isHavePalets;
    [SerializeField] GameObject[] bonusBalls; 
    int NumberOfBallScored = 0;
    int totalBallZones;
    int currentBallZones = 0;
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
        for (int i = 0; i < BallZones.Count; i++)
        {
            BallZones[i].numberText.text = NumberOfBallScored + "/" + BallZones[i].ballToThrow;
        }

        totalBallZones = BallZones.Count - 1;
    }

    public void BallCountAndWrite()
    {
        NumberOfBallScored += 1;
        BallZones[currentBallZones].numberText.text = NumberOfBallScored + "/" + BallZones[currentBallZones].ballToThrow;
    }
    public void PhaseControl()
    {
        if (NumberOfBallScored >= BallZones[currentBallZones].ballToThrow)
        {
            BallZones[currentBallZones].animator.Play("ElevatorAnim");
            foreach (var item in BallZones[currentBallZones].phaseBalls)
            {
                item.SetActive(false);
            }

            if (currentBallZones == totalBallZones)
            {
                playerController.PlayerDontMove();
                Time.timeScale = 0;
                Debug.Log("Oyun Bitti");
            }
            else
            {
                currentBallZones++;
                NumberOfBallScored = 0;
                if (isHavePalets)
                {
                    collectorPalets[0].SetActive(true);
                    collectorPalets[1].SetActive(true);
                }
            }
        }
        else
        {
            Debug.Log("Kaybettin");
        }
    }
    public void CollectorPaletsOn()
    {
        isHavePalets = true;
        collectorPalets[0].SetActive(true);
        collectorPalets[1].SetActive(true);
    }
    public void CollectorPaletOff()
    {
        if (isHavePalets)
        {
            collectorPalets[0].SetActive(false);
            collectorPalets[1].SetActive(false);
        }
    }
    public void BonusBallsActive(int index)
    {
        bonusBalls[index].SetActive(true);
    }

}
