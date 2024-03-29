﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace sheet
{
    public class GUIHandler
    {
        private Form form;
        private bool disposed;
        public GUIHandler(Form form) {
            this.form = form;
        }
        public void AddLabel(string controlName,string text,int x, int y,int fontSize,Control contrainer = null)
        {
            Label temp = new Label();
            temp.Name = controlName;
            temp.Location = new System.Drawing.Point(x, y);
            temp.Font = new Font(temp.Font.FontFamily, fontSize);
            temp.AutoSize = true;
            temp.Text = text;
            form.Controls.Add(temp);
            (contrainer ?? form).Controls.Add(temp);
        }
        public void AddTextBox(string controlName, string text, int x, int y, int fontSize, int width, Control contrainer = null)
        {
            TextBox temp = new TextBox();
            temp.Name = controlName;
            temp.Location = new System.Drawing.Point(x, y);
            temp.Font = new Font(temp.Font.FontFamily, fontSize);
            temp.AutoSize = true;
            temp.Text = text;
            temp.Width = width;
            form.Controls.Add(temp);
            (contrainer ?? form).Controls.Add(temp);
        }
        public void AddLabeledTextBox(string controlName, string labelText,string textBoxText, int x, int y, int fontSize, int TextboxWidth,int spacing, Control contrainer = null)
        {
            AddLabel($"{controlName}_Label", labelText, x, y, fontSize, contrainer ?? form);
            AddTextBox($"{controlName}_TextBox", textBoxText, x+spacing, y, fontSize, TextboxWidth, contrainer ?? form);
        }
        public void DisposeControl(string controlName)
        {
            Control control = form.Controls.Find(controlName,true).FirstOrDefault();
            if (control != null)
            {
                control.Dispose();
            }
        }
        public void HideControl(string controlName)
        {
            Control control = form.Controls.Find(controlName, true).FirstOrDefault();
            if (control != null)
            {
                control.Visible = false;
            }
        }
        public void ShowControl(string controlName)
        {
            Control control = form.Controls.Find(controlName, true).FirstOrDefault();
            if (control != null)
            {
                control.Visible = true;
            }
        }
        public void ChangeText(string controlName, string text)
        {
            Control control = form.Controls.Find(controlName, true).FirstOrDefault();
            if (control is Label label || control is TextBox textBox)
            {
                control.Text = text;
            }
        }
        public string GetText(string controlName)
        {
            Control control = form.Controls.Find(controlName, true).FirstOrDefault();
            if (control is Label label || control is TextBox textBox)
            {
                return control.Text;
            }
            return "NOT A TEXT CONTAINER";
        }
        public void ChangeBackgroundImage(System.Drawing.Image image, Control control = null)
        {
            (control ?? form).BackgroundImage = image;
        }
        public void ChangeTextArray(string[] controlNameArray, string[] textArray)
        {
            if (controlNameArray.Length == textArray.Length)
            {
                for (int i = 0; i < controlNameArray.Length; i++)
                {
                    ChangeText(controlNameArray[i], textArray[i]);
                }
            }
            else
            {
                MessageBox.Show("Array doesn't fit the control collection or vice versa");
            }
        }
        public string[] GetControlsTextsArray(string[] controlNameArray)
        {
            string[] temp = new string[controlNameArray.Length];
            for(int i = 0;i < controlNameArray.Length; i++)
            {
                temp[i] = GetText(controlNameArray[i]);
            }
            return temp;
        }
        public void CreateLabelCollum(string[] controlNameArray, string[] textArray, int x, int startY, int fontSize, int spacing, Control contrainer = null)
        {
            int currentY = startY;
            for (int i = 0; i < controlNameArray.Length; i++)
            {
                if (i!=0)
                {
                    AddLabel(controlNameArray[i], textArray[i], x, currentY, fontSize, contrainer);
                    currentY = form.Controls.Find(controlNameArray[i], true).FirstOrDefault().Height + currentY + spacing;
                }
                else
                {
                    AddLabel(controlNameArray[i], textArray[i], x, currentY, fontSize, contrainer);
                    currentY = form.Controls.Find(controlNameArray[i],true).FirstOrDefault().Height + currentY + spacing;
                }
            }
        }
        public void CreateTextBoxCollum(string[] controlNameArray, string[] textArray, int x, int startY, int fontSize,int width, int spacing, Control contrainer = null)
        {
            int currentY = startY;
            for (int i = 0; i < controlNameArray.Length; i++)
            {
                if (i != 0)
                {
                    AddTextBox(controlNameArray[i], textArray[i], x, currentY, fontSize,width, contrainer);
                    currentY = form.Controls.Find(controlNameArray[i], true).FirstOrDefault().Height + currentY + spacing;
                }
                else
                {
                    AddTextBox(controlNameArray[i], textArray[i], x, currentY, fontSize, width, contrainer);
                    currentY = form.Controls.Find(controlNameArray[i], true).FirstOrDefault().Height + currentY + spacing;
                }
            }
        }
        //this is yoinked
        #region disposer
        // Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    if (form != null)
                        form.Dispose();
                }

                // Dispose unmanaged resources.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~GUIHandler()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
        #endregion
    }
}
