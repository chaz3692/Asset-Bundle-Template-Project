using System;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using BepInEx;
using DevHoldableEngine;
using GorillaLocomotion.Swimming;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilla;

namespace CustomGrabbableMod
{
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		public static Plugin instance;
        public static AssetBundle bundle;
        public static GameObject assetBundleParent;
        public static string assetBundleName = "PUT FILE NAME HERE";
        public static string parentName = "BundleParent (put objects in here DONT MOVE)";

        void Start()
		{

			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnEnable()
		{

		}

		void OnDisable()
		{

		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			instance = this;

			//This loads the asset bundle put in the AssetBundles folder
			bundle = LoadAssetBundle("GorillaTagAssetBundleModTemplate.AssetBundles." + assetBundleName);

            //Spawn in Parent
            assetBundleParent = Instantiate(bundle.LoadAsset<GameObject>(parentName));

            //Set Parent Pos (DO NOT CHANGE)
            assetBundleParent.transform.position = new Vector3(-67.2225f, 11.57f, -82.611f);
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
