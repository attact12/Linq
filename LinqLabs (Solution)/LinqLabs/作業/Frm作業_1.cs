using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();

            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 100, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 40, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 30, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 60, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 50, Eng = 80, Math = 80, Gender = "Female" },

                                          };
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
        }

        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        int Totalpage = 0;
        int CurentPage = 0;
      
        
  
        private void ChickTotalpage()
        {
            Totalpage=nwDataSet1.Products.Rows.Count / int.Parse(txtBox1.Text);
            if (nwDataSet1.Products.Rows.Count % int.Parse(txtBox1.Text) > 0)
                Totalpage += 1;
        }
        private void button12_Click(object sender, EventArgs e)//上一頁
        {
            ChickTotalpage();
            if (CurentPage > 1)
            {
                int HowPage = int.Parse(txtBox1.Text);
                CurentPage--;
                
                var p = from data in nwDataSet1.Products.Skip(HowPage * (CurentPage-1 )).Take(HowPage)
                        select data;
                this.dataGridView2.DataSource = p.ToList();
            }
        }

        private void button13_Click(object sender, EventArgs e)//下一頁
        {
            ChickTotalpage();
            if (CurentPage < Totalpage)
            {
                int HowPage = int.Parse(txtBox1.Text);

                
                CurentPage++;

                var p = from data in nwDataSet1.Products.Skip(HowPage * (CurentPage-1 )).Take(HowPage)
                        select data;
                this.dataGridView2.DataSource = p.ToList();

            }
            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)

            //Distinct()
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();

            var q = from file in files
                    where file.Extension.ToLower().Contains(".log")
                    select file;


            this.dataGridView1.DataSource = q.ToList();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	


            // 數學不及格 ... 是誰 
            #endregion
            dataGridView1.DataSource = students_scores;

        }
        int maxchinese;
        private void button5_Click(object sender, EventArgs e)
        {
            List<int> MaxChi = new List<int>();
            for (int i = 0; i < students_scores.Count; i++)
            {
                MaxChi.Add(students_scores[i].Chi);
                maxchinese = MaxChi.Max();
            }
            MessageBox.Show("國文成績最高為" + maxchinese);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from file in files
                    where file.CreationTime.Year ==2019
                    select file;


            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            this.dataGridView1.DataSource = files;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from file in files
                    where file.Length>10000
                    select file;


            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            var f = from file in nwDataSet1.Orders

                    select file;
            this.dataGridView2.DataSource = f.ToList();
        }








        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            IEnumerable<int> q = from file in nwDataSet1.Orders
                                     //where file.OrderDate.Year==1996
                                 select file.OrderDate.Year;
            foreach (int i in q.Distinct())
                this.comboBox1.Items.Add(i);
        }
    }
}
