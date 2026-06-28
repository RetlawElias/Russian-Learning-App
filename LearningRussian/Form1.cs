using LearningRussian;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Xml;
using System.Xml.Linq;
using System.Net.Http.Headers;

public class Form1 : Form
{
    public static TextBoxBase _lastFocusedTextBox;
    private Button button3;
    private Label label4;
    private Label label5;
    private Button button4;
    private Button button5;
    private Button button6;
    private Panel panel1;
    private Button button7;
    private Panel panel2;
    private TrackBar trackBar1;
    public string fileReference;

    private CheckBox checkBox1;
    private Label label6;
    private Label label7;
    private Label label8;
    private CheckBox checkBox2;

    SessionDetails sessionDetails = new SessionDetails();

    private Label label9;
    private TrackBar trackBar2;
    private Panel panel3;
    private Label label10;
    private Panel panel4;
    private Panel panel6;
    private Panel panel5;
    private Label label11;
    private Panel panel7;
    private CheckBox checkBox5;
    private CheckBox checkBox4;
    private Label label12;
    private CheckBox checkBox3;
    private CheckBox checkBox6;
    private Label label14;
    private TextBox textBox3;
    private Label label13;

    public Form1()
    {
        InitializeComponent();

        textBox1.Enter += (s2, e2) => { TextInput_Enter(s2, e2); textBox1.Focus(); };
        textBox2.Enter += (s2, e2) => { TextInput_Enter(s2, e2); textBox2.Focus(); };


    }

    private void TextInput_Enter(object sender, EventArgs e)
    {
        _lastFocusedTextBox = sender as TextBoxBase;
    }


    public void promptToSelectFile()
    {
        OpenFileDialog dialog = new OpenFileDialog();

        dialog.Title = "Select a file";
        dialog.Filter = "All files (*.*)|*.*";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            string path = dialog.FileName;

            FileInfo file = new FileInfo(path);

            Console.WriteLine("Selected file:");
            Console.WriteLine(file.FullName);
            Console.WriteLine(file.Name);
            Console.WriteLine(file.Length + " bytes");

            fileReference = path;

            if (fileReference is not null && File.Exists(fileReference))
            {
                label3.ForeColor = Color.Green;
                label3.Text = "File Found";
                panel1.BackColor = Color.FromArgb(255, 100, 200, 100);
                button4.Enabled = true;
            }
        }
        else
        {
            fileReference = null;
            label3.ForeColor = Color.Red;
            label3.Text = "No File Detected";
            panel1.BackColor = Color.FromArgb(255, 200, 100, 100);
            button4.Enabled = false;
        }
    }

    public void promptToCreateFile()
    {
        SaveFileDialog dialog = new SaveFileDialog();

        dialog.Title = "Save a file";
        dialog.Filter = "All files (*.xml)|*.xml";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            string path = dialog.FileName;

            FileInfo file = new FileInfo(path);

            Console.WriteLine("Selected file:");
            Console.WriteLine(file.FullName);
            Console.WriteLine(file.Name);


            XDocument doc;
            doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("WordDatabase"));

            var root = doc.Root;
            if (root == null || root.Name != "WordDatabase")
                throw new InvalidDataException("Expected root element <WordDatabase>.");

            //doc.Root!.Add(newMap);
            doc.Save(path);

            fileReference = path;

            if (fileReference is not null && File.Exists(fileReference))
            {
                label3.ForeColor = Color.Green;
                label3.Text = "File Found";
                panel1.BackColor = Color.FromArgb(255, 100, 200, 100);
                button4.Enabled = true;
            }
        }
        else
        {
            fileReference = null;
            label3.ForeColor = Color.Red;
            label3.Text = "No File Detected";
            panel1.BackColor = Color.FromArgb(255, 200, 100, 100);
            button4.Enabled = false;
        }
    }

    public void promptToMixFiles()
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            // Allow multiple file selection
            openFileDialog.Multiselect = true;

            // Optional: Filter for specific extensions
            openFileDialog.Filter = "All files (*.xml)|*.xml";
            openFileDialog.Title = "Select Multiple Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileNames.Length > 1)
                {
                    // TODO Mix Files
                }

                // FileNames returns an array of all selected file paths
                foreach (string file in openFileDialog.FileNames)
                {
                    // Process each file (e.g., display, load, copy)
                    System.Diagnostics.Debug.WriteLine($"Selected: {file}");
                }
            }
        }
    }


    private void InitializeComponent()
    {
        button1 = new Button();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        label1 = new Label();
        label2 = new Label();
        button2 = new Button();
        label3 = new Label();
        button3 = new Button();
        label4 = new Label();
        label5 = new Label();
        button4 = new Button();
        button5 = new Button();
        button6 = new Button();
        panel1 = new Panel();
        button7 = new Button();
        panel2 = new Panel();
        panel7 = new Panel();
        checkBox6 = new CheckBox();
        label14 = new Label();
        textBox3 = new TextBox();
        label13 = new Label();
        checkBox5 = new CheckBox();
        checkBox4 = new CheckBox();
        checkBox3 = new CheckBox();
        label12 = new Label();
        panel6 = new Panel();
        label7 = new Label();
        checkBox2 = new CheckBox();
        trackBar2 = new TrackBar();
        label9 = new Label();
        panel5 = new Panel();
        label6 = new Label();
        checkBox1 = new CheckBox();
        trackBar1 = new TrackBar();
        label8 = new Label();
        label11 = new Label();
        panel3 = new Panel();
        label10 = new Label();
        panel4 = new Panel();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        panel7.SuspendLayout();
        panel6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
        panel5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
        panel3.SuspendLayout();
        panel4.SuspendLayout();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Font = new Font("Segoe UI", 12F);
        button1.Location = new Point(440, 117);
        button1.Name = "button1";
        button1.Size = new Size(176, 40);
        button1.TabIndex = 0;
        button1.Text = "Russian Keyboard";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(9, 40);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(169, 23);
        textBox1.TabIndex = 1;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(217, 40);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(169, 23);
        textBox2.TabIndex = 2;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        label1.Location = new Point(24, 10);
        label1.Name = "label1";
        label1.Size = new Size(254, 45);
        label1.TabIndex = 4;
        label1.Text = "Russian Learner";
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
        label2.Location = new Point(110, 56);
        label2.Name = "label2";
        label2.Size = new Size(84, 13);
        label2.TabIndex = 5;
        label2.Text = "by RetlawElias®";
        // 
        // button2
        // 
        button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button2.Location = new Point(78, 120);
        button2.Name = "button2";
        button2.Size = new Size(138, 23);
        button2.TabIndex = 6;
        button2.Text = "Load Learning-File";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Top;
        label3.ForeColor = Color.Red;
        label3.Location = new Point(82, 56);
        label3.Name = "label3";
        label3.Size = new Size(130, 16);
        label3.TabIndex = 7;
        label3.Text = "No File Detected";
        label3.TextAlign = ContentAlignment.TopCenter;
        // 
        // button3
        // 
        button3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button3.Location = new Point(78, 89);
        button3.Name = "button3";
        button3.Size = new Size(138, 23);
        button3.TabIndex = 8;
        button3.Text = "Create Learning-File";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.Top;
        label4.Font = new Font("Segoe UI", 14F);
        label4.ForeColor = Color.Black;
        label4.Location = new Point(9, 13);
        label4.Name = "label4";
        label4.Size = new Size(169, 24);
        label4.TabIndex = 9;
        label4.Text = "German";
        label4.TextAlign = ContentAlignment.TopCenter;
        // 
        // label5
        // 
        label5.Anchor = AnchorStyles.Top;
        label5.Font = new Font("Segoe UI", 14F);
        label5.ForeColor = Color.Black;
        label5.Location = new Point(217, 13);
        label5.Name = "label5";
        label5.Size = new Size(169, 24);
        label5.TabIndex = 10;
        label5.Text = "Russian";
        label5.TextAlign = ContentAlignment.TopCenter;
        // 
        // button4
        // 
        button4.Enabled = false;
        button4.Location = new Point(141, 69);
        button4.Name = "button4";
        button4.Size = new Size(110, 28);
        button4.TabIndex = 11;
        button4.Text = "Add Entry";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // button5
        // 
        button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        button5.Enabled = false;
        button5.Location = new Point(78, 555);
        button5.Name = "button5";
        button5.Size = new Size(138, 40);
        button5.TabIndex = 12;
        button5.Text = "Merge Learning-Files";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // button6
        // 
        button6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button6.Location = new Point(78, 173);
        button6.Name = "button6";
        button6.Size = new Size(138, 23);
        button6.TabIndex = 13;
        button6.Text = "Browse Entires";
        button6.UseVisualStyleBackColor = true;
        button6.Click += button6_Click;
        // 
        // panel1
        // 
        panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        panel1.BackColor = Color.FromArgb(200, 100, 100);
        panel1.Controls.Add(button4);
        panel1.Controls.Add(textBox1);
        panel1.Controls.Add(textBox2);
        panel1.Controls.Add(label4);
        panel1.Controls.Add(label5);
        panel1.Location = new Point(328, 508);
        panel1.Name = "panel1";
        panel1.Size = new Size(393, 100);
        panel1.TabIndex = 14;
        // 
        // button7
        // 
        button7.Location = new Point(32, 579);
        button7.Name = "button7";
        button7.Size = new Size(194, 31);
        button7.TabIndex = 15;
        button7.Text = "Start Session";
        button7.UseVisualStyleBackColor = true;
        button7.Click += button7_Click;
        // 
        // panel2
        // 
        panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        panel2.BackColor = SystemColors.ButtonHighlight;
        panel2.BorderStyle = BorderStyle.FixedSingle;
        panel2.Controls.Add(panel7);
        panel2.Controls.Add(panel6);
        panel2.Controls.Add(panel5);
        panel2.Controls.Add(label11);
        panel2.Controls.Add(button7);
        panel2.Location = new Point(-3, -2);
        panel2.Name = "panel2";
        panel2.Size = new Size(268, 624);
        panel2.TabIndex = 16;
        // 
        // panel7
        // 
        panel7.BackColor = SystemColors.ButtonFace;
        panel7.Controls.Add(checkBox6);
        panel7.Controls.Add(label14);
        panel7.Controls.Add(textBox3);
        panel7.Controls.Add(label13);
        panel7.Controls.Add(checkBox5);
        panel7.Controls.Add(checkBox4);
        panel7.Controls.Add(checkBox3);
        panel7.Controls.Add(label12);
        panel7.Location = new Point(14, 358);
        panel7.Name = "panel7";
        panel7.Size = new Size(240, 215);
        panel7.TabIndex = 25;
        // 
        // checkBox6
        // 
        checkBox6.AutoSize = true;
        checkBox6.Enabled = false;
        checkBox6.Location = new Point(70, 186);
        checkBox6.Name = "checkBox6";
        checkBox6.Size = new Size(99, 19);
        checkBox6.TabIndex = 7;
        checkBox6.Text = "Repeat Words";
        checkBox6.UseVisualStyleBackColor = true;
        checkBox6.CheckedChanged += checkBox6_CheckedChanged;
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new Point(158, 158);
        label14.Name = "label14";
        label14.Size = new Size(41, 15);
        label14.TabIndex = 6;
        label14.Text = "Words";
        // 
        // textBox3
        // 
        textBox3.Enabled = false;
        textBox3.Location = new Point(52, 155);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(100, 23);
        textBox3.TabIndex = 5;
        // 
        // label13
        // 
        label13.Font = new Font("Segoe UI", 14F);
        label13.Location = new Point(3, 100);
        label13.Name = "label13";
        label13.Size = new Size(234, 27);
        label13.TabIndex = 4;
        label13.Text = "Limit";
        label13.TextAlign = ContentAlignment.TopCenter;
        // 
        // checkBox5
        // 
        checkBox5.AutoSize = true;
        checkBox5.Location = new Point(45, 65);
        checkBox5.Name = "checkBox5";
        checkBox5.Size = new Size(155, 19);
        checkBox5.TabIndex = 3;
        checkBox5.Text = "Only German -> Russian";
        checkBox5.UseVisualStyleBackColor = true;
        checkBox5.CheckedChanged += checkBox5_CheckedChanged;
        // 
        // checkBox4
        // 
        checkBox4.AutoSize = true;
        checkBox4.Location = new Point(45, 40);
        checkBox4.Name = "checkBox4";
        checkBox4.Size = new Size(155, 19);
        checkBox4.TabIndex = 2;
        checkBox4.Text = "Only Russian -> German";
        checkBox4.UseVisualStyleBackColor = true;
        checkBox4.CheckedChanged += checkBox4_CheckedChanged;
        // 
        // checkBox3
        // 
        checkBox3.AutoSize = true;
        checkBox3.Location = new Point(84, 130);
        checkBox3.Name = "checkBox3";
        checkBox3.Size = new Size(68, 19);
        checkBox3.TabIndex = 1;
        checkBox3.Text = "Enabled";
        checkBox3.UseVisualStyleBackColor = true;
        checkBox3.CheckedChanged += checkBox3_CheckedChanged;
        // 
        // label12
        // 
        label12.Font = new Font("Segoe UI", 14F);
        label12.Location = new Point(3, 10);
        label12.Name = "label12";
        label12.Size = new Size(234, 27);
        label12.TabIndex = 0;
        label12.Text = "Words";
        label12.TextAlign = ContentAlignment.TopCenter;
        // 
        // panel6
        // 
        panel6.BackColor = Color.FromArgb(200, 100, 100);
        panel6.Controls.Add(label7);
        panel6.Controls.Add(checkBox2);
        panel6.Controls.Add(trackBar2);
        panel6.Controls.Add(label9);
        panel6.Location = new Point(14, 212);
        panel6.Name = "panel6";
        panel6.Size = new Size(240, 139);
        panel6.TabIndex = 19;
        // 
        // label7
        // 
        label7.Font = new Font("Segoe UI", 14F);
        label7.Location = new Point(18, 12);
        label7.Name = "label7";
        label7.Size = new Size(207, 29);
        label7.TabIndex = 19;
        label7.Text = "Timer";
        label7.TextAlign = ContentAlignment.TopCenter;
        // 
        // checkBox2
        // 
        checkBox2.AutoSize = true;
        checkBox2.Location = new Point(84, 44);
        checkBox2.Name = "checkBox2";
        checkBox2.Size = new Size(68, 19);
        checkBox2.TabIndex = 21;
        checkBox2.Text = "Enabled";
        checkBox2.UseVisualStyleBackColor = true;
        checkBox2.CheckedChanged += checkBox2_CheckedChanged;
        // 
        // trackBar2
        // 
        trackBar2.BackColor = Color.FromArgb(200, 100, 100);
        trackBar2.Enabled = false;
        trackBar2.LargeChange = 10;
        trackBar2.Location = new Point(18, 69);
        trackBar2.Maximum = 300;
        trackBar2.Name = "trackBar2";
        trackBar2.Size = new Size(193, 45);
        trackBar2.SmallChange = 5;
        trackBar2.TabIndex = 22;
        trackBar2.TickFrequency = 30;
        trackBar2.Scroll += trackBar2_Scroll;
        // 
        // label9
        // 
        label9.Location = new Point(18, 117);
        label9.Name = "label9";
        label9.Size = new Size(193, 15);
        label9.TabIndex = 23;
        label9.Text = "0";
        label9.TextAlign = ContentAlignment.TopCenter;
        // 
        // panel5
        // 
        panel5.BackColor = Color.FromArgb(200, 100, 100);
        panel5.Controls.Add(label6);
        panel5.Controls.Add(checkBox1);
        panel5.Controls.Add(trackBar1);
        panel5.Controls.Add(label8);
        panel5.Location = new Point(14, 65);
        panel5.Name = "panel5";
        panel5.Size = new Size(240, 141);
        panel5.TabIndex = 19;
        // 
        // label6
        // 
        label6.Font = new Font("Segoe UI", 14F);
        label6.Location = new Point(18, 13);
        label6.Name = "label6";
        label6.Size = new Size(193, 29);
        label6.TabIndex = 17;
        label6.Text = "Exclude by Score";
        label6.TextAlign = ContentAlignment.TopCenter;
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Location = new Point(84, 45);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(68, 19);
        checkBox1.TabIndex = 18;
        checkBox1.Text = "Enabled";
        checkBox1.UseVisualStyleBackColor = true;
        checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        // 
        // trackBar1
        // 
        trackBar1.BackColor = Color.FromArgb(200, 100, 100);
        trackBar1.Enabled = false;
        trackBar1.Location = new Point(18, 70);
        trackBar1.Maximum = 100;
        trackBar1.Minimum = 1;
        trackBar1.Name = "trackBar1";
        trackBar1.Size = new Size(193, 45);
        trackBar1.TabIndex = 16;
        trackBar1.TickFrequency = 10;
        trackBar1.Value = 1;
        trackBar1.Scroll += trackBar1_Scroll;
        // 
        // label8
        // 
        label8.Location = new Point(18, 118);
        label8.Name = "label8";
        label8.Size = new Size(193, 15);
        label8.TabIndex = 20;
        label8.Text = "1";
        label8.TextAlign = ContentAlignment.TopCenter;
        // 
        // label11
        // 
        label11.Font = new Font("Segoe UI", 18F);
        label11.Location = new Point(14, 18);
        label11.Name = "label11";
        label11.Size = new Size(230, 54);
        label11.TabIndex = 24;
        label11.Text = "Session-Details";
        label11.TextAlign = ContentAlignment.TopCenter;
        // 
        // panel3
        // 
        panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel3.BackColor = SystemColors.ButtonHighlight;
        panel3.BorderStyle = BorderStyle.FixedSingle;
        panel3.Controls.Add(label10);
        panel3.Controls.Add(label3);
        panel3.Controls.Add(button3);
        panel3.Controls.Add(button6);
        panel3.Controls.Add(button2);
        panel3.Controls.Add(button5);
        panel3.Location = new Point(784, -2);
        panel3.Name = "panel3";
        panel3.Size = new Size(286, 624);
        panel3.TabIndex = 17;
        // 
        // label10
        // 
        label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label10.Font = new Font("Segoe UI", 18F);
        label10.Location = new Point(14, 18);
        label10.Name = "label10";
        label10.Size = new Size(257, 38);
        label10.TabIndex = 0;
        label10.Text = "File-Management";
        label10.TextAlign = ContentAlignment.TopCenter;
        // 
        // panel4
        // 
        panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        panel4.BorderStyle = BorderStyle.FixedSingle;
        panel4.Controls.Add(label1);
        panel4.Controls.Add(label2);
        panel4.Location = new Point(372, 11);
        panel4.Name = "panel4";
        panel4.Size = new Size(301, 100);
        panel4.TabIndex = 18;
        // 
        // Form1
        // 
        ClientSize = new Size(1069, 620);
        Controls.Add(panel4);
        Controls.Add(panel3);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Controls.Add(button1);
        Name = "Form1";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel2.ResumeLayout(false);
        panel7.ResumeLayout(false);
        panel7.PerformLayout();
        panel6.ResumeLayout(false);
        panel6.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
        panel5.ResumeLayout(false);
        panel5.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
        panel3.ResumeLayout(false);
        panel4.ResumeLayout(false);
        panel4.PerformLayout();
        ResumeLayout(false);

    }

    private void button1_Click(object sender, EventArgs e)
    {
        //if (_lastFocusedTextBox == null) return;

        Form2 keyboard = new Form2();
        keyboard.Show();
    }

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private Label label1;
    private Label label2;
    private System.Windows.Forms.Button button2;
    private Label label3;
    private System.Windows.Forms.Button button1;

    private void button2_Click(object sender, EventArgs e)
    {
        promptToSelectFile();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        promptToCreateFile();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        promptToMixFiles();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        if (fileReference is not null && textBox1.Text != "" && textBox2.Text != "")
        {
            XElement entry = new XElement("Word");
            entry.SetAttributeValue("DE", textBox1.Text);
            entry.SetAttributeValue("RU", textBox2.Text);
            entry.SetAttributeValue("Score", 0);

            XDocument doc;

            using (FileStream f = new FileStream(fileReference, FileMode.Open))
            {
                doc = XDocument.Load(f);
                doc.Root!.Add(entry);
            }

            doc.Save(fileReference);

            textBox1.Text = "";
            textBox2.Text = "";
        }
    }

    private void button6_Click(object sender, EventArgs e)
    {
        if (fileReference is null && fileReference != "") return;

        XDocument doc = XDocument.Load(fileReference);


        EntryViewer viewer = new EntryViewer(doc.Root.Elements(), fileReference);
        viewer.Show();
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        sessionDetails.scoreLimit = trackBar1.Value;
        label8.Text = sessionDetails.scoreLimit.ToString();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        sessionDetails.hasScoreLimit = checkBox1.Checked;

        if (sessionDetails.hasScoreLimit)
        {
            trackBar1.Enabled = true;
            panel5.BackColor = Color.FromArgb(255, 100, 200, 100);
            trackBar1.BackColor = Color.FromArgb(255, 100, 200, 100);
        }
        else
        {
            trackBar1.Enabled = false;
            panel5.BackColor = Color.FromArgb(255, 200, 100, 100);
            trackBar1.BackColor = Color.FromArgb(255, 200, 100, 100);
        }
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        sessionDetails.hasTimeLimit = checkBox2.Checked;

        if (checkBox2.Checked)
        {
            trackBar2.Enabled = true;
            panel6.BackColor = Color.FromArgb(255, 100, 200, 100);
            trackBar2.BackColor = Color.FromArgb(255, 100, 200, 100);
        }
        else
        {
            trackBar2.Enabled = false;
            panel6.BackColor = Color.FromArgb(255, 200, 100, 100);
            trackBar2.BackColor = Color.FromArgb(255, 200, 100, 100);
        }

    }

    private void button7_Click(object sender, EventArgs e)
    {
        if(sessionDetails.hasWordLimit && Int32.TryParse(textBox3.Text, out int result))
        {
            sessionDetails.wordLimit = result;
        }
        WordLearner learningSession = new WordLearner(fileReference, sessionDetails);
        if(!learningSession.IsDisposed)
        learningSession?.Show();
    }

    private void trackBar2_Scroll(object sender, EventArgs e)
    {
        sessionDetails.timeLimit = trackBar2.Value;
        label9.Text = sessionDetails.timeLimit.ToString() + " Sec";
    }

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox4.Checked)
        {
            checkBox5.Checked = false;
            sessionDetails.languageDirection = 1;
        }
        else
        {
            if (checkBox5.Checked)
            {
                sessionDetails.languageDirection = 2;
            }
            else
            {
                sessionDetails.languageDirection = 0;
            }
        }
    }

    private void checkBox5_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox5.Checked)
        {
            checkBox4.Checked = false;
            sessionDetails.languageDirection = 2;
        }
        else
        {
            if (checkBox4.Checked)
            {
                sessionDetails.languageDirection = 1;
            }
            else
            {
                sessionDetails.languageDirection = 0;
            }
        }
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox3.Checked)
        {
            sessionDetails.hasWordLimit = true;
            sessionDetails.wordLimit = 1;
            textBox3.Enabled = true;
            checkBox6.Enabled = true;
        }
        else
        {
            sessionDetails.hasWordLimit = false;
            textBox3.Enabled = false;
            checkBox6.Enabled = false;
        }
    }

    private void checkBox6_CheckedChanged(object sender, EventArgs e)
    {
        if(checkBox6.Checked)
        {
            sessionDetails.mayRepeat = true;
        }
        else
        {
            sessionDetails.mayRepeat = false;
        }
    }
}

