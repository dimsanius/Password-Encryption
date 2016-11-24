using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Password_encyption
{
    public partial class Root : Form
    {
        private static string ValueToPass;
        public static string PassedValueManagement
        {
            get { return ValueToPass; }
            set { ValueToPass = value;  }
        }

        
        public Root()
        {
            InitializeComponent();
            listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_MouseDoubleClick);
            
        }


        public void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form createNewOption = new AddItem();
            createNewOption.ShowDialog();

            listBox1.Items.Add(PassedValueManagement);
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"/Options/"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"/Options");
            StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "/Options/" + PassedValueManagement);
            streamWriter.Close();
        }

        private void Root_Load(object sender, EventArgs e)
        {
            foreach (string s in Directory.GetFiles(String.Format(Directory.GetCurrentDirectory() + @"/Options")).Select(Path.GetFileName))
                listBox1.Items.Add(s);


        }


        

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        MessageBox.Show(String.Format("{0}", listBox1.SelectedIndex.ToString()));
         
     }

    }
}
