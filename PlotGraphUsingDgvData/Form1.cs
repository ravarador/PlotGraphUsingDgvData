using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlotGraphUsingDgvData
{
public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var data1 = new DataModel { 
                Id = 1,
                Data1 = "6,4,2,3,6,8,10",
                Data2 = "Mon,Tue,Wed,Thu,Fri,Sat,Sun"
            };
            var data2 = new DataModel
            {
                Id = 2,
                Data1 = "11,4,2,1,6,3,10",
                Data2 = "Mon,Tue,Wed,Thu,Fri,Sat,Sun"
            };

            var DataList = new List<DataModel>();
            DataList.Add(data1);
            DataList.Add(data2);

            dataGridView1.DataSource = DataList;
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            formsPlot1.plt.Clear();
            //get data from dgv
            var selectedId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            var selectedData1 = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            var selectedData2 = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            //get selected data, turn them into array or list
            var data1Array = Array.ConvertAll(selectedData1.Split(','), Double.Parse);
            var data2Array = selectedData2.Split(',');

            //create variables for graph data
            double[] xs = DataGen.Consecutive(data1Array.Length);
            double[] ys = data1Array;

            //plot the graph
            var plt = new ScottPlot.Plot(600, 400);
            formsPlot1.plt.PlotBar(xs, ys);
            formsPlot1.plt.XTicks(xs, data2Array);
            formsPlot1.plt.Title("Title");
            formsPlot1.Render();
            
        }
    }
}
