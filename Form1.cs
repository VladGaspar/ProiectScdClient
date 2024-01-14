using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace SCRDesktopApp
{
    public partial class Form1 : Form
    {
        EmployeeService employeeService;
        List<int> employeeThresholdList;
        List<Department> departmentList;
        int departmentIdForEmployee;
        int employeeThreshold;
        public Form1()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            employeeService.createConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var token = employeeService.login();
            this.employeeThresholdList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            this.departmentList = employeeService.getDepartments();
            this.departmentList = employeeService.getDepartments();

            comboBox1.DataSource = departmentList;
            comboBox1.DisplayMember = "Description";
            comboBox1.ValueMember = "Id";

            comboBox2.DataSource = employeeThresholdList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
             listBox1.DataSource = this.employeeService.getEmployeesByDepartment(this.departmentIdForEmployee);
            listBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem is int selectedValue)
            {
                // Cast the selected item to the Department type
                this.departmentIdForEmployee = (int)comboBox1.SelectedValue;
                Console.WriteLine(comboBox1.SelectedValue);
                // Use the departmentId as needed
                Console.WriteLine("Selected Department ID: " + this.departmentIdForEmployee);
            }
            else
            {
                Department selectedDepartment = (Department)comboBox1.SelectedItem;
                this.departmentIdForEmployee = selectedDepartment.Id;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = this.employeeService.getAllByNumber(this.employeeThreshold);
            listBox2.DisplayMember = "Description";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem is int selectedValue)
            {
                // Cast the selected item to the Department type
                this.employeeThreshold = (int)comboBox2.SelectedValue;
                Console.WriteLine(comboBox2.SelectedValue);
                // Use the departmentId as needed
                Console.WriteLine("Selected Employee numberr: " + this.employeeThreshold);
            }
            else
            {
             /*   Department selectedDepartment = (Department)comboBox2.SelectedItem;
                this.employeeThreshold = selectedDepartment.Id;*/
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
