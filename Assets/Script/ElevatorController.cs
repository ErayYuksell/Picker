using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] Animator BarrierZone;
    public AnimationClip anim;
    [SerializeField] PlayerController PlayerController;
    public void RemoveBarrier()
    {
        //BarrierZone.Play("BarrierRemove");
        BarrierZone.Play(anim.name);
    }
    public void Done()
    {
        PlayerController.PlayerMoveOn();
    }
}
