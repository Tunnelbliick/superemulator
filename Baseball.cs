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
using System.IO;
using System.Linq;

namespace StorybrewScripts
{
    public class Baseball : StoryboardObjectGenerator
    {
        public override void Generate()
        {

            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png");
            var receportWidth = recepotrBitmap.Width;

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, 20841, 26610, receportWidth, 60f, 0f);
            field.ScalePlayField(20842, 1, OsbEasing.None, 250f, 500f);
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 30);

            List<Vector2> anchors = new List<Vector2>() {
                new Vector2(0,0),
                new Vector2(0,0),
             new Vector2(0,0),
             new Vector2(0,0),
            };

            field.MoveOriginAbsolute(20843, 1, OsbEasing.None, new Vector2(500, 110), ColumnType.one);
            field.MoveOriginAbsolute(20843, 1, OsbEasing.None, new Vector2(505, 110), ColumnType.two);
            field.MoveOriginAbsolute(20843, 1, OsbEasing.None, new Vector2(510, 110), ColumnType.three);
            field.MoveOriginAbsolute(20843, 1, OsbEasing.None, new Vector2(515, 110), ColumnType.four);

            DrawInstance instance = new DrawInstance(field, 20843, 900f, 40, OsbEasing.None, false);
            instance.addRelativeAnchorList(ColumnType.all, 20841, anchors, false, receptors);

            field.ScaleOrigin(20842, 1, OsbEasing.None, new Vector2(0.02f, 0.02f), ColumnType.all);
            field.ScaleReceptor(20842, 1, OsbEasing.None, new Vector2(0.02f, 0.02f), ColumnType.all);

            field.MoveReceptorAbsolute(20843, 1, OsbEasing.None, new Vector2(500, 120), ColumnType.one);
            field.MoveReceptorAbsolute(20843, 1, OsbEasing.None, new Vector2(505, 120), ColumnType.two);
            field.MoveReceptorAbsolute(20843, 1, OsbEasing.None, new Vector2(510, 120), ColumnType.three);
            field.MoveReceptorAbsolute(20843, 1, OsbEasing.None, new Vector2(515, 120), ColumnType.four);

            field.MoveOriginAbsolute(21850, 1, OsbEasing.None, new Vector2(575, 440), ColumnType.one);
            field.MoveOriginAbsolute(21850, 1, OsbEasing.None, new Vector2(575, 440), ColumnType.two);
            field.MoveOriginAbsolute(21850, 1, OsbEasing.None, new Vector2(575, 440), ColumnType.three);
            field.MoveOriginAbsolute(21850, 1, OsbEasing.None, new Vector2(575, 440), ColumnType.four);

            field.MoveReceptorAbsolute(21418, 300, OsbEasing.None, new Vector2(250, 120), ColumnType.one);
            field.MoveReceptorAbsolute(21418, 200, OsbEasing.None, new Vector2(220, 170), ColumnType.two);
            field.MoveReceptorAbsolute(21418, 300, OsbEasing.None, new Vector2(210, 240), ColumnType.three);
            field.MoveReceptorAbsolute(21418, 300, OsbEasing.None, new Vector2(250, 300), ColumnType.four);

            field.ScaleReceptor(21418, 300, OsbEasing.None, new Vector2(0.4f, 0.4f), ColumnType.all);

            instance.UpdateAnchors(20841, 21418 + 300 - 20841, ColumnType.all);

            instance.ManipulateAnchorAbsolute(0, 21418 + 301, 1, new Vector2(590, 440), OsbEasing.None, ColumnType.all);
            instance.ManipulateAnchorAbsolute(1, 21418 + 301, 1, new Vector2(575, 150), OsbEasing.None, ColumnType.one);
            instance.ManipulateAnchorAbsolute(1, 21418 + 301, 1, new Vector2(575, 175), OsbEasing.None, ColumnType.two);
            instance.ManipulateAnchorAbsolute(1, 21418 + 301, 1, new Vector2(575, 200), OsbEasing.None, ColumnType.three);
            instance.ManipulateAnchorAbsolute(1, 21418 + 301, 1, new Vector2(575, 225), OsbEasing.None, ColumnType.four);

            instance.ManipulateAnchorAbsolute(2, 21418 + 301, 1, new Vector2(350, 150), OsbEasing.None, ColumnType.one);
            instance.ManipulateAnchorAbsolute(2, 21418 + 301, 1, new Vector2(350, 175), OsbEasing.None, ColumnType.two);
            instance.ManipulateAnchorAbsolute(2, 21418 + 301, 1, new Vector2(350, 200), OsbEasing.None, ColumnType.three);
            instance.ManipulateAnchorAbsolute(2, 21418 + 301, 1, new Vector2(350, 225), OsbEasing.None, ColumnType.four);

            instance.ResetAnchors(24000, 1, OsbEasing.None, ColumnType.all);
            field.ScalePlayField(24014, 300, OsbEasing.None, 250, 500f);

            instance.UpdateAnchors(24010, 400, ColumnType.all);

            instance.setHoldScalePrecision(0f);
            instance.drawNotesByAnchors(26610 - 20843, PathType.bezier);


        }
    }
}
