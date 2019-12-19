using UnityEngine;

//Simon Voss
//Sends triggers to animator to play ceratin animations

public class PlayMyAnimation : MonoBehaviour
{

    public Animator anim;
    public void PlayDefault()
    {
        if (anim != null)
        {
            anim.SetTrigger("Play");
        }
        else
        {
            Debug.Log("no animation desu");
        }
    }
    public void PlayDeath()
    {

        if (anim != null)
        {
            anim.SetTrigger("Death");
        }
        else
        {
            Debug.Log("no animation desu");

        }
    }
    public void PlayIdle()
    {

        if (anim != null)
        {
            anim.SetTrigger("Idle");
        }
        else
        {
            Debug.Log("no animation desu");

        }
    }
    public void PlayShoot()
    {
        if (anim != null)
        {
            anim.SetTrigger("Shoot");
        }
        else
        {

            Debug.Log("no animation desu");
        }
    }

}
