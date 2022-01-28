using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    [SerializeField]
    Transform _target;

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
        transform.position = Vector3.Lerp(transform.position, _target.position, 0.1f);
    }

    public void ChangeTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
