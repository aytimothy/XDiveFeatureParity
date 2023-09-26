using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XDiveFeatureParity.Entry;

namespace XDiveFeatureParity.Features.InstantFinish {
    /// <summary>
    /// This script re-enables the "Skip DiVE" buttons in the story.
    /// </summary>
    // public class UIChallengePopupWatcher : UIWatcher<UI_ChallengePopup> {
    public class UIChallengePopupWatcher : MonoBehaviour {
        // UIWatcher.cs
        public UI_ChallengePopup TargetUi;

        void Update() {
            UI_ChallengePopup target = FindObjectOfType<UI_ChallengePopup>();
            if (target == null && TargetUi != null) {
                TargetUi = null;
                Debug.Log("UI_ChallengePopup was destroyed!");
                OnUiDestroyed();
                return;
            }

            if (target != null && TargetUi == null) {
                TargetUi = target;
                Debug.Log("Found a UI_ChallengePopup!");
                OnUiCreated(target);
            }
        }
        // End UIWatcher.cs

        public Button skipButton;
        public Button skipButton2;

        void ModifyUI(UI_ChallengePopup target) {
            try {
                Transform root = target.transform;
                Transform normalRoot = root.transform.GetAllChildren().First(t => t.gameObject.name == "NormalRoot");
                Transform challengeRoot = root.transform.GetAllChildren().First(t => t.gameObject.name == "ChallengeRoot");
                Transform bottomInfo = normalRoot.transform.GetAllChildren().First(t => t.gameObject.name == "BottomInfo");
                Transform imgBg0 = normalRoot.transform.GetAllChildren().First(t => t.gameObject.name == "ImgBg0");

                if (!normalRoot.gameObject.activeSelf) {
                    return;
                }
                
                skipButton = bottomInfo.GetAllChildren().First(t => t.gameObject.name == "BtnSweeping").GetComponent<Button>();
                skipButton2 = bottomInfo.GetAllChildren().First(t => t.gameObject.name == "BtnSweeping2").GetComponent<Button>();
                OrangeText energyCostText = bottomInfo.GetAllChildren().First(t => t.gameObject.name == "TextCostValue").GetComponent<OrangeText>();
                RectTransform skipButtonRectTransform = skipButton.GetComponent<RectTransform>();
                RectTransform skipButton2RectTransform = skipButton2.GetComponent<RectTransform>();
                RectTransform backgroundRectTransform = imgBg0.GetComponent<RectTransform>();

                skipButton.gameObject.SetActive(true);
                skipButton2.gameObject.SetActive(true);
                skipButtonRectTransform.anchoredPosition = new Vector2(50, -300f);
                skipButton2RectTransform.anchoredPosition = new Vector2(50f, -400f);
                backgroundRectTransform.anchoredPosition = new Vector2(411.95f, -15f);
                backgroundRectTransform.sizeDelta = new Vector2(1043f, 950f);
            }
            catch (Exception e) {
                Debug.LogError($"UIChallengePopupWatcher Failed to hook into UI_ChallengePopup!\n{e}");
            }
        }

        void CheckCompletionStatus(UI_ChallengePopup target) {
            skipButton.interactable = target.hasClearData;
            skipButton2.interactable = target.hasClearData;
        }

        public void OnUiCreated(UI_ChallengePopup target) {
            ModifyUI(target);
            CheckCompletionStatus(target);
        }

        public void OnUiDestroyed() {
            Utils.DoNothing();
        }
    }
}
