using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2D시아각 컴포넌트
/// 2DViewAngle Component
/// </summary>
public class ViewAngle2D : MonoBehaviour
{
    /// <summary>
    /// 시아에 보이는 오브젝트들
    /// Object that is visible in the view angle
    /// </summary>
    private List<GameObject> objectsInView;
    public GameObject[] ObjectsInView
    {
        get
        {
            return objectsInView.ToArray();
        }
    }

    [SerializeField] LayerMask _targetMask;
    [SerializeField] LayerMask _obstacleMask;

    [Range(0f, 360f)]
    [SerializeField] float _viewAngle;
    [SerializeField] float _viewDistance;

    private void OnDrawGizmosSelected()
    {
        if (!UnityEditor.EditorApplication.isPlaying)
        {
            findObjectsInView();
        }

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _viewDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * _viewDistance);

        Gizmos.color = Color.yellow;
        Vector3 left = Quaternion.AngleAxis(-_viewAngle / 2, transform.forward) * transform.up * _viewDistance;
        Vector3 right = Quaternion.AngleAxis(_viewAngle / 2, transform.forward) * transform.up * _viewDistance;
        Gizmos.DrawLine(transform.position, transform.position + left);
        Gizmos.DrawLine(transform.position, transform.position + right);

        foreach (GameObject obj in objectsInView)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, obj.transform.position);
        }
    }

    private void isCanSee(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Vector2.Angle(direction, transform.up);
        if (angle < _viewAngle / 2)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _viewDistance, _obstacleMask);
            if (hit.collider == null || hit.collider.gameObject == target.gameObject)
            {
                objectsInView.Add(target.gameObject);
            }
        }
    }

    private void findObjectsInView()
    {
        Collider2D[] targetsinDistance;
        objectsInView.Clear();
        targetsinDistance = Physics2D.OverlapCircleAll(transform.position, _viewDistance, _targetMask);

        foreach (var target in targetsinDistance)
        {
            if (target.gameObject != gameObject)
            {
                isCanSee(target.transform);
            }
        }
    }

    private void Update()
    {
        findObjectsInView();
    }
}
