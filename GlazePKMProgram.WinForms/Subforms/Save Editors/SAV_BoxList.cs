﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

using GlazePKMProgram.Core;
using GlazePKMProgram.WinForms.Controls;

namespace GlazePKMProgram.WinForms
{
    public sealed partial class SAV_BoxList : Form
    {
        private readonly BoxEditor[] Boxes;

        public SAV_BoxList(SAVEditor p, SlotChangeManager m)
        {
            InitializeComponent();
            WinFormsUtil.TranslateInterface(this, Main.CurrentLanguage);

            // initialize boxes dynamically
            var sav = p.SAV;

            Boxes = new BoxEditor[sav.BoxCount];
            AddControls(p, m, sav);
            SetWindowDimensions(sav.BoxCount);

            AllowDrop = true;
            AddEvents();
            CenterToParent();
            Owner = p.ParentForm;
            foreach (var b in Boxes)
                m.Env.Slots.Publisher.Subscribers.Add(b);
            FormClosing += (sender, e) =>
            {
                foreach (var b in Boxes)
                {
                    b.M?.Boxes.Remove(b);
                    m.Env.Slots.Publisher.Subscribers.Remove(b);
                }
            };
        }

        private void AddEvents()
        {
            GiveFeedback += (sender, e) => e.UseDefaultCursors = false;
            DragEnter += Main_DragEnter;
            DragDrop += (sender, e) =>
            {
                Cursor = DefaultCursor;
                System.Media.SystemSounds.Asterisk.Play();
            };
        }

        private void AddControls(SAVEditor p, SlotChangeManager m, SaveFile sav)
        {
            for (int i = 0; i < sav.BoxCount; i++)
            {
                var boxEditor = new BoxEditor
                {
                    Name = $"BE_Box{i:00}",
                    Margin = new Padding(1),
                    Editor = new BoxEdit(sav),
                };
                boxEditor.Setup(m);
                boxEditor.InitializeGrid();
                boxEditor.Reset();
                foreach (PictureBox pb in boxEditor.SlotPictureBoxes)
                    pb.ContextMenuStrip = p.SlotPictureBoxes[0].ContextMenuStrip;
                boxEditor.CurrentBox = i;
                boxEditor.CB_BoxSelect.Enabled = false;
                Boxes[i] = boxEditor;
            }
            FLP_Boxes.Controls.AddRange(Boxes);

            // Setup swapping
            foreach (var box in Boxes)
            {
                box.ClearEvents();
                box.B_BoxLeft.Click += (s, e) =>
                {
                    if (s == null)
                        return;
                    int index = Array.IndexOf(Boxes, ((Button)s).Parent);
                    int other = (index + Boxes.Length - 1) % Boxes.Length;
                    m.SwapBoxes(index, other, p.SAV);
                };
                box.B_BoxRight.Click += (s, e) =>
                {
                    if (s == null)
                        return;
                    int index = Array.IndexOf(Boxes, ((Button)s).Parent);
                    int other = (index + 1) % Boxes.Length;
                    m.SwapBoxes(index, other, p.SAV);
                };
            }
        }

        private void SetWindowDimensions(int count)
        {
            // adjust layout to stack up boxes
            var sqrt = Math.Sqrt(count);
            int height = Math.Min(5, (int)Math.Ceiling(sqrt));
            int width = (int)Math.Ceiling((float)count / height);
            Debug.Assert(height * width >= count);
            width = Math.Min(4, width);

            var padWidth = (Boxes[0].Margin.Horizontal * 2) + 1;
            Width = ((Boxes[0].Width + padWidth) * width) - (padWidth / 2) + 0x10;

            var padHeight = (Boxes[0].Margin.Vertical * 2) + 1;
            Height = ((Boxes[0].Height + padHeight) * height) - (padHeight / 2);
        }

        private static void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link)) // external file
                e.Effect = DragDropEffects.Copy;
            else if (e.Data != null) // within
                e.Effect = DragDropEffects.Move;
        }
    }
}
