using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicaCloth;
using UnityEngine;

namespace XDiveFeatureParity {
    public static class Utils {
        public static List<Transform> GetAllChildren(this Transform parent) {
            List<Transform> children = new List<Transform>(parent.childCount);
            for (int i = 0; i < parent.childCount; i++)
                children.Add(parent.GetChild(i));
            return children;
        }

        public static void DoNothing() {
            // nothing here but a comment.
        }
    }
}
