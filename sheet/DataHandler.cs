using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sheet
{
    public class DataHandler : IDisposable
    {
        private bool disposed = false;
        public DataHandler() { }

        public void FillTextBoxes<T>(T[] data, TextBox[] textBoxes)
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
                        textBox.Text = data[i].ToString();
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error has occured setting the values of {data} into {textBoxes} this can be an issue of types or microsofts error if more descriptive: {e.Message}");
            }
        }
        public T[] FillFromBoxes<T>(TextBox[] textBoxes)
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
        public string SerializeToJson<T>(T toserialize)
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
        public T Deserialize<T>(string json)
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
        public void ToJsonFile<T>(T toserialize,string fileLocation)
        {
            using (var sw = new StreamWriter(fileLocation))
            {
                sw.Write(SerializeToJson<T>(toserialize));
            }
            try
            {

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        public T FromJsonFile<T>(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
            }
            try
            {

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        #region yoinked
        public void Dispose()
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
        #endregion

    }
}
