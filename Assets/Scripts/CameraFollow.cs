using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    [SerializeField]
    Transform _target;
    [SerializeField]
    float _dampTime = 0.15f;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if(_target != null)
        {
            float point = Camera.main.WorldToViewportPoint(_target.position).x;
            float delta = _target.position.x - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).x;
            float destination = transform.position.x + delta;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(destination, 0, -10), ref velocity, _dampTime);
        }
    }

    public void ChangeTarget(Transform newTarget)
    {
        _target = newTarget;
    }

    public Transform GetTargetTransform()
    {
        return _target;
    }
}
