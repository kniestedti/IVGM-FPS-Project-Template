using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarPuzzle : MonoBehaviour
{
    public GameObject left;
    public GameObject right;

    public Boolean active = true;

    public Material activeMaterial;
    public Material disabledMaterial;

    private MeshRenderer render;
    private PillarPuzzleChecker _checker;

    /**
     * When hit triggers the behaviour.
     */
    public void trigger()
    {
        if (active)
            return;
        
        pillarPuzzle leftPillar = (pillarPuzzle) left.GetComponent(typeof(pillarPuzzle));
        pillarPuzzle rightPillar = (pillarPuzzle) right.GetComponent(typeof(pillarPuzzle));

        leftPillar.active = !leftPillar.active;
        rightPillar.active = !rightPillar.active;
        active = true;
        
        _checker.check();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        render = (MeshRenderer) GetComponent(typeof(MeshRenderer));
        _checker = (PillarPuzzleChecker) GetComponentInParent(typeof(PillarPuzzleChecker));
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            render.material = activeMaterial;
        }
        else
        {
            render.material = disabledMaterial;
        }
    }
}
