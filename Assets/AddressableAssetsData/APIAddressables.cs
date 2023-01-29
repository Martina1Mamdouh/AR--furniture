using RobinBird.FirebaseTools.Storage.Addressables;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;

namespace UnityEditor.AddressableAssets.Build
{
    /// <summary>
    /// Serializable object that can be used to save and restore the state of the editor scene manager.
    /// </summary>
    [Serializable]
    public class APIAddressables : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Addressables.ResourceManager.ResourceProviders.Add(new FirebaseStorageAssetBundleProvider());
            Addressables.ResourceManager.ResourceProviders.Add(new FirebaseStorageJsonAssetProvider());
            Addressables.ResourceManager.ResourceProviders.Add(new FirebaseStorageHashProvider());

            // This requires Addressables >=1.75 and can be commented out for lower versions
            Addressables.InternalIdTransformFunc += FirebaseAddressablesCache.IdTransformFunc;
            FirebaseAddressablesManager.IsFirebaseSetupFinished = true;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
