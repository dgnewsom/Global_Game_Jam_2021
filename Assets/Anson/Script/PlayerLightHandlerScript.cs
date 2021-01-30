using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightHandlerScript : MonoBehaviour
{
    [Header("Material")]
    [SerializeField] List<Material> materials;
    [Header("Light")]
    [SerializeField] Light playerLight;
    [SerializeField] float playerLightRange;

}
