using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            // Initalize
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            // Show dashboard panel
            ShowPanel("Dashboard");
        }

        private void ShowPanel(string panelName)
        {
            if (panelName == "Dashboard" && !pnlDashboard.Visible) // If the panelName is Dashboard and is not visible...
            {
                // Hide all other panels
                HideAllPanels();

                // Show Dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }
            else if (panelName == "Students" && !pnlStudents.Visible) // If the panelName is Students and is not visible...
            {
                // Hide all other panels
                HideAllPanels();

                // Show Students
                pnlStudents.Show();

                try
                {
                    // fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService();
                    List<Student> studentList = studService.GetStudents();

                    // clear the listview ITEMS before filling it again !!Using list.Clear() will remove the column headers too.
                    listViewStudents.Items.Clear();

                    // For each Student object in the list, create a new List Item and fill details before adding it.
                    foreach (Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(s.Number.ToString());
                        li.SubItems.Add(s.FirstName);
                        li.SubItems.Add(s.LastName);
                        li.SubItems.Add(s.BirthDate.ToString("yyyy-MM-dd"));
                        listViewStudents.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    /* Display message box when an error occured with the appropiate error
                     *    !!When debugging and an exception occurs it will still break(This is a VS setting), but when
                     *    !!an user uses it they will only the see message box with the error, and with an OK button.
                     */
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }
            }
            else if (panelName == "Teachers" && !pnlTeachers.Visible) // If the panelName is Teachers and is not visible...
            {
                // Hide all other panels
                HideAllPanels();

                // Show Teachers
                pnlTeachers.Show();

                try
                {
                    /* Add code here for the teacher part (Look at student code above and what columns there are for teacher)
                     * Also you're gonna have to create a TeacherDAO.cs in SomerenDAL and TeacherService.cs in SomerenLogic
                     * I already set up the Teacher.cs in SomerenModel
                     * Good luck and ask questions!! :D 
                     */

                }
                catch (Exception e)
                {
                    /* Display message box when an error occured with the appropiate error
                     *   !!When debugging and an exception occurs it will still break(This is a VS setting), but when
                     *   !!an user uses it they will only the see message box with the error, and with an OK button.
                     */
                    MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
                }
            }
        }

        private void HideAllPanels()
        {
            // Hide all panels
            pnlDashboard.Hide();
            imgDashboard.Hide();
            pnlStudents.Hide();            
            pnlTeachers.Hide();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        private void DashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Call method to display panel Dashboard
            ShowPanel("Dashboard");
        }

        private void ImgDashboard_Click(object sender, EventArgs e)
        {
            // Display messagebox when image is clicked
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void StudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call method to display panel Students
            ShowPanel("Students");
        }

        private void LecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call method to display panel Teachers
            ShowPanel("Teachers");
        }
    }
}
