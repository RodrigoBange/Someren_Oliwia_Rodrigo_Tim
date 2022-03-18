using SomerenLogic;
using SomerenModel;
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
            if (panelName == "Dashboard") // If the panelName is Dashboard...
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
                catch (Exception ex)
                {
                    // Write error to log and get file path
                    string filePath = ErrorLogger.LogError(ex);

                    // Display message box when an error occured with the appropiate error
                    MessageBox.Show("Something went wrong while loading the students: " + ex.Message + Environment.NewLine
                        + Environment.NewLine + "Error log location: " + filePath);
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
                    // fill the teachers listview within the teachers panel with a list of teachers
                    TeacherService teacherService = new TeacherService();
                    List<Teacher> teacherList = teacherService.GetTeachers();

                    // clear the listview ITEMS before filling it again !!Using list.Clear() will remove the column headers too.
                    listViewTeachers.Items.Clear();

                    // For each Teacher object in the list, create a new List Item and fill details before adding it.
                    foreach (Teacher t in teacherList)
                    {
                        ListViewItem li = new ListViewItem(t.Number.ToString());
                        li.SubItems.Add(t.FirstName);
                        li.SubItems.Add(t.LastName);
                        if (t.Supervises)
                        {
                            li.SubItems.Add("Yes");
                        }
                        else { li.SubItems.Add("No"); }
                        listViewTeachers.Items.Add(li);
                    }
                }
                catch (Exception ex)
                {
                    // Write error to log and get file path
                    string filePath = ErrorLogger.LogError(ex);

                    // Display message box when an error occured with the appropiate error
                    MessageBox.Show("Something went wrong while loading the teachers: "
                        + ex.Message + Environment.NewLine + Environment.NewLine + "Error log location: " + filePath);
                }
            }
            else if (panelName == "DrinkInventory" && !pnlDrinkInventory.Visible) // If the panelName is Teachers and is not visible...
            {
                // Hide all other panels
                HideAllPanels();

                // Show Teachers
                pnlDrinkInventory.Show();

                try
                {
                    // fill the drinks listview within the drinks panel with a list of drinks
                    DrinkService drinkService = new DrinkService();
                    List<Drink> drinksList = drinkService.GetDrinks();

                    // clear the listview ITEMS before filling it again !!Using list.Clear() will remove the column headers too.
                    listViewDrinkInventory.Items.Clear();

                    // For each Student object in the list, create a new List Item and fill details before adding it.
                    foreach (Drink drink in drinksList)
                    {
                        ListViewItem li = new ListViewItem(drink.Number.ToString());
                        li.SubItems.Add(drink.Name);
                        li.SubItems.Add(drink.Price.ToString("€ 0.00"));
                        if (drink.Type) { li.SubItems.Add("Alcoholic"); } 
                        else { li.SubItems.Add("Non-Alcoholic"); }
                        li.SubItems.Add(drink.AmountSold.ToString());
                        li.SubItems.Add(drink.Stock.ToString());
                        if (drink.Stock >= 10) { li.SubItems.Add("Stock sufficient"); }
                        else { li.SubItems.Add("Stock nearly depleted"); }
                        listViewDrinkInventory.Items.Add(li);
                    }
                }
                catch (Exception ex)
                {
                    // Write error to log and get file path
                    string filePath = ErrorLogger.LogError(ex);

                    // Display message box when an error occured with the appropiate error
                    MessageBox.Show("Something went wrong while loading the drinks: " + ex.Message + Environment.NewLine
                        + Environment.NewLine + "Error log location: " + filePath);
                }
            }
            else if (panelName == "CashRegister" && !pnlCashRegister.Visible) // If the panelName is and is not visible...
            {
                // Hide all other panels
                HideAllPanels();

                // Show 
                pnlCashRegister.Show();

                try
                {
                    // fill the register students listview within the Cash Register panel with a list of students
                    StudentService studService = new StudentService();
                    List<Student> studentList = studService.GetStudents();

                    // fill the register drinks listview within the Cash Register panel with a list of drinks
                    DrinkService drinkService = new DrinkService();
                    List<Drink> drinksList = drinkService.GetDrinks();


                    // clear the listview ITEMS before filling it again !!Using list.Clear() will remove the column headers too.
                    listViewRegisterStudents.Items.Clear();
                    listViewRegisterDrinks.Items.Clear();

                    // For each Student object in the list, create a new List Item and fill details before adding it.
                    foreach (Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(s.Number.ToString());
                        li.SubItems.Add(s.FirstName);
                        li.SubItems.Add(s.LastName);
                        li.SubItems.Add(s.BirthDate.ToString("yyyy-MM-dd"));
                        listViewRegisterStudents.Items.Add(li);
                    }
                    // For each Drink object in the list, create a new List Item and fill details before adding it.
                    foreach (Drink drink in drinksList)
                    {
                        ListViewItem li = new ListViewItem(drink.Name);
                        li.SubItems.Add(drink.Price.ToString("€ 0.00"));
                        if (drink.Type) { li.SubItems.Add("Alcoholic"); }
                        else { li.SubItems.Add("Non-Alcoholic"); }
                        li.SubItems.Add(drink.Stock.ToString());
                        listViewRegisterDrinks.Items.Add(li);

                    }
                }
                catch (Exception ex)
                {
                    // Write error to log and get file path
                    string filePath = ErrorLogger.LogError(ex);

                    // Display message box when an error occured with the appropiate error
                    MessageBox.Show("Something went wrong while loading the students or drinks: " + ex.Message + Environment.NewLine
                        + Environment.NewLine + "Error log location: " + filePath);
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
            pnlDrinkInventory.Hide();
            pnlCashRegister.Hide();
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

        private void DrinkInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call method to display panel DrinkInventory
            ShowPanel("DrinkInventory");
        }

        private void CashRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call method to display panel CashRegister
            ShowPanel("CashRegister");
        }
        private void ListViewRegisterDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item !!SelectedIndex is not a thing in winforms.
            if (listViewRegisterDrinks.SelectedItems.Count > 0 && listViewRegisterStudents.SelectedItems.Count > 0)
            {
                // Get index 
                ListViewItem item = listViewRegisterDrinks.SelectedItems[0];

                // Set variable to the label and enable the button
                lbl_RegisterPrice.Text = item.SubItems[1].Text;
                btn_Checkout.Enabled = true;
            }
        }
        private void ListViewRegisterStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item !!SelectedIndex is not a thing in winforms.
            if (listViewRegisterStudents.SelectedItems.Count > 0 && listViewRegisterDrinks.SelectedItems.Count > 0)
            {
                // Get index 
                ListViewItem item = listViewRegisterDrinks.SelectedItems[0];

                // Set variable to the label and enable the button
                lbl_RegisterPrice.Text = item.SubItems[1].Text;
                btn_Checkout.Enabled = true;
            }
        }
        private void ListViewDrinkInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item !!SelectedIndex is not a thing in winforms.
            if (listViewDrinkInventory.SelectedItems.Count > 0)
            {
                // Get index 
                ListViewItem item = listViewDrinkInventory.SelectedItems[0];

                // Set variables to text boxes and combo box
                txtBox_DrinkName.Text = item.SubItems[1].Text;
                txtBox_DrinkPrice.Text = item.SubItems[2].Text.Substring(2);
                txtBox_DrinkStock.Text = item.SubItems[5].Text;

                if (item.SubItems[3].Text == "Alcoholic") { cBox_DrinkType.SelectedIndex = 1; }
                else { cBox_DrinkType.SelectedIndex = 0; }
            }           
        }
        private void btn_Checkout_Click(object sender, EventArgs e)
        {
            try
            {
                //if()
                CashRegister cashRegister = new CashRegister();

                int studentId = registerStudentId.Index;
                //int drinkId = registerDrinkId.Index;
                decimal paidAmount = registerDrinkPrice.Index;
                //datetime purchaseDate = ???

                // Add purchase
                //CashRegisterService.AddPurchase(studentId, drinkId, paidAmount, purchaseDate);

                // Refresh panel
                HideAllPanels();
                ShowPanel("CashRegister");

                // Clear text boxes (It doesn't clear with the panel refreshes)
                ResetAllInput();

            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while adding the purchase: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_AddDrink_Click(object sender, EventArgs e)
        {
            try
            {
                // If all fields have values...
                if (txtBox_DrinkName.Text != "" && txtBox_DrinkPrice.Text != "" && 
                    cBox_DrinkType.SelectedIndex > -1 && txtBox_DrinkStock.Text != "")
                {
                    //Create a new DrinkService object
                    DrinkService drinkService = new DrinkService();

                    // Get values from the textboxes
                    string drinkName = txtBox_DrinkName.Text;
                    decimal drinkPrice = decimal.Parse(txtBox_DrinkPrice.Text);
                    int drinkStock = int.Parse(txtBox_DrinkStock.Text);
                    bool drinkType;

                    // Get value from combobox
                    if (cBox_DrinkType.SelectedIndex == 0)
                    {
                        drinkType = false;
                    }
                    else { drinkType = true; }

                    // Add drink
                    drinkService.AddDrink(drinkName, drinkPrice, drinkStock, drinkType);

                    // Refresh panel
                    HideAllPanels();
                    ShowPanel("DrinkInventory");

                    // Clear text boxes (It doesn't clear with the panel refreshes)
                    ResetAllInput();
                }
                else
                {
                    MessageBox.Show("Please enter appropiate values.");
                }

            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while adding the drink: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_RemoveDrink_Click(object sender, EventArgs e)
        {
            try
            {
                // Get selected item !!SelectedIndex is not a thing in winforms.
                if (listViewDrinkInventory.SelectedItems.Count > 0)
                {
                    //Create a new DrinkService object
                    DrinkService drinkService = new DrinkService();

                    // Get index 
                    ListViewItem item = listViewDrinkInventory.SelectedItems[0];

                    // Get values from selected item
                    int drinkId = int.Parse(item.SubItems[0].Text);

                    // Remove drink
                    drinkService.RemoveDrink(drinkId);

                    // Refresh panel
                    HideAllPanels();
                    ShowPanel("DrinkInventory");

                    // Clear text boxes (It doesn't clear with the panel refreshes)
                    ResetAllInput();
                }
                else
                {
                    MessageBox.Show("Please select an item to remove.");
                }

            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while removing the drink: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_EditDrink_Click(object sender, EventArgs e)
        {
            try
            {
                // Get selected item !!SelectedIndex is not a thing in winforms.
                if (listViewDrinkInventory.SelectedItems.Count > 0)
                {
                    //Create a new DrinkService object
                    DrinkService drinkService = new DrinkService();

                    // Get index 
                    ListViewItem item = listViewDrinkInventory.SelectedItems[0];

                    // Get values from selected item
                    int drinkId = int.Parse(item.SubItems[0].Text);
                    string drinkName = txtBox_DrinkName.Text;
                    decimal drinkPrice = decimal.Parse(txtBox_DrinkPrice.Text);
                    bool drinkType;
                    if (cBox_DrinkType.SelectedIndex == 0) { drinkType = false; }
                    else { drinkType = true; }
                    int drinkStock = int.Parse(txtBox_DrinkStock.Text);                    

                    // Edit drink values
                    drinkService.EditDrink(drinkId, drinkName, drinkPrice, drinkType, drinkStock);

                    // Refresh panel
                    HideAllPanels();
                    ShowPanel("DrinkInventory");

                    // Clear text boxes (It doesn't clear with the panel refreshes)
                    ResetAllInput();
                }
                else
                {
                    MessageBox.Show("Please select an item to edit.");
                }

            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while editing the drink: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void ResetAllInput()
        {
            // Clear text boxes -- Drink Inventory
            txtBox_DrinkName.Clear();
            txtBox_DrinkPrice.Clear();
            cBox_DrinkType.SelectedValue = -1;
            txtBox_DrinkStock.Clear();
        }
    }
}
