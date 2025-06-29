/*
Copyright (c) 2025 Xavier Arpa López Thomas Peter ('xavierarpa')

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#if UNITY_EDITOR
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace UniFlux.Toolkit.Editor
{
    public static class UniFluxToolkitMenuItems
    {
        private const int PRIORITY = 1;
        private const string PATH_TOP = "Tools/UniFlux/Toolkit/";
        private const string PATH_HIERARCHY = "GameObject/UniFlux Toolkit/";

        [MenuItem(PATH_HIERARCHY + nameof(ButtonFlux), false, PRIORITY)]
        [MenuItem(PATH_TOP + nameof(ButtonFlux), priority = PRIORITY)]
        private static void Create_ButtonFlux(MenuCommand cmd)
        {
            Create<ButtonFlux>(cmd, nameof(ButtonFlux));
        }

        [MenuItem(PATH_HIERARCHY + nameof(DropdownFlux), false, PRIORITY)]
        [MenuItem(PATH_TOP + nameof(DropdownFlux), priority = PRIORITY)]
        private static void Create_DropdownFlux(MenuCommand cmd)
        {
            Create<DropdownFlux>(cmd, nameof(DropdownFlux));
        }

        [MenuItem(PATH_HIERARCHY + nameof(InputFlux), false, PRIORITY)]
        [MenuItem(PATH_TOP + nameof(InputFlux), priority = PRIORITY)]
        private static void Create_InputFlux(MenuCommand cmd)
        {
            Create<InputFlux>(cmd, nameof(InputFlux));
        }

        [MenuItem(PATH_HIERARCHY + nameof(SliderFlux), false, PRIORITY)]
        [MenuItem(PATH_TOP + nameof(SliderFlux), priority = PRIORITY)]
        private static void Create_SliderFlux(MenuCommand cmd)
        {
            Create<SliderFlux>(cmd, nameof(SliderFlux));
        }

        [MenuItem(PATH_HIERARCHY + nameof(IndexButtonFlux), false, PRIORITY)]
        [MenuItem(PATH_TOP + nameof(IndexButtonFlux), priority = PRIORITY)]
        private static void Create_TabButtonFlux(MenuCommand cmd)
        {
            Create<IndexButtonFlux>(cmd, nameof(IndexButtonFlux));
        }

        [MenuItem(PATH_HIERARCHY + nameof(TabFlux), false, PRIORITY)]
        [MenuItem(PATH_TOP + nameof(TabFlux), priority = PRIORITY)]
        private static void Create_TabFlux(MenuCommand cmd)
        {
            Create<TabFlux>(cmd, nameof(TabFlux));
        }

        [MenuItem(PATH_HIERARCHY + nameof(ToggleFlux), false, PRIORITY)]
        [MenuItem(PATH_TOP + nameof(ToggleFlux), priority = PRIORITY)]
        private static void Create_ToggleFlux(MenuCommand cmd)
        {
            Create<ToggleFlux>(cmd, nameof(ToggleFlux));
        }

        private static void Create<T>(MenuCommand cmd, string assetName) where T : Object
        {
            var prefab = GetAsset<T>(assetName);
            InstantiateAsset(cmd, prefab, assetName);
        }

        private static GameObject InstantiateAsset(MenuCommand cmd, Object prefab, string operationName)
        {
            var instance = PrefabUtility.InstantiatePrefab(prefab);
            var instanceObject = instance.GameObject();
            GameObjectUtility.SetParentAndAlign(instanceObject, cmd.context as GameObject);
            Undo.RegisterCreatedObjectUndo(instanceObject, operationName);
            Selection.activeGameObject = instanceObject;
            return instanceObject;
        }

        private static T GetAsset<T>(string assetName) where T : Object
        {
            string guid = AssetDatabase.FindAssets(assetName).FirstOrDefault();

            if (string.IsNullOrEmpty(guid))
            {
                return null;
            }

            string path = AssetDatabase.GUIDToAssetPath(guid);

            var prefab = AssetDatabase.LoadAssetAtPath<T>(path);

            return prefab;
        }
    }
}
#endif
