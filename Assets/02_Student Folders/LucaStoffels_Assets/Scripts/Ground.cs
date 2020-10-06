using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Season))]

public class Ground : MonoBehaviour
{
    public void changeSeason(int seasonId)
    {
        transform.GetComponent<Renderer>().material.color = getSeasonColor(seasonId);
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
