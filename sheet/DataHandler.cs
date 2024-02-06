using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sheet
{
    public class DataHandler
    {
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
    }
}
