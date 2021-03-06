using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZGraphTools;

namespace ImageFilters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int SortingAlgorithm;
        // Knapsack : 1
        //Counting Sort : 2
        //Quick Sort : 3
        int MaxWinSize = 9;
        byte[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);

            }
        }

        private void btnZGraph_Click(object sender, EventArgs e)
        {
            // Make up some data points from the N, N log(N) functions
            int N = 40;
            double[] x_values = new double[N];
            double[] y_values_N = new double[N];
            double[] y_values_NLogN = new double[N];

            for (int i = 0; i < N; i++)
            {
                x_values[i] = i;
                y_values_N[i] = i;
                y_values_NLogN[i] = i * Math.Log(i);
            }

            //Create a graph and add two curves to it
             ZGraphForm ZGF = new ZGraphForm("Sample Graph", "N", "f(N)");
            ZGF.add_curve("f(N) = N", x_values, y_values_N,Color.Red);
            ZGF.add_curve("f(N) = N Log(N)", x_values, y_values_NLogN, Color.Blue);
            ZGF.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdaptiveMedianFilter.applyFilter(ImageMatrix,SortingAlgorithm,MaxWinSize);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SortingAlgorithm = 2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SortingAlgorithm = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SortingAlgorithm = 2;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SortingAlgorithm = 3;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MaxWinSize = int.Parse(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlphaTrim.applyFilter(ImageMatrix, SortingAlgorithm);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }
    }
}