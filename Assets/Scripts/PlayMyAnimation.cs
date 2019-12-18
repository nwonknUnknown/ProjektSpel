using UnityEngine;

//Simon Voss
//Sends triggers to animator to play ceratin animations

public class PlayMyAnimation : MonoBehaviour
{

    public Animator anim;

    public void PlayDefault()
    {
        anim.SetTrigger("Play");
    }
    public void PlayDeath()
    {
        anim.SetTrigger("Death");
    }
    public void PlayIdle()
    {
        anim.SetTrigger("Idle");
    }
    public void PlayShoot()
    {
        anim.SetTrigger("Shoot");
    }
}
