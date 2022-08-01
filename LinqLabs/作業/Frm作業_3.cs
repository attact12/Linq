using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LinqLabs.作業
{
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 60, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 88, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 77, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 85, Eng = 72, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 89, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 99, Gender = "Female" },
                                            new Student{ Name = "aahty", Class = "CS_102", Chi = 80, Eng = 55, Math = 80, Gender = "Female" },
                                            new Student{ Name = "bbcttt", Class = "CS_102", Chi = 80, Eng = 30, Math = 100, Gender = "Male" },
                                            new Student{ Name = "cccttt", Class = "CS_102", Chi = 40, Eng = 80, Math = 100, Gender = "Male" }
                                          };
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

        private void button33_Click(object sender, EventArgs e)
        {
            var g = from n in students_scores
                    group n by MyCount(n) into t
                    select new { 成績級分 = t.Key, MyCount = t.Count() };
            this.chart1.DataSource = g.ToList();
            this.chart1.Series[0].XValueMember = "成績級分";
            this.chart1.Series[0].YValueMembers = "MyCount";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            // split=> 數學成績 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
        }
        private string MyCount(Student n)
        {
            if (n.Math > 90)
                return "優良(90-100)";
            else if (89 > n.Math && n.Math >= 70)
                return "佳(70-89)";
            else
                return "待加強(69以下)";


        }

        private void button36_Click(object sender, EventArgs e)
        {
            var q = from n in students_scores
                    group n by n.Math into g
                    select new { 數學成績分類 = g.Key, Count = g.Count() };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            var q = from n in students_scores

                    select n;
            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
