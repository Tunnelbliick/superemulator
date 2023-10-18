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
    public class SpinComputer : StoryboardObjectGenerator
    {
        public override void Generate()
        {

            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png");
            var receportWidth = recepotrBitmap.Width;

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, 18533, 21995, receportWidth, 60f, 0f);
            field.ScalePlayField(18534, 1, OsbEasing.None, 250f, 500f);
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 30);
            field.moveField(18535, 1, OsbEasing.None, 0, -500);
            //field.moveField(19110, 550, OsbEasing.OutSine, 0, 500);

            field.MoveColumnRelative(19110, 350, OsbEasing.None, new Vector2(200, 250), ColumnType.one);
            field.MoveColumnRelative(19110, 350, OsbEasing.None, new Vector2(62.5f, 250), ColumnType.two);
            field.MoveColumnRelative(19110, 350, OsbEasing.None, new Vector2(-62.5f, 250), ColumnType.three);
            field.MoveColumnRelative(19110, 350, OsbEasing.None, new Vector2(-200, 250), ColumnType.four);

            field.MoveColumnRelative(19110 + 350, 350, OsbEasing.None, new Vector2(-200, 250), ColumnType.one);
            field.MoveColumnRelative(19110 + 350, 350, OsbEasing.None, new Vector2(-62.5f, 250), ColumnType.two);
            field.MoveColumnRelative(19110 + 350, 350, OsbEasing.None, new Vector2(62.5f, 250), ColumnType.three);
            field.MoveColumnRelative(19110 + 350, 350, OsbEasing.None, new Vector2(200, 250), ColumnType.four);


            double currentTime = 19110 + 700;
            double duration = 350;
            float width = -250f;

            for (int i = 0; i < 10; i++)
            {
                field.ScalePlayField(currentTime, duration, OsbEasing.InOutSine, width, 500f);
                width *= -1;
                currentTime += duration;
            }

            DrawInstance instance = new DrawInstance(field, 19110, 900f, 40, OsbEasing.None, true);
            instance.drawNotesByOriginToReceptor(21995 - 19110);

        }
    }
}
