using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FPSDisplay : MonoBehaviour
{
    public int avgFrameRate;
    public TMP_Text display_Text;

    public void Update ()
    {
        
        if(Time.timeScale == 1)
        {

            float current = 0;
            current = Time.frameCount / Time.time;
            avgFrameRate = (int)current;
            display_Text.text = avgFrameRate.ToString() + "FPS";
        }

    }
}