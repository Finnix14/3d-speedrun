using UnityEngine;
using UnityEngine.UI;
 
public class FPSDisplay : MonoBehaviour
{
    public int avgFrameRate;
    public Text display_Text;
 
    /*public void Start()
    {
        avgFrameRate = -100;
    }*/

    public void Update ()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";

        //set colour to red
        if(avgFrameRate <= 10) //less than or equal to 10 
            display_Text.color = new Color(255, 0, 0, 255);
        //set colour to orange
        else if(avgFrameRate <= 40) //less than or equal to 40
            display_Text.color = new Color(255, 165, 0, 255);
        //set colour to green
        else if(avgFrameRate >= 41) //greater than or equal to 41
            display_Text.color = new Color(0, 255, 0, 255);
    }
}