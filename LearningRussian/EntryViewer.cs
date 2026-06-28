using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace LearningRussian
{
    public class EntryViewer : Form
    {
        string defaultSave;

        public EntryViewer(IEnumerable<XElement> entries, string defaultSave)
        {
            InitializeComponent();

            this.defaultSave = defaultSave;

            int index = 0;
            foreach (XElement entry in entries)
            {
                Label DE = new Label();
                Label RU = new Label();
                Label Score = new Label();

                label1.Size = new Size(panel1.Size.Width / 3, 32);
                label2.Size = new Size(panel1.Size.Width / 3, 32);
                label3.Size = new Size(panel1.Size.Width / 3, 32);
                label1.Location = new Point(0, 0);
                label2.Location = new Point(panel1.Size.Width / 3, 0);
                label3.Location = new Point((panel1.Size.Width / 3) * 2, 0);

                DE.Text = (string)entry.Attribute("DE");
                RU.Text = (string)entry.Attribute("RU");
                Score.Text = (string)entry.Attribute("Score");

                DE.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                DE.Font = new Font("Segoe UI", 12F);
                DE.ForeColor = Color.Black;
                DE.Location = new Point(0, 0 + 30 * index);
                DE.Size = new Size(panel1.Size.Width / 3, 30);
                DE.TextAlign = ContentAlignment.TopLeft;
                DE.Click += (s, e) => DE_Click(s, e, entry);
                panel1?.Controls.Add(DE);

                RU.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                RU.Font = new Font("Segoe UI", 12F);
                RU.ForeColor = Color.Black;
                RU.Location = new Point(panel1.Size.Width / 3, 0 + 30 * index);
                RU.Size = new Size(panel1.Size.Width / 3, 30);
                RU.TextAlign = ContentAlignment.TopLeft;
                RU.Click += (s, e) => DE_Click(s, e, entry);
                panel1?.Controls.Add(RU);

                Score.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                Score.Font = new Font("Segoe UI", 12F);
                Score.ForeColor = Color.Black;
                Score.Location = new Point((panel1.Size.Width / 3) * 2, 0 + 30 * index);
                Score.Size = new Size(panel1.Size.Width / 3, 30);
                Score.TextAlign = ContentAlignment.TopLeft;
                panel1?.Controls.Add(Score);

                index++;
            }
        }

        private void ReloadEntries()
        {
            panel1.Controls.Clear();

            int index = 0;
            foreach (XElement entry in XDocument.Load(defaultSave).Root.Elements())
            {
                Label DE = new Label();
                Label RU = new Label();
                Label Score = new Label();

                DE.Text = (string)entry.Attribute("DE");
                RU.Text = (string)entry.Attribute("RU");
                Score.Text = (string)entry.Attribute("Score");

                DE.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                DE.Font = new Font("Segoe UI", 12F);
                DE.ForeColor = Color.Black;
                DE.Location = new Point(0, 0 + 30 * index);
                DE.Size = new Size(panel1.Size.Width / 3, 30);
                DE.TextAlign = ContentAlignment.TopLeft;
                DE.Click += (s, e) => DE_Click(s, e, entry);
                panel1?.Controls.Add(DE);

                RU.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                RU.Font = new Font("Segoe UI", 12F);
                RU.ForeColor = Color.Black;
                RU.Location = new Point(panel1.Size.Width / 3, 0 + 30 * index);
                RU.Size = new Size(panel1.Size.Width / 3, 30);
                RU.TextAlign = ContentAlignment.TopLeft;
                RU.Click += (s, e) => DE_Click(s, e, entry);
                panel1?.Controls.Add(RU);

                Score.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                Score.Font = new Font("Segoe UI", 12F);
                Score.ForeColor = Color.Black;
                Score.Location = new Point((panel1.Size.Width / 3) * 2, 0 + 30 * index);
                Score.Size = new Size(panel1.Size.Width / 3, 30);
                Score.TextAlign = ContentAlignment.TopLeft;
                panel1?.Controls.Add(Score);

                index++;
            }
        }



        private void DE_Click(object? sender, EventArgs e, XElement element)
        {
            XDocument doc = XDocument.Load(defaultSave);

            EntryEditor editForm = new EntryEditor(element, defaultSave);
            if (editForm.ShowDialog() == DialogResult.Cancel)
            {
                ReloadEntries();
            }
        }



        public void InitializeComponent()
        {
            panel1 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(759, 546);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(759, 35);
            panel4.TabIndex = 3;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(636, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 32);
            label3.TabIndex = 2;
            label3.Text = "Score";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(318, 0);
            label2.Name = "label2";
            label2.Size = new Size(315, 32);
            label2.TabIndex = 1;
            label2.Text = "Russian";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(315, 32);
            label1.TabIndex = 0;
            label1.Text = "German";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EntryViewer
            // 
            ClientSize = new Size(759, 581);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "EntryViewer";
            panel4.ResumeLayout(false);
            ResumeLayout(false);

        }
        private Panel panel4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel1;

    }
}
