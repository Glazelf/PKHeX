﻿using System;
using System.Collections.Generic;

namespace GlazePKMProgram.Core
{
    public sealed class BoxManipSortComplex : BoxManipBase
    {
        private readonly Func<IEnumerable<PKM>, SaveFile, int, IEnumerable<PKM>> Sorter;
        public BoxManipSortComplex(BoxManipType type, Func<IEnumerable<PKM>, SaveFile, IEnumerable<PKM>> sorter) : this(type, sorter, _ => true) { }
        public BoxManipSortComplex(BoxManipType type, Func<IEnumerable<PKM>, SaveFile, IEnumerable<PKM>> sorter, Func<SaveFile, bool> usable) : base(type, usable) => Sorter = (pkms, file, _) => sorter(pkms, file);

        public BoxManipSortComplex(BoxManipType type, Func<IEnumerable<PKM>, SaveFile, int, IEnumerable<PKM>> sorter) : this(type, sorter, _ => true) { }
        public BoxManipSortComplex(BoxManipType type, Func<IEnumerable<PKM>, SaveFile, int, IEnumerable<PKM>> sorter, Func<SaveFile, bool> usable) : base(type, usable) => Sorter = sorter;

        public override string GetPrompt(bool all) => all ? MessageStrings.MsgSaveBoxSortAll : MessageStrings.MsgSaveBoxSortCurrent;
        public override string GetFail(bool all) => all ? MessageStrings.MsgSaveBoxSortAllFailBattle : MessageStrings.MsgSaveBoxSortCurrentFailBattle;
        public override string GetSuccess(bool all) => all ? MessageStrings.MsgSaveBoxSortAllSuccess : MessageStrings.MsgSaveBoxSortCurrentSuccess;

        public override int Execute(SaveFile sav, BoxManipParam param)
        {
            IEnumerable<PKM> Method(IEnumerable<PKM> p, int index) => Sorter(p, sav, index);
            return sav.SortBoxes(param.Start, param.Stop, Method, param.Reverse);
        }
    }
}