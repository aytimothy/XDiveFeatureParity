/*
 *  THIS CLASS IS DISABLED BECAUSE GENERICS IS NOT SUPPORTED >:(
 *  SEE https://github.com/BepInEx/Il2CppInterop/issues/22
 */

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using UnityEngine;
// using UnityEngine.Events;
// using Object = UnityEngine.Object;
// 
// namespace XDiveFeatureParity.Entry {
//     /// <summary>
//     /// Base class for injecting into UI.
//     /// </summary>
//     /// <typeparam name="T">The desired screen to watch for.</typeparam>
//     public abstract class UIWatcher<T> : MonoBehaviour where T : OrangeUIBase {
//         public T TargetUi;
// 
//         public UnityEvent<T> _OnUiCreated = new UnityEvent<T>();
//         public UnityEvent _OnUiDestroyed = new UnityEvent();
// 
//         void Update() {
//             T target = Object.FindObjectOfType<T>();
//             if (target == null && TargetUi != null) {
//                 TargetUi = null;
//                 _OnUiDestroyed.Invoke();
//                 OnUiDestroyed();
//                 return;
//             }
// 
//             if (target != null && TargetUi == null) {
//                 TargetUi = target;
//                 _OnUiCreated.Invoke(target);
//                 OnUiCreated(target);
//             }
//         }
// 
//         public abstract void OnUiCreated(T target);
//         public abstract void OnUiDestroyed();
//     }
// }
