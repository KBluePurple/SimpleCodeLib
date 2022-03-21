using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2D 시아 스크립트
/// </summary>
public class ViewAngle2D : MonoBehaviour
{
    /// <summary>
    /// 현재 보이는 물체들
    /// </summary>
    [HideInInspector] public List<GameObject> ObjectsInView;

    [SerializeField] LayerMask _targetMask;
    [SerializeField] float _viewAngle;
    [SerializeField] float _viewDistance;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _viewDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * _viewDistance);

        Gizmos.color = Color.yellow;
        Vector3 left = Quaternion.AngleAxis(-_viewAngle / 2, transform.forward) * transform.up * _viewDistance;
        Vector3 right = Quaternion.AngleAxis(_viewAngle / 2, transform.forward) * transform.up * _viewDistance;
        Gizmos.DrawLine(transform.position, transform.position + left);
        Gizmos.DrawLine(transform.position, transform.position + right);
    }

    private void isCanSee(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < _viewAngle / 2)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, _viewDistance, _targetMask!))
            {
                if (hit.transform == target)
                {
                    ObjectsInView.Add(target.gameObject);
                }
            }
        }
    }

    private void Update()
    {
        var targetsinDistance = new List<Collider2D>();
        ObjectsInView.Clear();
        GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(), targetsinDistance);

        foreach (var target in targetsinDistance)
        {
            isCanSee(target.transform);
        }
    }
}
