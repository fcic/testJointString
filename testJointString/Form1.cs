using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testJointString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines(".\\AIS.csv");
            InitDataTable1();

            string[] temp;

            for (int i = 0; i < s.Length; i++)
            {
                temp = s[i].Split(',');
                dt.Rows.Add(temp[2], temp[0], temp[1].Substring(0,10), temp[1].Substring(11, 8), temp[3]);
            }

            DataTable dtName = dt.DefaultView.ToTable(true, new string[] { "ID" });

            //1 person & N datetime
            string result = "";
            for (int j = 0; j < dtName.Rows.Count; j++)
            {
                //result += dt.Select("ID =" + dtName.Rows[0][0].ToString());// + " " + dtName.Rows[0][1].ToString() + " " + dtName.Rows[0][4].ToString();
                //遍历日期
                for (DateTime dt2 = new DateTime(2016, 6, 1); dt2 < new DateTime(2016, 10, 20); dt2 = dt2.AddDays(1))
                {
                    DataRow[] dr = dt.Select("ID=" + dtName.Rows[j][0].ToString()+" and Date='"+dt2.ToString("yyyy-MM-dd")+"'", "Date desc");

                    //for (int i = 0; i < dr.Length; i++)
                    //{
                    //    //dtName.Rows[i][0].ToString() + "," + dtName.Rows[i][1].ToString() + "," + dtName.Rows[i][2] + "," + dtName.Rows[i][3];
                    //    result += dr[i][0].ToString() + " " + dr[i][1].ToString()+" "+dr[i][2].ToString()+" " +dr[i][3].ToString()+" "+dr[i+1][3].ToString()+ "\r\n";
                    //}
                    try
                    {
                        if (dr.Length == 1)
                        {
                            result += dr[0][0].ToString() + "," + dr[0][1].ToString() + "," + dr[0][4].ToString() + "," + dr[0][2].ToString() + "," + dr[0][3].ToString() +"\r\n"; // "," + dr[dr.Length - 1][3].ToString() + 
                        }
                        else
                        {
                            result += dr[0][0].ToString() + "," + dr[0][1].ToString() + "," + dr[0][4].ToString() + "," + dr[0][2].ToString() + "," + dr[0][3].ToString() + "," + dr[dr.Length - 1][3].ToString() + "\r\n";
                        }
                    }
                    catch (Exception ex)
                    {
                        //try
                        //{
                        //    result += dr[0][0].ToString() + "," + dr[0][1].ToString() + "," + dr[0][4].ToString() + "," + dr[0][2].ToString() + "," + dr[0][3].ToString() + "\r\n";
                        //}
                        //catch (Exception ex2)
                        //{

                        //    //throw;
                        //}
                        
                        //MessageBox.Show(ex.Message.ToString());
                        //throw;
                    }
                    
                }
                result += "\r\n";

            }
            File.AppendAllText(".\\result.txt",result);
        }

        DataTable dt;

        void InitDataTable1()
        {
            dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Date");
            dt.Columns.Add("Time");
            dt.Columns.Add("Gender");
            //dt.Rows.Add("001", "June");
            //dt.Rows.Add("002", "zhang");
            //dt.Rows.Add("003", "jun");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines(".\\AIS.csv");
            InitDataTable1();

            string[] temp;

            for (int i = 0; i < s.Length; i++)
            {
                temp = s[i].Split(',');
                dt.Rows.Add(temp[2], temp[0], temp[1].Substring(0, 10), temp[1].Substring(11, 8), temp[3]);
            }

            DataTable dtName = dt.DefaultView.ToTable(true, new string[] { "ID" });

            //1 person & N datetime
            string result = "";

            for (DateTime dt2 = new DateTime(2016, 6, 1); dt2 < new DateTime(2016, 10, 20); dt2 = dt2.AddDays(1))
            {
                for (int j = 0; j < dtName.Rows.Count; j++)
                {
                    //result += dt.Select("ID =" + dtName.Rows[0][0].ToString());// + " " + dtName.Rows[0][1].ToString() + " " + dtName.Rows[0][4].ToString();
                    //遍历日期

                    DataRow[] dr = dt.Select("ID=" + dtName.Rows[j][0].ToString() + " and Date='" + dt2.ToString("yyyy-MM-dd") + "'", "Date desc");

                    try
                    {
                        if (dr.Length == 1)
                        {
                            result += dr[0][0].ToString() + "," + dr[0][1].ToString() + "," + dr[0][4].ToString() + "," + dr[0][2].ToString() + "," + dr[0][3].ToString() + "\r\n"; // "," + dr[dr.Length - 1][3].ToString() + 
                        }
                        else
                        {
                            result += dr[0][0].ToString() + "," + dr[0][1].ToString() + "," + dr[0][4].ToString() + "," + dr[0][2].ToString() + "," + dr[0][3].ToString() + "," + dr[dr.Length - 1][3].ToString() + "\r\n";
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }
                result += "\r\n";
            }

               

            File.AppendAllText(".\\result2.txt", result);
        }
    }
}
