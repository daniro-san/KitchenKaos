using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour {

    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start() {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, OnSelectedCounterChangedEventArgs e) {
        if (e.selectedCounter == baseCounter) {
            SetSelected(true);
        } else {
            SetSelected(false);
        }
    }

    private void SetSelected(bool isSelected) {
        foreach (GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(isSelected);
        }
    }
}
