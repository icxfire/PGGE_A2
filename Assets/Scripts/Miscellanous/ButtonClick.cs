using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void ButtonClicked_S()
    {
        SoundScript.instance.OnClick_Single();
    }

    public void ButtonClicked_M()
    {
        SoundScript.instance.OnClick_Multi();
    }

    public void ButtonClicked_J()
    {
        SoundScript.instance.OnClick_Join();
    }

    public void ButtonClicked_B()
    {
        SoundScript.instance.OnClick_Back();
    }
}
