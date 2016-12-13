
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ejercicio1
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		void SalirToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		void AbrirCarpetaToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(folderBrowserDialog1.ShowDialog()==DialogResult.OK){
				dir=new System.IO.DirectoryInfo(folderBrowserDialog1.SelectedPath);
				listBox1.Items.Clear();
				listBox1.Items.AddRange(dir.GetFiles("*.ico"));
				listBox1.Items.AddRange(dir.GetFiles("*.jpeg"));
				listBox1.Items.AddRange(dir.GetFiles("*.jpg"));
				listBox1.Items.AddRange(dir.GetFiles("*.bmp"));
				listBox1.Items.AddRange(dir.GetFiles("*.bmp"));
				
				if(listBox1.Items.Count>0){
					listBox1.SelectedIndex=0;
				}
				
			}
		}
		private System.IO.DirectoryInfo dir;
		void MainFormLoad(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text=System.IO.Directory.GetCurrentDirectory();
			toolStripComboBox1.SelectedIndex=0;
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text=dir.FullName+"\\"+listBox1.SelectedItem.ToString();
			pictureBox1.Image=Image.FromFile(toolStripStatusLabel1.Text);
			if(!presentacionToolStripMenuItem.Enabled)presentacionToolStripMenuItem.Enabled=true;
		}
		
		void AjustarALaVentanaToolStripMenuItemCheckedChanged(object sender, EventArgs e)
		{
			if(ajustarALaVentanaToolStripMenuItem.Checked){
				pictureBox1.Dock=DockStyle.Fill;
				pictureBox1.SizeMode=PictureBoxSizeMode.Zoom;
			}else{
				pictureBox1.Dock=DockStyle.None;
				pictureBox1.SizeMode= PictureBoxSizeMode.AutoSize;
			}
		}
		
		void VerListaDeImagenesToolStripMenuItemCheckedChanged(object sender, EventArgs e)
		{
			if(verListaDeImagenesToolStripMenuItem.Checked){
				splitContainer1.Panel1Collapsed=false;
			}else{
				splitContainer1.Panel1Collapsed=true;
			}
		}
		
		void PresentacionToolStripMenuItemClick(object sender, EventArgs e)
		{
			Maximizado m=new Maximizado();
			string[] lista=new string[listBox1.Items.Count];
			int i=0;
			foreach(System.IO.FileInfo f in listBox1.Items){
				lista[i]=f.FullName;
				i++;
			}
			m.LoadInfoPictures(lista,(toolStripComboBox1.SelectedIndex+1)*2000);
			m.ShowDialog();
			
		}
	}
}
