using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Season))]

public class Vines : MonoBehaviour
{
    public bool VisibleInSpring = true;
    public bool VisibleInSummer = true;

    public bool hasCollider = false;

    public void changeSeason(int seasonId)
    {
       
        if (VisibleInSpring && seasonId == 0)
        {
            transform.GetComponent<Renderer>().enabled = true;
            if (hasCollider)
            {
                transform.GetComponent<BoxCollider>().enabled = true;
            }
            transform.GetComponent<Renderer>().material.color = getSeasonColor(seasonId);
        }
        else if (VisibleInSummer && seasonId == 1)
        {
            transform.GetComponent<Renderer>().enabled = true;
            if (hasCollider)
            {
                transform.GetComponent<BoxCollider>().enabled = true;
            }
            transform.GetComponent<Renderer>().material.color = getSeasonColor(seasonId);
        }
        else
        {
            transform.GetComponent<Renderer>().enabled = false;
            if (hasCollider)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    public Color getSeasonColor(int seasonId)
    {
        if (seasonId == 0)
        {
            return new Color(22 / 255f, 145 / 255f, 16 / 255f); // Spring
        }
        if (seasonId == 1)
        {
            return new Color(75 / 255f, 153 / 255f, 0); // Summer
        }
        if (seasonId == 2)
        {
            return new Color(153 / 255f, 120 / 255f, 0); // Fall
        }
        if (seasonId == 3)
        {
            return new Color(230 / 255f, 230 / 255f, 230 / 255f); // Winter
        }
        return new Color(0, 0, 0); // Error
    }
}
