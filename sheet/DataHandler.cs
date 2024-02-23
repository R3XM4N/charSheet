using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace sheet
{
    public static class DataHandler
    {
        public static void FillTextBoxes<T>(T[] data, TextBox[] textBoxes)
        {
            try
            {
                if (data.Length != textBoxes.Length)
                {
                    MessageBox.Show("An error has occured the data you wanna load cannot fit into the desired place or the other way around");
                }
                else
                {
                    int i = 0;
                    foreach (TextBox textBox in textBoxes)
                    {
                        if (data[i] == null)
                        {
                            textBox.Text = "NULL";
                        }
                        else
                        {
                            textBox.Text = data[i].ToString();
                        }
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error has occured setting the values of {data} into {textBoxes} this can be an issue of types or microsofts error if more descriptive: {e.Message}");
            }
        }
        public static void FillTextBoxesReadableProf(int[] data, TextBox[] textBoxes, List<int> bonus, int proefficency)
        {
            try
            {
                if (data.Length != textBoxes.Length)
                {
                    MessageBox.Show("An error has occured the data you wanna load cannot fit into the desired place or the other way around");
                }
                else
                {
                    int i = 0;
                    foreach (TextBox textBox in textBoxes)
                    {
                        if (bonus.Contains(i))
                        {
                            if (data[i] + proefficency > 0)
                            {
                                textBox.Text = $"+{data[i] + proefficency}";
                            }
                            else
                            {
                                textBox.Text = $"{data[i] + proefficency}";
                            }
                        }
                        else
                        {
                            if (data[i] > 0)
                            {
                                textBox.Text = $"+{data[i]}";
                            }
                            else
                            {
                                textBox.Text = $"{data[i]}";
                            }
                        }
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error has occured setting the values of {data} into {textBoxes} this can be an issue of types or microsofts error if more descriptive: {e.Message}");
            }
        }
        public static T[] FillFromBoxes<T>(TextBox[] textBoxes)
        {
            T[] temp = new T[textBoxes.Length];
            try
            {
                int i = 0;
                foreach (TextBox textBox in textBoxes)
                {
                    temp[0] = (T)Convert.ChangeType(textBox.Text, typeof(T)); ;
                    i++;
                }
                return temp;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return new T[0];
            }
        }
        public static string SerializeToJson<T>(T toserialize)
        {
            try
            {
                return JsonConvert.SerializeObject(toserialize, Formatting.Indented);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }
        public static T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return default(T);
            }
        }
        public static void ToJsonFile<T>(T toserialize, string fileLocation)
        {
            try
            {
                using (var sw = new StreamWriter(fileLocation))
                {
                    sw.Write(SerializeToJson<T>(toserialize));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static T FromJsonFile<T>(string filePath)
        {
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return default(T);
            }
        }
        public static string GetFilePath(bool save, string extension, string initialPath)
        {
            extension = extension.ToLower();
            if (save)
            {
                using (SaveFileDialog sd = new SaveFileDialog())
                {
                    sd.Title = "Choose a location to save";
                    if (initialPath != "" && extension != null)
                    {
                        sd.InitialDirectory = initialPath;
                    }
                    if (extension != "" && extension != null)
                    {
                        sd.AddExtension = true;
                        sd.DefaultExt = extension;
                        sd.Filter = $"{extension.ToUpper()} files (*.{extension})|*.{extension}";
                    }
                    sd.ShowDialog();
                    if (sd.FileName != null && sd.FileName != "")
                    {
                        return sd.FileName;
                    }
                    else
                    {
                        return "INVALID";
                    }
                }
            }
            else
            {
                using (OpenFileDialog od = new OpenFileDialog())
                {
                    od.Title = "Choose a file to open.";
                    if (initialPath != "" && extension != null)
                    {
                        od.InitialDirectory = initialPath;
                    }
                    if (extension != "" && extension != null)
                    {
                        od.AddExtension = true;
                        od.DefaultExt = extension;
                        od.Filter = $"{extension.ToUpper()} files (*.{extension})|*.{extension}";
                    }
                    od.ShowDialog();
                    if (od.FileName != null && od.FileName != "")
                    {
                        return od.FileName;
                    }
                    else
                    {
                        return "INVALID";
                    }
                }
            }
        }
        #region yoinked
    /* public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Dispose managed state (managed objects).
                // For example: myManagedResource?.Dispose();
            }

            // Free unmanaged resources (unmanaged objects) and override a finalizer below.
            // For example: Marshal.FreeHGlobal(myUnmanagedResource);

            disposed = true;
        }
        ~DataHandler() {
            Dispose(false);
        }
    */
        #endregion
    }
}
