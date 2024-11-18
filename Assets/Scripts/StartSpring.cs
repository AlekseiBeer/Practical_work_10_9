using UnityEngine;

public class StartSpring : MonoBehaviour
{
    private Rigidbody rb;
    private ConfigurableJoint _configurableJoint;

    public float _cycleDelay = 2f;
    private float _timer = 0f;
    private bool _isPulling = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _configurableJoint = rb.GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        Vector3 locPos = transform.localPosition;
        JointDrive JD = _configurableJoint.zDrive;

        _timer += Time.deltaTime;

        if (_isPulling)
        {
            locPos.z = transform.localPosition.z <= -11f ? locPos.z : locPos.z - 1f * Time.deltaTime;
            JD.positionSpring = 0;
            _configurableJoint.zDrive = JD;

            if (_timer >= _cycleDelay)
            {
                _isPulling = false;
                _timer = 0f;
            }
        }
        else
        {
            JD.positionSpring = 100000;
            _configurableJoint.zDrive = JD;

            if (_timer >= _cycleDelay)
            {
                _isPulling = true;
                _timer = 0f;
            }
        }
        transform.localPosition = locPos;
    }
}