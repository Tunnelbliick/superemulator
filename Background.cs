using AForge.Imaging;
using OpenTK;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;
using System.Linq;

namespace StorybrewScripts
{
    public class Background : StoryboardObjectGenerator
    {
        [Group("Timing")]
        [Configurable] public int StartTime = 0;
        [Configurable] public int EndTime = 0;

        [Group("Sprite")]
        [Description("Leave empty to automatically use the map's background.")]
        [Configurable] public string SpritePath = "";
        [Configurable] public double Opacity = 0.2;

        public override void Generate()
        {
            if (SpritePath == "") SpritePath = Beatmap.BackgroundPath ?? string.Empty;
            if (StartTime == EndTime) EndTime = (int)(Beatmap.HitObjects.LastOrDefault()?.EndTime ?? AudioDuration);

            var black = GetLayer("").CreateSprite("sb/black.png", OsbOrigin.Centre);
            black.ScaleVec(StartTime, new Vector2(500, 500));
            black.Fade(StartTime - 500, StartTime, 0, Opacity);
            black.Fade(EndTime, EndTime + 500, Opacity, 0);

            var bitmap = GetMapsetBitmap("sb/bg/frames/frame0.jpg");
            var bg = GetLayer("").CreateAnimation("sb/bg/frames/frame.jpg", 262, 100, OsbLoopType.LoopOnce, OsbOrigin.Centre);
            bg.Scale(StartTime, 480.0f / bitmap.Height);
            bg.Fade(StartTime - 500, StartTime, 0, Opacity);
            bg.Fade(EndTime, EndTime + 500, Opacity, 0);

            double currentTime = 3533;
            double duration = 3822 - 3533;
            double rotate = -0.1;
            double nextRotaion = 0;
            double lastRotation = 0.1;


            for (int i = 0; i < 4; i++)
            {
                bg.Scale(OsbEasing.OutCirc, currentTime, currentTime + duration, 2, 480.0f / bitmap.Height);

                lastRotation = rotate;
                currentTime += duration;
            }

            bg.Rotate(OsbEasing.OutCirc, 3533, 3533 + duration, 0, -0.1);
            bg.Rotate(OsbEasing.OutCirc, 3533 + duration, 3533 + duration + duration, -0.1, 0);
            bg.Rotate(OsbEasing.OutCirc, 3533 + duration + duration, 3533 + duration + duration + duration, 0, 0.1);
            bg.Rotate(OsbEasing.OutCirc, 3533 + duration + duration + duration, 3533 + duration + duration + duration, 0.1, 0);

            bg.Scale(OsbEasing.OutSine, 5841, 5841 + 800, 2, 480.0f / bitmap.Height);
            bg.Scale(OsbEasing.OutSine, 6706, 6706 + 800, 2, 480.0f / bitmap.Height);
            bg.Scale(OsbEasing.OutSine, 8148, 8148 + 800, 2, 480.0f / bitmap.Height);
            bg.Scale(OsbEasing.OutSine, 9014, 9014 + 800, 2, 480.0f / bitmap.Height);

        }
    }
}
