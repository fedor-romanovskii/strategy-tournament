using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersTest : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log($"PlayerParameters.baseHP:{PlayerParameters.baseHP}");
        Debug.Log($"PlayerParameters.baseDamage:{PlayerParameters.baseDamage}");
        Debug.Log($"PlayerParameters.goldSpeed:{PlayerParameters.goldSpeed}");
        Debug.Log($"PlayerParameters.lumberSpeed:{PlayerParameters.lumberSpeed}");
        Debug.Log($"PlayerParameters.unitPrice:{PlayerParameters.unitPrice}");
        Debug.Log($"PlayerParameters.upgradePrice:{PlayerParameters.upgradePrice}");
        Debug.Log($"PlayerParameters.moveSpeed:{PlayerParameters.moveSpeed}");
        Debug.Log($"PlayerParameters.detectionRange:{PlayerParameters.detectionRange}");
    }
}
