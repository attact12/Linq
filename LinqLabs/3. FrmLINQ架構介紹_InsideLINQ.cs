using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

        }

        private void button30_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList arrList = new ArrayList();
            arrList.Add(2);
            arrList.Add(4);

            var q = from n in arrList.Cast<int>()
                    select new { N = n };

            this.dataGridView1.DataSource = q.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //I. 延遲查詢 (deferred execution)
            //定義時不會估算
            //使用時才估算


            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int i = 0;
            var q = from n in nums
                           select ++i;

            //foreach 執行 Query
            foreach (var v in q)
            {
                listBox1.Items.Add(string.Format("v = {0}, i = {1}", v, i));
            }
            listBox1.Items.Add("===========================================");

            //=======================================================

            i = 0;
            var q1 = (from n in nums
                      select ++i).ToList();

            foreach (var v in q1)
            {
                listBox1.Items.Add(string.Format("v = {0}, i = {1}", v, i));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           

            var q = (from p in this.nwDataSet1.Products
                     orderby p.UnitsInStock descending
                     select p).Take(5);

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //When LInq execute  query ??
            //1. foreach (...in q)
            //2. q.ToXXX()
            //3. Aggregtion   q.Sum()

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,111,0 };

            this.listBox1.Items.Add("sum = " + nums.Sum());
            this.listBox1.Items.Add("max = " + nums.Max());
            this.listBox1.Items.Add("min = " + nums.Min());
            this.listBox1.Items.Add("avg = " + nums.Average());
            this.listBox1.Items.Add("count = " + nums.Count());

            // nums.Median()

            //python pandas
            //nums.Median()
            //nums.Mean()

            //===================================
            this.listBox1.Items.Add("Avg UnitPrice =" + this.nwDataSet1.Products.Average(p => p.UnitPrice));
            this.listBox1.Items.Add("Max UnitsInStock =" + this.nwDataSet1.Products.Max(p => p.UnitsInStock));

        }
        //int MyMax(int[] nums)
        //{

        //}
    }
}