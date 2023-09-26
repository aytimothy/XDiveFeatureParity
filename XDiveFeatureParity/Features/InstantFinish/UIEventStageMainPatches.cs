using System;
using HarmonyLib;
using Il2CppSystem;
using Il2CppSystem.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace XDiveFeatureParity.Features.InstantFinish {
    public static class UIEventStageMainPatches {
        delegate void OnUiLoadedDelegate<T>(T ui) where T : UnityEngine.Component;

        [HarmonyPatch(typeof(EventStageMain), nameof(EventStageMain.OnClickSweep))]
        [HarmonyPrefix]
        public static void OnClickSweep(EventStageMain __instance) {
            ShowTip("UI not implemented for OnClickSweep().");
            UnityEngine.Debug.Log("UI not implemented for OnClickSweep().");
        }

        public static unsafe void ShowTip(string text) {
            OnUiLoadedDelegate<TipUI> callbackDelegate = OnUiLoaded<TipUI>;
            if (callbackDelegate == null) {
                Debug.LogError("callbackDelegate is null!!!");
                throw new System.Exception("callbackDelegate is null!!!");
            }

            System.IntPtr callbackPointer = IntPtr.Zero;
            callbackPointer = Marshal.GetFunctionPointerForDelegate(callbackDelegate);
            if (callbackPointer == IntPtr.Zero) {
                Debug.LogError("callbackPointer is null!!!");
                throw new System.Exception("callbackPointer is null!!!");
            }

            UIManager.LoadUIComplete<TipUI> callback = new UIManager.LoadUIComplete<TipUI>(callbackPointer);
            UIManager.Instance.LoadUI<TipUI>(text, callback);
        }

        public static unsafe void OnUiLoaded<T>(T ui) where T : UnityEngine.Component {
            if (ui is TipUI) {
                TipUI tip = ui as TipUI;
                UIManager.Instance.AddUI(tip);
                tip.textMsg.text = "TEST TEXT";
                tip.textMsg.UpdateTextImmediate();
                UIManager.Instance.AdditionalEft_FadeIn(tip);
            }
            else {
                Debug.LogError($"ui is not TipUI!!! (It is {ui.GetType().FullName})");
                throw new System.Exception($"ui is not TipUI!!! (It is {ui.GetType().FullName})");
            }
        }
    }
}
