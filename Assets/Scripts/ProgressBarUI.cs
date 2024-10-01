using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour {
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image progressBarImage;

    private IHasProgress hasProgress;

    private void Start() {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();

        if(hasProgress == null) {
            Debug.LogError("Game Object " + hasProgressGameObject + " does not implement IHasProgress!");
        }
        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        progressBarImage.fillAmount = 0f;

        ToggeProgressBar(false);
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e) {
        progressBarImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0f || e.progressNormalized == 1f) {
            ToggeProgressBar(false);
        } else {
            ToggeProgressBar(true);
        }
    }

    private void ToggeProgressBar(bool value) {
        gameObject.SetActive(value);
    }
}
