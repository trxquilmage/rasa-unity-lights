using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDecoder : MonoBehaviour
{
    public static ActionDecoder instance;

    [SerializeField] List<Light> allLights = new List<Light>();

    List<char> light = new List<char>();
    List<char> color = new List<char>();
    List<char> word = new List<char>();
    List<Light> selectedLights = new List<Light>();

    void Start()
    {
        instance = this;
    }

    public void MessageDecoder(string message)
    {
        int plus = 0;
        int ampersand = 0;
        foreach (char c in message)
        {

            if (c == '+')
            {
                plus++;
            }
            else if (c == '&')
            {
                ampersand++;
            }
            else if (ampersand == 1)
            {
                word.Add(c);
            }
            else if (plus == 1)
            {
                light.Add(c);
            }
            else if (plus == 2)
            {
                color.Add(c);
            }
            else if (plus == 0)
            {
                print("something went wrong here, skipping.");
                break;
            }
        }
        if (light.Count != 0 && color.Count != 0 || light.Count != 0 && word.Count != 0)
        {
            string sLight = "";
            string sColor = "";
            string sWord = "";

            foreach (char c in light)
            {
                sLight = sLight + c;
            }
            foreach (char c in color)
            {
                sColor = sColor + c;
            }
            foreach (char c in word)
            {
                sWord = sWord + c;
            }

            switch (sLight)
            {
                case "1":
                    selectedLights.Add(allLights[0]);
                    break;
                case "2":
                    selectedLights.Add(allLights[1]);
                    break;
                case "3":
                    selectedLights.Add(allLights[2]);
                    break;
                case "alle":
                    selectedLights = allLights;
                    break;
            }
            if (sColor != "")
            {
                switch (sColor)
                {
                    case "rot":
                        SetLightsToColor(selectedLights, Color.red);
                        break;
                    case "orange":
                        SetLightsToColor(selectedLights, new Color(0.9f, 0.9f, 0));
                        break;
                    case "gelb":
                        SetLightsToColor(selectedLights, Color.yellow);
                        break;
                    case "gruen":
                        SetLightsToColor(selectedLights, Color.green);
                        break;
                    case "blau":
                        SetLightsToColor(selectedLights, Color.blue);
                        break;
                    case "pink":
                        SetLightsToColor(selectedLights, Color.magenta);
                        break;
                    case "lila":
                        SetLightsToColor(selectedLights, new Color(0.9f, 0, 0.9f));
                        break;
                    case "weiss":
                        SetLightsToColor(selectedLights, Color.white);
                        break;
                    case "grau":
                        SetLightsToColor(selectedLights, Color.grey);
                        break;
                    case "schwarz":
                        SetLightsToColor(selectedLights, Color.black);
                        break;
                }
            }
            else
            {
                SetLightsToIntensity(selectedLights, sWord);
            }
        }

    }

    void SetLightsToColor(List<Light> theLight, Color theColor)
    {
        foreach (Light l in theLight)
        {
            l.color = theColor;
        }
    }

    void SetLightsToIntensity(List<Light> theLight, string theWord)
    {
        foreach (Light l in theLight)
        {
            switch(theWord)
            {
                case "up":
                    l.intensity = l.intensity + 0.4f;
                    break;
                case "down":
                    l.intensity = l.intensity - 0.4f;
                    break;
                case "off":
                    l.intensity = 0;
                    break;
            }
        }
    }
}
