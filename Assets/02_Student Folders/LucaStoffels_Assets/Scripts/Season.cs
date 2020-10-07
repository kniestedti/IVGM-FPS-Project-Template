using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Season : MonoBehaviour
{
    public int season = 0;

    public bool isTree = false;
    public bool isGround = false;
    public bool isSnow = false;
    public bool isVines = false;
    public bool isTimerRespawner = false;

    public void Start()
    {
        season = 1;
        adjustSeason();
    }

    public void nextSeason()
    {
        season++;
        season = season % 4;
        adjustSeason();
    }

    void adjustSeason()
    {
        if (isTree)
        {
            transform.GetComponent<Tree>().changeSeason(season);
        }
        if (isGround)
        {
            transform.GetComponent<Ground>().changeSeason(season);
        }
        if (isSnow)
        {
            transform.GetComponent<Snow>().changeSeason(season);
        }
        if (isVines)
        {
            transform.GetComponent<Vines>().changeSeason(season);
        }
        if (isTimerRespawner)
        {
            transform.GetComponent<TimerRespawner>().changeSeason(season);
        }
    }
}
