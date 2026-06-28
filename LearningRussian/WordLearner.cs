using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace LearningRussian
{
    public class WordLearner : Form
    {
        List<string> germanWords = new List<string>();
        List<string> russianWords = new List<string>();
        Random r = new Random();
        
        int wordIndex = 0;
        int languageDirection = 0;
        int sessionWords = 0;

        bool awaitContinue = false;

        string fileReference;

        private Label label2;
        private Label label3;
        private Button button2;

        public WordLearner(string fileReference, SessionDetails sessionDetails)
        {
            this.fileReference = fileReference;
            
            InitializeComponent();

            textBox1.Enter += (s2, e2) => { TextInput_Enter(s2, e2); textBox1.Focus(); };

            LoadInstance(sessionDetails);
        }

        private void TextInput_Enter(object sender, EventArgs e)
        {
            Form1._lastFocusedTextBox = sender as TextBoxBase;
        }


        public void LoadInstance(SessionDetails sessionDetails)
        {
            XDocument doc = XDocument.Load(fileReference);

            IEnumerable<XElement> possibleWords = doc.Root.Elements();

            if (sessionDetails.hasScoreLimit)
            {
                possibleWords = possibleWords.Where(el => (int)el.Attribute("Score") < sessionDetails.scoreLimit);
            }


            if (sessionDetails.hasWordLimit)
            {
                if(sessionDetails.mayRepeat)
                {
                    for (int i = 0; i < sessionDetails.wordLimit; i++)
                    {
                        int val = r.Next(0, possibleWords.Count());

                        germanWords.Add((string)possibleWords.ElementAt(val).Attribute("DE"));
                        russianWords.Add((string)possibleWords.ElementAt(val).Attribute("RU"));
                    }
                }
                else
                {
                    int index = 0;

                    foreach (XElement word in possibleWords)
                    {
                        germanWords.Add((string)word.Attribute("DE"));
                        russianWords.Add((string)word.Attribute("RU"));
                        index++;

                        if(index >= sessionDetails.wordLimit)
                        {
                            break;
                        }
                    }
                }

                
            }
            else
            {
                foreach (XElement word in possibleWords)
                {
                    germanWords.Add((string)word.Attribute("DE"));
                    russianWords.Add((string)word.Attribute("RU"));
                }
            }

            languageDirection = sessionDetails.languageDirection;
            
            wordIndex = r.Next(0, germanWords.Count);

            if(germanWords.Count == 0)
            {
                this.Close();
                return;
            }

            switch(languageDirection)
            {
                case 0:
                    // Choose German or Russian
                    if (r.Next(0, 2) == 0)
                    {
                        label1.Text = germanWords[wordIndex];
                        label3.Text = "(DE)";
                    }
                    else
                    {
                        label1.Text = russianWords[wordIndex];
                        label3.Text = "(RU)";
                    }
                    break;
                case 1:
                    label1.Text = russianWords[wordIndex];
                    label3.Text = "(RU)";
                    break;
                case 2:
                    label1.Text = germanWords[wordIndex];
                    label3.Text = "(DE)";
                    break;
            }

            sessionWords = germanWords.Count();

            label2.Text = sessionWords - germanWords.Count + " / " + sessionWords;
        }


        public void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(443, 151);
            label1.TabIndex = 0;
            label1.Text = "WordRU";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.Menu;
            textBox1.Font = new Font("Segoe UI", 24F);
            textBox1.Location = new Point(12, 265);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(443, 50);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Location = new Point(171, 331);
            button1.Name = "button1";
            button1.Size = new Size(138, 54);
            button1.TabIndex = 2;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(395, 331);
            button2.Name = "button2";
            button2.Size = new Size(58, 54);
            button2.TabIndex = 3;
            button2.Text = "RUS";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(171, 9);
            label2.Name = "label2";
            label2.Size = new Size(138, 23);
            label2.TabIndex = 4;
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.ForeColor = Color.OrangeRed;
            label3.Location = new Point(147, 144);
            label3.Name = "label3";
            label3.Size = new Size(167, 23);
            label3.TabIndex = 5;
            label3.Text = "(lg)";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // WordLearner
            // 
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(467, 435);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "WordLearner";
            ResumeLayout(false);
            PerformLayout();

        }

        private Label label1;
        private Button button1;
        private TextBox textBox1;

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 keyboard = new Form2();
            keyboard.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(awaitContinue)
            {
                button1.Text = "Submit";
                awaitContinue = false;
                ChooseNewWord();
                return;
            }



            if((label1.Text == germanWords[wordIndex] && textBox1.Text.ToLower() == russianWords[wordIndex].ToLower())
            || (label1.Text == russianWords[wordIndex] && textBox1.Text.ToLower() == germanWords[wordIndex].ToLower()))
            {
                button1.Enabled = false;
                
                XDocument doc = XDocument.Load(fileReference);

                XElement entry = doc.Root.Elements()
                    .Where(el =>
                        (string)el.Attribute("DE") == germanWords.ElementAt(wordIndex) &&
                        (string)el.Attribute("RU") == russianWords.ElementAt(wordIndex)
                    )
                    .First();

                int x = (int)entry.Attribute("Score");
                x++;
                entry.SetAttributeValue("Score", x.ToString());
                doc.Save(fileReference);

                germanWords.RemoveAt(wordIndex);
                russianWords.RemoveAt(wordIndex);
            
                Debug.WriteLine("Word was Correct!");
            
            
                int colorFlashGreen = 255;

            
                while(colorFlashGreen > 0)
                {
                    BackColor = Color.FromArgb(255,0, colorFlashGreen, 0);
                    colorFlashGreen -= 10;
                    await Task.Delay(30);
                }

                button1.Enabled = true;


                if (germanWords.Count == 0)
                {
                    this.Close();
                    return;
                }
            
            }
            else
            {
                int colorFlashRed = 255;

                button1.Enabled = false;


                while (colorFlashRed > 0)
                {
                    BackColor = Color.FromArgb(255, colorFlashRed, 0, 0);
                    colorFlashRed -= 10;
                    await Task.Delay(30);
                }

                button1.Text = "Continue";
                label1.Text = russianWords[wordIndex] + " - " + germanWords[wordIndex];

                awaitContinue = true;
                button1.Enabled = true;
                return;
            }

            ChooseNewWord();
        }

        public void ChooseNewWord()
        {
            wordIndex = r.Next(0, germanWords.Count);

            switch (languageDirection)
            {
                case 0:
                    // Choose German or Russian
                    if (r.Next(0, 2) == 0)
                    {
                        label1.Text = germanWords[wordIndex];
                        label3.Text = "(DE)";
                    }
                    else
                    {
                        label1.Text = russianWords[wordIndex];
                        label3.Text = "(RU)";
                    }
                    break;
                case 1:
                    label1.Text = russianWords[wordIndex];
                    label3.Text = "(RU)";
                    break;
                case 2:
                    label1.Text = germanWords[wordIndex];
                    label3.Text = "(DE)";
                    break;
            }

            textBox1.Text = "";
            label2.Text = sessionWords - germanWords.Count + " / " + sessionWords;
        }
    }
}
