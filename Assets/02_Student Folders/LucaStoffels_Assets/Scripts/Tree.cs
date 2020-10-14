using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Season))]

public class Tree : MonoBehaviour
{
    private bool fading = false;
    public float MaxFadeTime = 2;
    private float fadeTime = 0;

    private Transform[] childeren;


    public void Start()
    {
        transform.GetComponent<Damageable>().damageMultiplier = 10;
        transform.GetComponent<Health>().maxHealth = 0.1f;
        transform.GetComponent<BoxCollider>().center = new Vector3(0, 1.6f, 0);
        transform.GetComponent<BoxCollider>().size = new Vector3(0.75f, 3.2f, 0.75f);

        childeren = new Transform[transform.childCount];
        int childId = 0;
        foreach (Transform child in transform)
        {
            childeren[childId] = child;
            childId++;
        }

        fadeTime = MaxFadeTime;
    }

    public void Update()
    {
        if (fading)
        {
            fade();
        }
    }

    public void destroy()
    {
        transform.GetComponent<BoxCollider>().enabled = false;

        for (int i = 0; i < childeren.Length; i++)
        {
            childeren[i].transform.parent = null;
            Rigidbody rb = childeren[i].gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            rb.mass = 5;
            MeshCollider mc = childeren[i].gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
            mc.convex = true;

            rb.velocity = new Vector3((float)UnityEngine.Random.Range(-10,10) / (float)5, (float)UnityEngine.Random.Range(2, 10) / (float)5, (float)UnityEngine.Random.Range(-10, 10) / (float)5);

            changeToFadeRendering(childeren[i].GetComponent<Renderer>().material);
        }
        fading = true;
    }

    public void changeSeason(int seasonId)
    {
        if(childeren == null)
        {
            childeren = new Transform[transform.childCount];
            int childId = 0;
            foreach (Transform child in transform)
            {
                childeren[childId] = child;
                childId++;
            }
        }
        for (int i = 0; i < childeren.Length; i++)
        {
            if (childeren[i].name[0] == 'L')
            {
                childeren[i].GetComponent<Renderer>().material.color = getSeasonColor(seasonId);
            }
            
        }
    }

    public void fade()
    {
        for (int i = 0; i < childeren.Length; i++)
        {
            Color childColor = childeren[i].GetComponent<Renderer>().material.color;
            childColor.a = fadeTime/ MaxFadeTime;
            childeren[i].GetComponent<Renderer>().material.color = childColor;
        }
        fadeTime -= Time.deltaTime;
        if(fadeTime <= 0)
        {
            for (int i = 0; i < childeren.Length; i++)
            {
                Destroy(childeren[i].gameObject);
            }
            Destroy(gameObject);
        }
    }

    public void changeToFadeRendering(Material material)
    {
        material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }

    public Color getSeasonColor(int seasonId)
    {
        if(seasonId == 0)
        {
            return new Color(22/255f, 145 / 255f, 16 / 255f); // Spring
        }
        if (seasonId == 1)
        {
            return new Color(125 / 255f, 153 / 255f, 0); // Summer
        }
        if (seasonId == 2)
        {
            return new Color(153 / 255f, 51 / 255f, 0); // Fall
        }
        if (seasonId == 3)
        {
            return new Color(230 / 255f, 230 / 255f, 230 / 255f); // Winter
        }
        return new Color(0, 0, 0); // Error
    }
}
