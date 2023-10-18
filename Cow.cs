using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Cow : StoryboardObjectGenerator
    {
        public override void Generate()
        {


            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png");
            var receportWidth = recepotrBitmap.Width;

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, 12475, 19687, receportWidth, 60f, 0f);
            field.ScalePlayField(12477, 1, OsbEasing.None, 250f, 500f);
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 30);

            double currentTime = 13341;
            double rotation = Math.PI / 8;
            double currentRotation = rotation;

            for (int i = 0; i < 8; i++)
            {



                field.RotatePlayField(currentTime, 10, OsbEasing.None, currentRotation, 50);
                //currentRotation += rotation;
                //currentRotation *= -1;
                currentTime += 13413 - 13341;
            }

            field.ScalePlayField(13918, 200, OsbEasing.InOutSine, -250f, 500f);
            field.ScalePlayField(13918 + 200, 350, OsbEasing.InOutSine, -250f, -500f);

            field.RotatePlayFieldStatic(14492, 400, OsbEasing.None, Math.PI * 4);
            field.ScalePlayField(14492, 1, OsbEasing.InOutSine, 250f, -500f);

            field.ZoomAndMove(14495, 1, OsbEasing.None, new Vector2(0.4f, 0.4f), new Vector2(-25, 0));
            field.ZoomAndMove(14639, 1, OsbEasing.None, new Vector2(0.35f, 0.35f), new Vector2(-25, 0));
            field.ZoomAndMove(14783, 1, OsbEasing.None, new Vector2(0.3f, 0.3f), new Vector2(-50, 0));
            field.ZoomAndMove(14927, 1, OsbEasing.None, new Vector2(0.25f, 0.25f), new Vector2(-50, 0));
            field.ZoomAndMove(15071, 1, OsbEasing.None, new Vector2(0.3f, 0.3f), new Vector2(0, 0));

            field.RotatePlayField(15073, 1200, OsbEasing.InOutSine, 0.4, 20);
            field.RotatePlayField(15073 + 1200, 1500, OsbEasing.InOutSine, -0.3, 20);
            field.RotatePlayField(15073 + 1200 + 1500, 1200, OsbEasing.InOutSine, -.4, 20);
            field.ZoomMoveAndRotate(15073 + 1200 + 1500 + 1200, 600, OsbEasing.InOutSine, new Vector2(0.4f, 0.4f), new Vector2(-100, 1500), -1, 40);

            DrawInstance instance = new DrawInstance(field, 12692, 900f, 40, OsbEasing.None, true, 50, 50);
            instance.setHoldRotationPrecision(0.01f);
            instance.drawNotesByOriginToReceptor(19687 - 12692);

        }
    }
}
