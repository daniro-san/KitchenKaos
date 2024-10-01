using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
    private enum Mode {
        LookAt,
        LookAtInverted,
        CameraFroward,
        CameraFrowardInverted
    }

    [SerializeField] private Mode mode;

    private void LateUpdate() {
        switch(mode) {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;
            case Mode.CameraFroward:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CameraFrowardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
        }
    }
}
