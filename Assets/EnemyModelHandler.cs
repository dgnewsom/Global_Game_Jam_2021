using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyModelHandler : MonoBehaviour
{
    [Range(0f,1f)]
    [SerializeField] float charge;
    [SerializeField] AnimationCurve opacityCurve;
    [Header("Core")]
    [SerializeField] MeshRenderer coreMesh;
    [SerializeField] Material coreMaterial;
    [Header("Floor")]
    [SerializeField] VisualEffect shardEffect;
    [Header("Animator")]
    [SerializeField] Animator animator;
    [Header("Sound")]
    [SerializeField] Sound Sound_Ambient;
    [SerializeField] Sound Sound_Charge;
    [SerializeField] Sound Sound_Attack;


    private void Awake()
    {
        if (coreMaterial == null)
        {
            coreMaterial = coreMesh.material;
        }
        animator = GetComponent<Animator>();
        Sound_Ambient.Play();
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
        
        coreMaterial.SetFloat("_MainOpacity", opacityCurve.Evaluate(charge));
        coreMaterial.SetFloat("_LerpBetweenState", charge);
        shardEffect.SetFloat("MainOpacity", opacityCurve.Evaluate(charge));

    }
    public void PlayAnim_Death()
    {
        animator.SetTrigger("Die");
    }

    public void PlayAnim_Reset()
    {
        animator.SetTrigger("Reset");
    }
    public void PlaySound_Charge()
    {
        print("Play charge");
        Sound_Charge.Play();
    }

    public void PlaySound_Attack()
    {
        Sound_Attack.Play();
    }
}
