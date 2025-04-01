using System;
using TMPro;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    /*
     * This script generalizes animations for the enemies in the game,
     * allowing animations to be called from the Health component, if the enemy has animations.
     */

    private Animator _a;

    private void Start()
    {
        _a = GetComponent<Animator>();
    }

    public void Hit()
    {
        _a.SetTrigger("Hit");
    }

    public void Death()
    {
        _a.SetTrigger("Death");
    }

    public void PrimaryAttack()
    {
        _a.SetTrigger("PrimaryAttack");
    }

    public void SecondaryAttack()
    {
        _a.SetTrigger("SecondaryAttack");
    }
}
