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
using System.Drawing;
using System.Linq;

namespace StorybrewScripts
{
    public class Jumps : StoryboardObjectGenerator
    {
        StoryboardLayer path;
        StoryboardLayer notes;
        StoryboardLayer receptors;

        float receportWidth;

        public override void Generate()
        {

            receptors = GetLayer("r");
            notes = GetLayer("n");
            path = GetLayer("p");

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png");
            receportWidth = recepotrBitmap.Width;

            initializePlayfield(10342, 10700, 10384, new Vector2(0, 0), new Vector2(0.5f, 0.5f));
            initializePlayfield(10745, 11033, 10745, new Vector2(200, 0), new Vector2(0.3f, 0.3f));
            initializePlayfield(11033, 11321, 11033, new Vector2(-200, 50), new Vector2(0.25f, 0.25f));
            initializePlayfield(11321, 11610, 11321, new Vector2(100, 50), new Vector2(0.4f, 0.4f));
            initializePlayfield(11610, 11898, 11610, new Vector2(-100, -50), new Vector2(0.3f, 0.3f));
            initializePlayfield(11898, 12187, 11610, new Vector2(300, 0), new Vector2(0.4f, 0.4f));
            initializePlayfieldUpsideDown(12187, 12475, 12187, new Vector2(-200, -100), new Vector2(0.35f, 0.35f));
            initializePlayfieldStreched(12475, 12692, 12475, new Vector2(-100, -50), new Vector2(0.4f, 0.4f));

        }

        void jump(Playfield field, double time)
        {
            field.MoveColumnRelative(time, 75, OsbEasing.InSine, new Vector2(0, -80), ColumnType.all);
            field.MoveColumnRelative(time + 75, 75, OsbEasing.OutSine, new Vector2(0, 80), ColumnType.all);
        }

        void initializePlayfield(double showTime, double hideTime, double jumpTime, Vector2 offset, Vector2 scale)
        {

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, 10312, 14495, receportWidth, 60f, 0f);
            field.ScalePlayField(10340, 1, OsbEasing.None, 250f, -500f);
            field.ZoomAndMove(10342, 1, OsbEasing.None, scale, offset);
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 30);
            jump(field, jumpTime);

            DrawInstance instance = new DrawInstance(field, showTime, 900, 30, OsbEasing.None, true, 0, 50);
            instance.drawNotesByOriginToReceptor(hideTime - showTime);

        }

        void initializePlayfieldUpsideDown(double showTime, double hideTime, double jumpTime, Vector2 offset, Vector2 scale)
        {

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, 10312, 14495, receportWidth, 60f, 0f);
            field.ScalePlayField(10340, 1, OsbEasing.None, 250f, 500f);
            field.ZoomAndMove(10342, 1, OsbEasing.None, scale, offset);
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 30);
            jump(field, jumpTime);

            DrawInstance instance = new DrawInstance(field, showTime, 900, 30, OsbEasing.None, true, 0, 50);
            instance.drawNotesByOriginToReceptor(hideTime - showTime);

        }

        void initializePlayfieldStreched(double showTime, double hideTime, double jumpTime, Vector2 offset, Vector2 scale)
        {

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, 10312, 14495, receportWidth, 60f, 0f);
            field.ScalePlayField(10340, 1, OsbEasing.None, 300f, -500f);
            field.ZoomAndMove(10342, 1, OsbEasing.None, scale, offset);
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 30);
            jump(field, jumpTime);

            DrawInstance instance = new DrawInstance(field, showTime, 900, 30, OsbEasing.None, true, 0, 50);
            instance.drawNotesByOriginToReceptor(hideTime - showTime);

        }
    }
}
