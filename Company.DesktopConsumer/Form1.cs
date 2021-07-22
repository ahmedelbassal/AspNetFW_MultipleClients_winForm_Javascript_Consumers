using Company.DesktopConsumer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company.DesktopConsumer
{
    public partial class Form1 : Form
    {

        string baseUrl = "http://localhost:8547/api/";

        bool comboBoxFilled = false;

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillGridView();

            fillComboBox();

        }

        private void fillComboBox()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            var result = client.GetAsync("employees").Result;

            if (result.IsSuccessStatusCode)
            {
                var emps = result.Content.ReadAsAsync<List<Employee>>().Result;

                ddlEmployees.DataSource = emps;

                ddlEmployees.DisplayMember = "Name";
                ddlEmployees.ValueMember = "Id";

                comboBoxFilled = true;
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase + " " + result.StatusCode);
            }


        }

        private void fillGridView()
        {
            HttpClient client = new HttpClient();

            var result = client.GetAsync($"{baseUrl}employees").Result;

            // redundant
            //if(result.StatusCode==System.Net.HttpStatusCode.OK&&result.StatusCode==System.Net.HttpStatusCode.NoContent)

            if (result.IsSuccessStatusCode)
            {
                var emps = result.Content.ReadAsAsync<List<Employee>>().Result;
                dataGridView1.DataSource = emps;
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            var emp = new Employee
            {
                Name = txtName.Text,
                Salary = decimal.Parse(txtSalary.Text),
                Id = int.Parse(txtId.Text),
                DeptId=int.Parse(txtDepartment.Text)

            };

            var result = client.PostAsJsonAsync($"{baseUrl}employees", emp).Result;

            if (result.IsSuccessStatusCode)
            {
                // redundant
                //// base is api/
                //var res = client.GetAsync("employee").Result;
                //var emps=res.Content.ReadAsAsync<List<Employee>>().Result;
                //dataGridView1.DataSource = emps;

                fillGridView();
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase+" "+result.StatusCode);
            }
        }

        private void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxFilled) return;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            var result = client.GetAsync($"employees/{ddlEmployees.SelectedValue}").Result;

            if (result.IsSuccessStatusCode)
            {
               var selectedEmp= result.Content.ReadAsAsync<Employee>().Result;

                txtId.Text = selectedEmp.Id.ToString();

                txtName.Text = selectedEmp.Name;

                txtSalary.Text = selectedEmp.Salary.ToString();

                txtDepartment.Text = selectedEmp.DeptId.ToString();

            }
            else
            {
                MessageBox.Show(result.ReasonPhrase + " " + result.StatusCode);
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {

            var emp = new Employee
            {
                Name = txtName.Text,
                Salary = decimal.Parse(txtSalary.Text),
                Id = int.Parse(txtId.Text),
                DeptId = int.Parse(txtDepartment.Text)

            };

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            //var result= client.PutAsJsonAsync($"employee/{ddlEmployees.SelectedValue}", emp).Result;
            var result= client.PutAsJsonAsync($"employees/{txtId.Text}", emp).Result;

            if (result.IsSuccessStatusCode)
            {
                fillGridView();
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase + " " + result.StatusCode);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            var result = client.DeleteAsync($"{baseUrl}employees/{ddlEmployees.SelectedValue}").Result;


            if (result.IsSuccessStatusCode)
            {
                fillGridView();
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase + " " + result.StatusCode);
            }
        }
    }
}
