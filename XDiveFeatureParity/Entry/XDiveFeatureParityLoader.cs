
using System;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;
using XDiveFeatureParity.Features.InstantFinish;

namespace XDiveFeatureParity.Entry {
    /// <summary>
    /// Entry point into XDiVE. Initializes the UI Element watchers.
    /// </summary>
    public class XDiveFeatureParityLoader : MonoBehaviour {
        public static XDiveFeatureParityLoader Instance;

        public static void Initialize() {
            if (Instance != null) {
                Debug.LogError("Error: UI Element Watchers has already been initialized!");
                return;
            }

            try {
                ClassInjector.RegisterTypeInIl2Cpp<XDiveFeatureParityLoader>();
                ClassInjector.RegisterTypeInIl2Cpp<UIChallengePopupWatcher>();
                ClassInjector.RegisterTypeInIl2Cpp<UIEventStageMainWatcher>();

                GameObject newGameObject = new GameObject("XDiveFeatureParity");
                DontDestroyOnLoad(newGameObject);
                newGameObject.hideFlags = HideFlags.HideAndDontSave;
                Instance = newGameObject.AddComponent<XDiveFeatureParityLoader>();

                Harmony.CreateAndPatchAll(typeof(UIEventStageMainPatches));

                Debug.Log("Initialized XDiveFeatureParityLoader!");
            }
            catch (Exception ex) {
                Debug.LogException(new Il2CppSystem.Exception(ex.ToString()));
                Debug.Log("Failed to initialize XDiveFeatureParityLoader (in Unity hook)");
            }
        }

        void Start() {
            InstantiateObjects();
        }

        public void InstantiateObjects() {
            GameObject uiWatcherGameObject = new GameObject("UiWatchers");
            uiWatcherGameObject.transform.parent = transform;
            uiWatcherGameObject.AddComponent<UIChallengePopupWatcher>();
            uiWatcherGameObject.AddComponent<UIEventStageMainWatcher>();
        }
    }
}
