using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyModelHandler : MonoBehaviour
{
    [Range(0f,1f)]
    [SerializeField] float charge;
    [Header("Core")]
    [SerializeField] MeshRenderer coreMesh;
    [SerializeField] Material coreMaterial;
    [Header("Floor")]
    [SerializeField] VisualEffect shardEffect; 


    private void Awake()
    {
        if (coreMaterial == null)
        {
            coreMaterial = coreMesh.material;
        }
    }

    private void FixedUpdate()
    {
        UpdateCharge();
    }


    public void UpdateCharge(float charge)
    {
        this.charge = Mathf.Clamp(charge, 0, 1);
        UpdateCharge();
    }

    public void UpdateCharge()
    {
        coreMaterial.SetFloat("_MainOpacity", charge);
        coreMaterial.SetFloat("_LerpBetweenState", charge);
        shardEffect.SetFloat("MainOpacity", charge);

    }
}
