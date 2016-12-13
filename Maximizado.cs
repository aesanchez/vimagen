
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ejercicio1
{
	/// <summary>
	/// Description of Maximizado.
	/// </summary>
	public partial class Maximizado : Form
	{
		private string[] imagenes;
		private int index=1;
		public Maximizado()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void LoadInfoPictures(string[] list,int duracion){
			imagenes=list;
			timer1.Interval=duracion;
			pictureBox1.Image=Image.FromFile(imagenes[0]);
			
		}
		void MaximizadoKeyPress(object sender, KeyPressEventArgs e)
		{
			this.Close();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			if(index==imagenes.Length){
				index=0;
			}
			pictureBox1.Image=Image.FromFile(imagenes[index++]);
		}
	}
}
