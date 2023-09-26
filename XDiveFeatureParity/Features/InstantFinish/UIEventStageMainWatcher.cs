using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace XDiveFeatureParity.Features.InstantFinish {
    /// <summary>
    /// This script patches EventStageMain to fix and re-enable the "Skip DiVE" button.
    /// </summary>
    // public class UIEventStageMainWatcher : UIWatcher<EventStageMain> {
    public class UIEventStageMainWatcher : MonoBehaviour {
        // UIWatcher.cs
        public EventStageMain TargetUi;

        void Update() {
            EventStageMain target = FindObjectOfType<EventStageMain>();
            if (target == null && TargetUi != null) {
                TargetUi = null;
                Debug.Log("EventStageMain was destroyed!");
                OnUiDestroyed();
                return;
            }

            if (target != null && TargetUi == null) {
                TargetUi = target;
                Debug.Log("Found a EventStageMain!");
                OnUiCreated(target);
            }

            On_Update();
        }
        // End UIWatcher.cs

        Button skipButton;
        RectTransform skipButtonRectTransform;

        public void ModifyUI(EventStageMain target) {
            try {
                Transform root = target.transform;
                Transform bottomPanel = root.transform.GetAllChildren().First(t => t.gameObject.name == "BottomPanel");

                skipButton = bottomPanel.transform.GetAllChildren().First(t => t.gameObject.name == "BtnSweep").GetComponent<Button>();
                skipButtonRectTransform = skipButton.GetComponent<RectTransform>();
                ForceUIOn();
            }
            catch (Exception e) {
                Debug.LogError($"UIEventStageMainWatcher Failed to hook into EventStageMain!\n{e}");
            }
        }

        public void OnUiCreated(EventStageMain target) {
            ModifyUI(target);
        }

        public void OnUiDestroyed() {
            skipButton = null;
            skipButtonRectTransform = null;
        }

        void ForceUIOn() {
            skipButton.gameObject.SetActive(true);
            RectTransform skipButtonRectTransform = skipButton.GetComponent<RectTransform>();
            skipButtonRectTransform.anchoredPosition = new Vector2(-500f, 30f);
        }

        void On_Update() {
            if (skipButton != null && skipButtonRectTransform != null) {
                ForceUIOn();
            }
        }
    }
}
