using MelonLoader;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using StressLevelZero.Rig;

namespace SlowMoPostProcessing
{
    public static class BuildInfo
    {
        public const string Name = "SlowMoPostProcessing";
        public const string Author = "DarkSwitchPro";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = null;
    }

    public class SlowMoPostProcessing : MelonMod
    {
        public override void OnUpdate()
        {
            if (Time.timeScale <= 0.0f)
                return;

            PostProcessVolume v = GameObject.Find("[RigManager (Default Brett)]").GetComponent<RigManager>().gameWorldSkeletonRig.m_head.GetChild(0).GetComponent<PostProcessVolume>();
            ChromaticAberration ab = v.profile.settings[3].Cast<ChromaticAberration>();
            ab.intensity.value = 0.1f / Time.timeScale;
            v.profile.settings[3] = ab;
        }
    }
}
