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
using System.Runtime.InteropServices;

namespace StorybrewScripts
{
    public class Floss : StoryboardObjectGenerator
    {

        StoryboardLayer path;

        public override void Generate()
        {

            var receptors = GetLayer("r");
            var notes = GetLayer("n");
            path = GetLayer("p");

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png");
            var receportWidth = recepotrBitmap.Width;

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, 0, 3533, receportWidth, 60f, 0f);
            field.ScalePlayField(-10, 1, OsbEasing.None, 250f, 500f);
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 30);
            field.ZoomMoveAndRotate(2416, 250, OsbEasing.OutSine, new Vector2(0.5f, 0.5f), new Vector2(1000, 0), -Math.PI * 2, 50);

            DrawInstance draw = new DrawInstance(field, 0, 900f, 40, OsbEasing.None, true, 50, 50);
            draw.drawNotesByOriginToReceptor(2850);

            Playfield field2 = new Playfield();
            field2.initilizePlayField(receptors, notes, 1947, 5769, receportWidth, 60f, 0f);
            // Overwrite notestart
            field2.noteStart = 2523;
            field2.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 30);

            field2.ScalePlayField(1950, 1, OsbEasing.None, 250f, 500f);
            field2.moveFieldX(1960, 1, OsbEasing.None, -500);
            field2.moveFieldX(2300, 200, OsbEasing.OutCirc, 500);
            PlayFieldEffect effect = new PlayFieldEffect(field2, 2812, 2956, OsbEasing.InOutSine, 10);
            effect.SwapColumn(ColumnType.two, ColumnType.four);
            PlayFieldEffect effect2 = new PlayFieldEffect(field2, 2956, 3100, OsbEasing.InOutSine, 10);
            effect2.SwapColumn(ColumnType.one, ColumnType.three);
            field2.ScalePlayField(3245, 50, OsbEasing.None, 250f, 500);

            Playfield field3 = new Playfield();
            field3.initilizePlayField(receptors, notes, 3386, 5769, receportWidth, 60f, 0f);
            // Overwrite notestart
            field3.noteStart = 2668;
            field3.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 50);
            field3.ScalePlayField(3388, 1, OsbEasing.None, 250f, -500f);

            Playfield field4 = new Playfield();
            field4.initilizePlayField(receptors, notes, 5000, 11612, receportWidth, 60f, 0f);
            // Overwrite notestart
            field4.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 60);

            Playfield field5 = new Playfield();
            field5.initilizePlayField(receptors, notes, 5000, 11612, receportWidth, 60f, 0f);
            // Overwrite notestart
            field5.initializeNotes(Beatmap.HitObjects.ToList(), notes, 104.0f, 72, 60);

            field4.MoveOriginAbsolute(5001, 1, OsbEasing.None, new Vector2(320, 300), ColumnType.all);
            field5.MoveOriginAbsolute(5001, 1, OsbEasing.None, new Vector2(320, 300), ColumnType.all);

            field4.MoveReceptorAbsolute(5001, 1, OsbEasing.None, new Vector2(320, 240), ColumnType.all);
            field5.MoveReceptorAbsolute(5001, 1, OsbEasing.None, new Vector2(320, 240), ColumnType.all);

            List<Vector2> anchorsOne = new List<Vector2>()
            {
                new Vector2(0,-0),new Vector2(0,0),  new Vector2(-150,0), new Vector2(0,0),
            };

            List<Vector2> anchorsTwo = new List<Vector2>()
            {
                new Vector2(0,-0),new Vector2(0,0),  new Vector2(-75,0), new Vector2(0,0),
            };

            List<Vector2> anchorsThree = new List<Vector2>()
            {
                new Vector2(0,-0), new Vector2(0,0), new Vector2(75,0), new Vector2(0,0),
            };

            List<Vector2> anchorsFour = new List<Vector2>()
            {
                new Vector2(0,-0),new Vector2(0,0),  new Vector2(150,0), new Vector2(0,0),
            };

            List<Vector2> anchorsOneSecond = new List<Vector2>()
            {
                new Vector2(0,-0),new Vector2(0,0),  new Vector2(-125,0), new Vector2(0,0),
            };

            List<Vector2> anchorsTwoSecond = new List<Vector2>()
            {
                new Vector2(0,-0),new Vector2(0,0),  new Vector2(-50,0), new Vector2(0,0),
            };

            List<Vector2> anchorsThreeSecond = new List<Vector2>()
            {
                new Vector2(0,-0), new Vector2(0,0), new Vector2(50,0),new Vector2(0,0),
            };

            List<Vector2> anchorsFourSecond = new List<Vector2>()
            {
                new Vector2(0,-0), new Vector2(0,0), new Vector2(125,0), new Vector2(0,0),
            };


            DrawInstance draw4 = new DrawInstance(field4, 5264, 900f, 30, OsbEasing.None, false, 50, 50);
            draw4.addRelativeAnchorList(ColumnType.one, 5264, anchorsOne, false, receptors);
            draw4.addRelativeAnchorList(ColumnType.two, 5264, anchorsTwo, false, receptors);
            draw4.addRelativeAnchorList(ColumnType.three, 5264, anchorsThree, false, receptors);
            draw4.addRelativeAnchorList(ColumnType.four, 5264, anchorsFour, false, receptors);

            DrawInstance draw5 = new DrawInstance(field5, 5264, 900f, 30, OsbEasing.None, false, 50, 50);
            draw5.addRelativeAnchorList(ColumnType.one, 5264, anchorsOneSecond, false, receptors);
            draw5.addRelativeAnchorList(ColumnType.two, 5264, anchorsTwoSecond, false, receptors);
            draw5.addRelativeAnchorList(ColumnType.three, 5264, anchorsThreeSecond, false, receptors);
            draw5.addRelativeAnchorList(ColumnType.four, 5264, anchorsFourSecond, false, receptors);

            double rotation = 0;
            double rotationPerI = Math.PI / 8;
            double offset = 3822 - 3533;
            double halfOffset = offset / 2;
            double currentTime = 3389;

            for (int i = 0; i < 4; i++)
            {
                field2.RotateAndRescalePlayField(currentTime, halfOffset, OsbEasing.OutCubic, rotationPerI, 100, -200, Playfield.CenterType.middle);
                field2.RotateAndRescalePlayField(currentTime + halfOffset, halfOffset, OsbEasing.OutCubic, rotationPerI, 100, 250, Playfield.CenterType.middle);

                field3.RotateAndRescalePlayField(currentTime, halfOffset, OsbEasing.OutCubic, rotationPerI, 100, -200, Playfield.CenterType.middle);
                field3.RotateAndRescalePlayField(currentTime + halfOffset, halfOffset, OsbEasing.OutCubic, rotationPerI, 100, 250, Playfield.CenterType.middle);
                currentTime += offset;
            }

            field2.RotateAndRescalePlayField(currentTime, 700, OsbEasing.OutCubic, Math.PI, 25, 0, Playfield.CenterType.middle);
            field3.RotateAndRescalePlayField(currentTime, 700, OsbEasing.OutCubic, Math.PI, 25, 0, Playfield.CenterType.middle);

            currentTime += 700;

            float currentOffset = 96f;
            float offsetX = 128f;

            field4.MoveReceptorAbsolute(currentTime, 100, OsbEasing.OutCubic, new Vector2(currentOffset, 60), ColumnType.one);
            currentOffset += offsetX;
            field4.MoveReceptorAbsolute(currentTime + 300, 100, OsbEasing.OutCubic, new Vector2(currentOffset, 60), ColumnType.two);
            currentOffset += offsetX;
            field4.MoveReceptorAbsolute(currentTime + 300, 100, OsbEasing.OutCubic, new Vector2(currentOffset, 60), ColumnType.three);
            currentOffset += offsetX;
            field4.MoveReceptorAbsolute(currentTime, 100, OsbEasing.OutCubic, new Vector2(currentOffset, 60), ColumnType.four);

            currentOffset = 160f;
            offsetX = 128f;


            field5.MoveReceptorAbsolute(currentTime, 100, OsbEasing.OutCubic, new Vector2(currentOffset, 60), ColumnType.one);
            currentOffset += offsetX;
            field5.MoveReceptorAbsolute(currentTime + 300, 100, OsbEasing.OutCubic, new Vector2(currentOffset, 60), ColumnType.two);
            currentOffset += offsetX;
            field5.MoveReceptorAbsolute(currentTime + 300, 100, OsbEasing.OutCubic, new Vector2(currentOffset, 60), ColumnType.three);
            currentOffset += offsetX;
            field5.MoveReceptorAbsolute(currentTime, 100, OsbEasing.OutCubic, new Vector2(currentOffset, 60), ColumnType.four);

            field4.MoveOriginAbsolute(currentTime, 500, OsbEasing.InOutSine, new Vector2(250, 560), ColumnType.all);
            field5.MoveOriginAbsolute(currentTime, 500, OsbEasing.InOutSine, new Vector2(400, 560), ColumnType.all);

            draw4.UpdateAnchors(currentTime, 600, ColumnType.all);
            draw5.UpdateAnchors(currentTime, 600, ColumnType.all);

            field4.MoveReceptorRelative(9302, 100, OsbEasing.None, new Vector2(64, 0), ColumnType.one);
            field5.MoveReceptorRelative(9446, 100, OsbEasing.None, new Vector2(-64, 0), ColumnType.four);

            field4.MoveReceptorRelative(9591, 100, OsbEasing.None, new Vector2(64, 0), ColumnType.one);
            field5.MoveReceptorRelative(9591, 100, OsbEasing.None, new Vector2(64, 0), ColumnType.one);
            field4.MoveReceptorRelative(9591, 100, OsbEasing.None, new Vector2(64, 0), ColumnType.two);

            field5.MoveReceptorRelative(9735, 100, OsbEasing.None, new Vector2(-64, 0), ColumnType.three);
            field5.MoveReceptorRelative(9735, 100, OsbEasing.None, new Vector2(-64, 0), ColumnType.four);
            field4.MoveReceptorRelative(9735, 100, OsbEasing.None, new Vector2(-64, 0), ColumnType.four);

            field5.ScalePlayField(9879, 300, OsbEasing.None, 250f, -500f);
            field4.ScalePlayField(9879, 300, OsbEasing.None, 250f, -500f);


            draw4.UpdateAnchors(9302, 500, ColumnType.all);
            draw5.UpdateAnchors(9302, 500, ColumnType.all);

            draw4.ResetAnchors(9879, 200, OsbEasing.None, ColumnType.all);
            draw5.ResetAnchors(9879, 200, OsbEasing.None, ColumnType.all);


            DrawInstance draw2 = new DrawInstance(field2, 2300, 900f, 30, OsbEasing.None, true, 50, 50);
            draw2.setHoldRotationDeadZone(0);
            draw2.setHoldRotationPrecision(0f);
            draw2.drawNotesByOriginToReceptor(5260 - 2300);

            DrawInstance draw3 = new DrawInstance(field3, 3388, 900f, 30, OsbEasing.None, true, 50, 50);
            //draw3.setHoldRotationDeadZone(0);
            draw3.setHoldRotationPrecision(0f);
            draw3.drawNotesByOriginToReceptor(5260 - 3388);

            draw4.drawNotesByAnchors(10342 - 5264, PathType.bezier);
            draw5.drawNotesByAnchors(10342 - 5264, PathType.bezier);

            flashPathWay(draw4, 5841, 9302, 60000 / 105f);
            flashPathWay(draw5, 5841, 9302, 60000 / 105f);


        }

        void flashPathWay(DrawInstance draw, double start, double endtime, double interval)
        {
            draw.DrawPath(start, endtime, path, "sb/white1x.png", PathType.bezier, 11, 20);

            double currentTime = start;

            while (currentTime < endtime)
            {
                draw.FadePath(currentTime, interval / 2, OsbEasing.InSine, 1, ColumnType.all);
                draw.FadePath(currentTime + interval / 2, interval / 2, OsbEasing.OutSine, 0, ColumnType.all);

                currentTime += interval;
            }

        }
    }
}
