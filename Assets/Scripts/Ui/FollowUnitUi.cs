using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUnitUi : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 20.0f;
    private Transform targetTranfsform;
    private RectTransform rectTransform;

   public void SetUp(Transform target)
    {
        targetTranfsform = target;
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTranfsform.position);
        rectTransform.position = screenPosition + distance;
    }
}
