using UnityEngine;

[ExecuteInEditMode]
public class Laser : MonoBehaviour {

    [SerializeField]
    private Color _startColor = Color.red;
    [SerializeField]
    private Color _endColor = Color.red;

    private LineRenderer _lr;

    private void Start() {
        _lr = GetComponentInChildren<LineRenderer>();

        _lr.startColor = _startColor;
        _lr.endColor = _endColor;
    }

    private void Update() {
        _lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            if (hit.collider) {
                _lr.SetPosition(1, hit.point);
            }
        } else _lr.SetPosition(1, transform.forward * 5000);
    }

    private void OnValidate() {
        if (_lr == null)
            _lr = GetComponentInChildren<LineRenderer>();

        _lr.startColor = _startColor;
        _lr.endColor = _endColor;
    }

}