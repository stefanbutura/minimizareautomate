using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n;
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
 
            n = i-1;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
     
        }
        void minimizare(int[,] tabel)
        {
            richTextBox1.Text = "";
            int [,] mec=new int[20,20];
            //pas 1;
            int i, j, k=0;
            for(i=0;i<n;i++)
            {
                for(j=0;j<i;j++)
                {
                    if(tabel[i,2]!=tabel[j,2])
                    {
                        mec[i,j]=2;
                        mec[j,i]=2;
                    }
                    else
                    {
                        mec[i,j]=0;
                        mec[j,i]=0;
                    }
                }
                mec[i,i]=1;
            }

            //pas 2
            int da = 1;
            while(da==1)
            {
                da = 0;
                for(i=0;i<n;i++)
                    for(j=0;j<i;j++)
                        if(mec[i,j]==0)
                        {
                            if( mec[tabel[i,1],tabel[j,1]]==2 || mec[tabel[i,0],tabel[j,0]]==2 )
                            {
                                mec[i,j]=2;
                                mec[j,i]=2;
                                da = 1;
                            }
                            if(k==n*n-1)
                            {
                                mec[i,j]=1;
                                mec[j,i]=1;
                            }

                        }
                if(da==0)
                    for (i = 0; i < n; i++)
                        for (j = 0; j < i; j++)
                            if (mec[i, j] == 0)
                            {
                                    mec[i, j] = 1;
                                    mec[j, i] = 1;
                            }
            }
            for(i=1;i<n;i++)
            {
                richTextBox1.Text += i  + "|    ";
                for (j = 0; j < i; j++)
                    richTextBox1.Text += (char)(60 + mec[i,j] * 9) + " ";
                richTextBox1.Text += "\n";
            }
            richTextBox1.Text += "_______________"+"\n" + "       ";
            for (i = 0; i < n - 1; i++)
                richTextBox1.Text+= i + "' ";
            richTextBox1.Text += "\n \n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i,j;
            int [,] tabel=new int[10,4];
            for (i = 0; i < n; i++)
                for (j = 0; j < 3; j++)
                    tabel[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
            minimizare(tabel);
        }
    }
}
