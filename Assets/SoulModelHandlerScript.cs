using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulModelHandlerScript : MonoBehaviour
{
    [SerializeField] List<MeshRenderer> meshRenders;
    [SerializeField] bool isFound;
    //[SerializeField] Vector3 targetPos;
    [SerializeField] float distance;
    [SerializeField] bool hardLock;
    [SerializeField] float detectionRange;
    [SerializeField] float deadZone;
    [Header("Debug")]
    [SerializeField] Transform targetTransform;


    private void FixedUpdate()
    {
        if (targetTransform != null)
        {
            distance = Mathf.Abs((transform.position - targetTransform.position).magnitude);
        }
        //UpdateMaterials();
    }

    public void UpdateMaterials()
    {
        Material m;
        foreach (MeshRenderer mesh in meshRenders)
        {
            m = mesh.material;
            if (isFound)
            {
                m.SetInt("_IsFound", 1);
            }
            else
            {
                m.SetInt("_IsFound", 0);
            }
            //m.SetVector("targetPos", targetPos);
            if (hardLock)
            {
                m.SetInt("_HardLockActive", 1);
            }
            else
            {
                m.SetInt("_HardLockActive", 0);
            }
            m.SetFloat("_Distance", distance);
        }
    }
    /*
    /// <summary>
    /// Update position every frame required
    /// 
    /// </summary>
    /// <param name="pos"></param>
    public void SetTargetPosistion(Vector3 pos)
    {
        targetPos = pos;
        UpdateMaterials();
    }
    */

    /// <summary>
    /// Set is Found, range of the light and a target position
    /// Update position every frame required
    /// </summary>
    /// <param name="b"></param>
    /// <param name="pos"></param>
    public void SetFound(bool b, float detectionRange, float distance)
    {
        isFound = b;
        this.detectionRange = detectionRange;
        this.distance = distance;
        UpdateMaterials();
    }
    /*
    /// <summary>
    /// Set is Found, range of the light and a target position
    /// Update position every frame required
    /// </summary>
    /// <param name="b"></param>
    /// <param name="pos"></param>
    public void SetFound(bool b, float detectionRange, Transform t)
    {
        targetTransform = t;
        isFound = b;
        targetPos = targetTransform.position;
        UpdateMaterials();
    }
    */

    public void SetHardlock(bool b)
    {
        hardLock = b;
        UpdateMaterials();
    }

    public void SetDeadZone(float f)
    {
        deadZone = f;
        UpdateMaterials();
    }

    public void SetDistance(float d)
    {
        distance = d;
    }



}
