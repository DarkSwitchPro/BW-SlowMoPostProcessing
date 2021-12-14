using MelonLoader;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using StressLevelZero.Rig;
using ModThatIsNotMod;

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
        public PostProcessVolume cachedVolume;
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            cachedVolume = ModThatIsNotMod.Player.GetRigManager().GetComponentInChildren<PostProcessVolume>();
        }
        public override void OnUpdate()
        {
            if (Time.timeScale <= 0.0f || cachedVolume == null)
                return;

            ChromaticAberration ab = cachedVolume.profile.settings[3].Cast<ChromaticAberration>();
            ab.intensity.value = 0.1f / Time.timeScale;
            cachedVolume.profile.settings[3] = ab;
        }
    }
}
