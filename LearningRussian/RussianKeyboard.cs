using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using static LearningRussian.NativeMethods;

namespace LearningRussian
{

    public class Form2 : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_NOACTIVATE = 0x08000000;

                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE;
                return cp;
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }




        public Form2()
        {
            InitializeComponent();

            foreach (Button btn in ControlExtensions.GetAll<Button>(this))
            {
                btn.Click += (sender2, e2) => printChar(sender2, e2, btn.Text[0]);
            }
        }

        public void printChar(object sender, EventArgs e, char c)
        {
            if(Form1._lastFocusedTextBox is not null)
            Form1._lastFocusedTextBox.Focus();

            NativeMethods.INPUT[] inputs = new NativeMethods.INPUT[2];

            // KeyDown
            inputs[0] = new NativeMethods.INPUT();
            inputs[0].type = NativeMethods.INPUT_KEYBOARD;
            inputs[0].U.ki.wVk = 0; // Enter VK Code
            inputs[0].U.ki.wScan = (ushort)c;
            inputs[0].U.ki.dwFlags = NativeMethods.KEYEVENTF_UNICODE;
            inputs[0].U.ki.time = 0;
            inputs[0].U.ki.dwExtraInfo = IntPtr.Zero;

            // KeyUp
            inputs[1] = new NativeMethods.INPUT();
            inputs[1].type = NativeMethods.INPUT_KEYBOARD;
            inputs[1].U.ki.wVk = 0;
            inputs[1].U.ki.wScan = (ushort)c;
            inputs[1].U.ki.dwFlags = NativeMethods.KEYEVENTF_UNICODE | NativeMethods.KEYEVENTF_KEYUP;
            inputs[1].U.ki.time = 0;
            inputs[1].U.ki.dwExtraInfo = IntPtr.Zero;

            // Senden
            uint result = NativeMethods.SendInput(2, inputs, Marshal.SizeOf(typeof(NativeMethods.INPUT)));

            Debug.WriteLine(result);

            int error = Marshal.GetLastWin32Error();
            Debug.WriteLine(error);

            Debug.WriteLine(Marshal.SizeOf(typeof(NativeMethods.INPUT)));

            if (result == 0)
            {
                // Fehlerbehandlung, z.B. via Marshal.GetLastWin32Error()
            }
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            button21 = new Button();
            button22 = new Button();
            button24 = new Button();
            button25 = new Button();
            button26 = new Button();
            button27 = new Button();
            button28 = new Button();
            button29 = new Button();
            button30 = new Button();
            button31 = new Button();
            button32 = new Button();
            button33 = new Button();
            button23 = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 15);
            button1.Name = "button1";
            button1.Size = new Size(54, 51);
            button1.TabIndex = 0;
            button1.Text = "А";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(72, 15);
            button2.Name = "button2";
            button2.Size = new Size(54, 51);
            button2.TabIndex = 1;
            button2.Text = "Б";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(132, 15);
            button3.Name = "button3";
            button3.Size = new Size(54, 51);
            button3.TabIndex = 2;
            button3.Text = "В";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(192, 15);
            button4.Name = "button4";
            button4.Size = new Size(54, 51);
            button4.TabIndex = 3;
            button4.Text = "Г";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(252, 15);
            button5.Name = "button5";
            button5.Size = new Size(54, 51);
            button5.TabIndex = 4;
            button5.Text = "Д";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(312, 15);
            button6.Name = "button6";
            button6.Size = new Size(54, 51);
            button6.TabIndex = 5;
            button6.Text = "Е";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(372, 15);
            button7.Name = "button7";
            button7.Size = new Size(54, 51);
            button7.TabIndex = 6;
            button7.Text = "Ё";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(432, 15);
            button8.Name = "button8";
            button8.Size = new Size(54, 51);
            button8.TabIndex = 7;
            button8.Text = "Ж";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(492, 15);
            button9.Name = "button9";
            button9.Size = new Size(54, 51);
            button9.TabIndex = 8;
            button9.Text = "З";
            button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Location = new Point(552, 15);
            button10.Name = "button10";
            button10.Size = new Size(54, 51);
            button10.TabIndex = 9;
            button10.Text = "И";
            button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(612, 15);
            button11.Name = "button11";
            button11.Size = new Size(54, 51);
            button11.TabIndex = 10;
            button11.Text = "Й";
            button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.Location = new Point(29, 72);
            button12.Name = "button12";
            button12.Size = new Size(54, 51);
            button12.TabIndex = 21;
            button12.Text = "К";
            button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Location = new Point(89, 72);
            button13.Name = "button13";
            button13.Size = new Size(54, 51);
            button13.TabIndex = 20;
            button13.Text = "Л";
            button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            button14.Location = new Point(149, 72);
            button14.Name = "button14";
            button14.Size = new Size(54, 51);
            button14.TabIndex = 19;
            button14.Text = "М";
            button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            button15.Location = new Point(209, 72);
            button15.Name = "button15";
            button15.Size = new Size(54, 51);
            button15.TabIndex = 18;
            button15.Text = "Н";
            button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            button16.Location = new Point(269, 72);
            button16.Name = "button16";
            button16.Size = new Size(54, 51);
            button16.TabIndex = 17;
            button16.Text = "О";
            button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            button17.Location = new Point(329, 72);
            button17.Name = "button17";
            button17.Size = new Size(54, 51);
            button17.TabIndex = 16;
            button17.Text = "П";
            button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            button18.Location = new Point(389, 72);
            button18.Name = "button18";
            button18.Size = new Size(54, 51);
            button18.TabIndex = 15;
            button18.Text = "Р";
            button18.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            button19.Location = new Point(449, 72);
            button19.Name = "button19";
            button19.Size = new Size(54, 51);
            button19.TabIndex = 14;
            button19.Text = "С";
            button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            button20.Location = new Point(509, 72);
            button20.Name = "button20";
            button20.Size = new Size(54, 51);
            button20.TabIndex = 13;
            button20.Text = "Т";
            button20.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            button21.Location = new Point(569, 72);
            button21.Name = "button21";
            button21.Size = new Size(54, 51);
            button21.TabIndex = 12;
            button21.Text = "У";
            button21.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            button22.Location = new Point(629, 72);
            button22.Name = "button22";
            button22.Size = new Size(54, 51);
            button22.TabIndex = 11;
            button22.Text = "Ф";
            button22.UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            button24.Location = new Point(49, 129);
            button24.Name = "button24";
            button24.Size = new Size(54, 51);
            button24.TabIndex = 31;
            button24.Text = "Х";
            button24.UseVisualStyleBackColor = true;
            // 
            // button25
            // 
            button25.Location = new Point(109, 129);
            button25.Name = "button25";
            button25.Size = new Size(54, 51);
            button25.TabIndex = 30;
            button25.Text = "Ц";
            button25.UseVisualStyleBackColor = true;
            // 
            // button26
            // 
            button26.Location = new Point(169, 129);
            button26.Name = "button26";
            button26.Size = new Size(54, 51);
            button26.TabIndex = 29;
            button26.Text = "Ч";
            button26.UseVisualStyleBackColor = true;
            // 
            // button27
            // 
            button27.Location = new Point(228, 129);
            button27.Name = "button27";
            button27.Size = new Size(54, 51);
            button27.TabIndex = 28;
            button27.Text = "Ш";
            button27.UseVisualStyleBackColor = true;
            // 
            // button28
            // 
            button28.Location = new Point(288, 129);
            button28.Name = "button28";
            button28.Size = new Size(54, 51);
            button28.TabIndex = 27;
            button28.Text = "Щ";
            button28.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            button29.Location = new Point(348, 129);
            button29.Name = "button29";
            button29.Size = new Size(54, 51);
            button29.TabIndex = 26;
            button29.Text = "Ъ";
            button29.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            button30.Location = new Point(408, 129);
            button30.Name = "button30";
            button30.Size = new Size(54, 51);
            button30.TabIndex = 25;
            button30.Text = "Ы";
            button30.UseVisualStyleBackColor = true;
            // 
            // button31
            // 
            button31.Location = new Point(468, 129);
            button31.Name = "button31";
            button31.Size = new Size(54, 51);
            button31.TabIndex = 24;
            button31.Text = "Ь";
            button31.UseVisualStyleBackColor = true;
            // 
            // button32
            // 
            button32.Location = new Point(528, 129);
            button32.Name = "button32";
            button32.Size = new Size(54, 51);
            button32.TabIndex = 23;
            button32.Text = "Э";
            button32.UseVisualStyleBackColor = true;
            // 
            // button33
            // 
            button33.Location = new Point(588, 129);
            button33.Name = "button33";
            button33.Size = new Size(54, 51);
            button33.TabIndex = 22;
            button33.Text = "Ю";
            button33.UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            button23.Location = new Point(648, 129);
            button23.Name = "button23";
            button23.Size = new Size(54, 51);
            button23.TabIndex = 32;
            button23.Text = "Я";
            button23.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button23);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button24);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button25);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button26);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button27);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button28);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button29);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button30);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button31);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button32);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(button33);
            panel1.Controls.Add(button22);
            panel1.Controls.Add(button12);
            panel1.Controls.Add(button21);
            panel1.Controls.Add(button13);
            panel1.Controls.Add(button20);
            panel1.Controls.Add(button14);
            panel1.Controls.Add(button19);
            panel1.Controls.Add(button15);
            panel1.Controls.Add(button18);
            panel1.Controls.Add(button16);
            panel1.Controls.Add(button17);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(717, 201);
            panel1.TabIndex = 33;
            // 
            // Form2
            // 
            ClientSize = new Size(738, 227);
            Controls.Add(panel1);
            Name = "Form2";
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Button button21;
        private Button button22;
        private Button button24;
        private Button button25;
        private Button button26;
        private Button button27;
        private Button button28;
        private Button button29;
        private Button button30;
        private Button button31;
        private Button button32;
        private Button button33;
        private Button button23;
        private Panel panel1;
        private Button button11;
    }


}
public static class ControlExtensions
{
    /// <summary>
    /// Recursively retrieves all child controls of a specific type.
    /// </summary>
    public static IEnumerable<T> GetAll<T>(this Control control) where T : Control
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrl => ctrl.GetAll<T>())
                       .Concat(controls.OfType<T>());
    }
}