using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LavaDo___To_Do_App
{
    public partial class Form1 : Form

    {
        private List<CheckBox> checkedBoxes = new List<CheckBox>(); 
        public Form1()
        {
            InitializeComponent();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (!string.IsNullOrWhiteSpace(txtGorev.Text))
                {
                    string yeniGorev = txtGorev.Text;
                    ToDoItem yeniToDoItem = new ToDoItem(yeniGorev, false);
                    listBoxGorevler.Items.Add(yeniToDoItem);

                   
                    CheckBox yeniCheckBox = new CheckBox();
                    yeniCheckBox.Text = yeniGorev;

                    
                    yeniCheckBox.CheckedChanged += (s, ev) =>
                    {
                        CheckBox checkBox = (CheckBox)s; 
                        if (checkBox.Checked)
                        {
                            checkedBoxes.Add(checkBox); 
                        }
                        else
                        {
                            checkedBoxes.Remove(checkBox); 
                        }
                    };

                   
                    Controls.Add(yeniCheckBox);
                    yeniCheckBox.Top = 50 + listBoxGorevler.Items.Count * 25;
                    yeniCheckBox.Left = 20;

                    
                    checkedBoxes.Add(yeniCheckBox);

                    
                    yeniCheckBox.Tag = listBoxGorevler.Items.Count - 1;

                    txtGorev.Clear();
                }
                else
                {
                    MessageBox.Show("Lütfen bir görev girin.","Uyarı");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = checkedBoxes.Count - 1; i >= 0; i--)
            {
                CheckBox checkBox = checkedBoxes[i];
                if (checkBox.Checked)
                {
                    int index = (int)checkBox.Tag; 
                    if (index >= 0 && index < listBoxGorevler.Items.Count)
                    {
                        
                        listBoxGorevler.Items.RemoveAt(index);

                        
                        foreach (CheckBox cb in checkedBoxes)
                        {
                            int cbIndex = (int)cb.Tag;
                            if (cbIndex > index)
                            {
                                cb.Tag = cbIndex - 1;
                            }
                        }

                        
                        Controls.Remove(checkBox);
                        checkedBoxes.Remove(checkBox);
                    }
                }
            
        }
        }
        public class ToDoItem
        {
            public string Gorev { get; set; }
            public bool Tamamlandi { get; set; }

            public ToDoItem(string gorev, bool tamamlandi)
            {
                Gorev = gorev;
                Tamamlandi = tamamlandi;
            }

            public override string ToString()
            {
                return Gorev;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

