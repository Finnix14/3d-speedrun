using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnims : MonoBehaviour
{
    public Animator anim;
    

    public void PlaySwoosh()
    {
        anim.SetTrigger("Play");
    }

    public void OptionsSwoosh()
    {
        anim.SetTrigger("Options");
    }

    public void OptionsBack()
    {
        anim.SetTrigger("OptionsBack");
    }
    public void PlayBack()
    {
        anim.SetTrigger("PlayBack");
    }
}
