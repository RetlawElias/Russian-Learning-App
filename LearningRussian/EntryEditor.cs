using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LearningRussian
{
    public class EntryEditor : Form
    {
        TextBox DE = new TextBox();
        TextBox RU = new TextBox();

        Button saveButton = new Button();
        Button deleteButton = new Button();
        Button russianKeyboard = new Button();

        XElement element;
        string defaultSave;

        public EntryEditor(XElement element, string defaultSave)
        {
            this.element = element;
            this.defaultSave = defaultSave;



            InitializeComponent();

            RU.Enter += TextInput_Enter;
            DE.Enter += TextInput_Enter;
        }

        public void InitializeComponent()
        {
            string german = (string)element.Attribute("DE");
            string russian = (string)element.Attribute("RU");

            SuspendLayout();

            DE.Location = new Point(0, 0);
            DE.Size = new Size(100, 50);
            DE.Text = german;

            RU.Location = new Point(100, 0);
            RU.Size = new Size(100, 50);
            RU.Text = russian;

            saveButton.Text = "Save";
            saveButton.Size = new Size(100, 50);
            saveButton.Location = new Point(0, 50);
            saveButton.Click += (s2, e2) => { saveButton_Click(s2, e2, element, DE.Text, RU.Text); this.Close(); };

            deleteButton.Text = "Delete";
            deleteButton.Size = new Size(100, 50);
            deleteButton.Location = new Point(100, 50);
            deleteButton.Click += (s2, e2) => { deleteButton_Click(s2, e2, element); this.Close(); };

            russianKeyboard.Text = "Rus";
            russianKeyboard.Size = new Size(50, 100);
            russianKeyboard.Location = new Point(200, 0);
            russianKeyboard.Click += russianKeyboard_Click;


            // 
            // EntryEditor
            // 
            ClientSize = new Size(250, 100);
            Controls.Add(DE);
            Controls.Add(RU);
            Controls.Add(saveButton);
            Controls.Add(deleteButton);
            Controls.Add(russianKeyboard);
            Text = "Edit Entry";

            ResumeLayout(false);

        }
        private void TextInput_Enter(object sender, EventArgs e)
        {
            Form1._lastFocusedTextBox = sender as TextBoxBase;
        }

        private void russianKeyboard_Click(object? sender, EventArgs e)
        {
            //if (_lastFocusedTextBox == null) return;

            Form2 keyboard = new Form2();
            keyboard.Show();
        }

        public void saveButton_Click(object? sender, EventArgs e, XElement element, string DE, string RU)
        {
            element.SetAttributeValue("DE", DE);
            element.SetAttributeValue("RU", RU);
            element.Document.Save(defaultSave);
        }

        public void deleteButton_Click(object? sender, EventArgs e, XElement element)
        {
            XDocument doc = element.Document;

            element.Remove();

            doc.Save(defaultSave);
        }
    }
}
