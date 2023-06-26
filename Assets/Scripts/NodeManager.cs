using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeManager : MonoBehaviour
{
    public Color hoverColor;
    public Color canBuildColor;
    public Color cannotBuildColor;
    public Vector3 positionOffset;

    [Header("Optional for initialization:")]
    public GameObject mage;

    private Renderer rend;
    private Color startColor;    

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            rend.material.color = cannotBuildColor;
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = canBuildColor;
        } else
        {
            rend.material.color = cannotBuildColor;
        }
        
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            rend.material.color = cannotBuildColor;
            return;
        }

        if (mage != null)
        {
            rend.material.color = cannotBuildColor;
            return;
        }

        buildManager.BuildMageOn(this);
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
