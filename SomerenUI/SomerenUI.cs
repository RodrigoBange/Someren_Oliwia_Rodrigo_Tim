using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            // Show login panel
            ShowPanel("Login");
        }

        /* PANEL BEHAVIOURS */
        private void ShowPanel(string panelName)
        {
            // Hide all other panels before loading new panel
            HideAllPanels();

            if (panelName == "Dashboard") // If the panelName is Dashboard...
            {
                // Show Dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }
            else if (panelName == "Login" && !pnlLogin.Visible)
            {
                // Show Login panel
                pnlLogin.Show();
            }
            else if (panelName == "Register" && !pnlRegister.Visible)
            {
                // Show Register panel
                pnlRegister.Show();
            }
            else if (panelName == "Students" && !pnlStudents.Visible) // If the panelName is Students and is not visible...
            {
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
                        ListViewItem li = new ListViewItem(drink.Number.ToString());
                        li.SubItems.Add(drink.Name);
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
            else if (panelName == "Activities" && !pnlActivities.Visible)
            {
                // Show activities
                pnlActivities.Show();

                try
                {
                    // fill the activity listview within the activities panel with a list of activities
                    ActivityService activityService = new ActivityService();
                    List<Activity> activityList = activityService.GetActivities();

                    // clear the listview ITEMS before filling it again !!Using list.Clear() will remove the column headers too.
                    listViewActivities.Items.Clear();

                    // For each Student object in the list, create a new List Item and fill details before adding it.
                    foreach (Activity activity in activityList)
                    {
                        ListViewItem li = new ListViewItem(activity.Number.ToString());
                        li.SubItems.Add(activity.Name);
                        li.SubItems.Add(activity.Description);
                        li.SubItems.Add(activity.StartDate.ToString("dd/MM/yyyy HH:mm"));
                        li.SubItems.Add(activity.EndDate.ToString("dd/MM/yyyy HH:mm"));
                        listViewActivities.Items.Add(li);
                    }
                }
                catch (Exception ex)
                {
                    // Write error to log and get file path
                    string filePath = ErrorLogger.LogError(ex);

                    // Display message box when an error occured with the appropiate error
                    MessageBox.Show("Something went wrong while loading the activies: " + ex.Message + Environment.NewLine
                        + Environment.NewLine + "Error log location: " + filePath);
                }
            }
            else if (panelName == "Supervisors" && !pnlSupervisors.Visible)
            {
                // Show supervisors
                pnlSupervisors.Show();

                try
                {
                    // Fill the activity listview with activities
                    ActivityService activityService = new ActivityService();
                    List<Activity> activities = activityService.GetActivities();

                    // Clear the listview before adding items
                    listViewSupervisorActivities.Items.Clear();
                    listViewActivitiesNonSupervisors.Items.Clear();
                    listViewActivitySupervisors.Items.Clear();

                    // Add the activities to the list
                    foreach (Activity activity in activities)
                    {
                        ListViewItem li = new ListViewItem(activity.Number.ToString());
                        li.SubItems.Add(activity.Name);
                        listViewSupervisorActivities.Items.Add(li);
                    }
                }
                catch (Exception ex)
                {
                    // Write error to log and get file path
                    string filePath = ErrorLogger.LogError(ex);

                    // Display message box when an error occured with the appropiate error
                    MessageBox.Show("Something went wrong while loading the activies: " + ex.Message + Environment.NewLine
                        + Environment.NewLine + "Error log location: " + filePath);
                }
            }
        }

        private void HideAllPanels()
        {
            // Hide all panels
            pnlDashboard.Hide();
            pnlLogin.Hide();
            pnlRegister.Hide();
            imgDashboard.Hide();
            pnlStudents.Hide();            
            pnlTeachers.Hide();
            pnlDrinkInventory.Hide();
            pnlCashRegister.Hide();
            pnlActivities.Hide();
            pnlSupervisors.Hide();
        }

        /* ALL TOOLTIP MENU ITEM METHODS */
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

        private void ActivitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call method to display panel Activities
            ShowPanel("Activities");
        }

        private void SupervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call method to display panel Supervisors
            ShowPanel("Supervisors");
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display logged out message
            MessageBox.Show("Successfully logged out.");

            // Disable menu strip for user
            menuStrip1.Visible = false;

            // Reset all input boxes
            ResetAllInput();

            // Call method to go back to the login panel
            ShowPanel("Login");
        }

        /* LISTVIEW BEHAVIOURS */
        private void ListViewRegisterDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item !!SelectedIndex is not a thing in winforms.
            if (listViewRegisterDrinks.SelectedItems.Count > 0 && listViewRegisterStudents.SelectedItems.Count > 0)
            {
                // Get index 
                ListViewItem item = listViewRegisterDrinks.SelectedItems[0];

                // Set variable to the label and enable the button
                lbl_RegisterPrice.Text = item.SubItems[2].Text;
                btn_Checkout.Enabled = true;
                btn_StockMinus.Enabled = true;
                btn_StockPlus.Enabled = true;
                lbl_DrinksAmount.Text = "1";
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
                lbl_RegisterPrice.Text = item.SubItems[2].Text;
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

        private void ListViewSupervisorActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Get selected item
                if (listViewSupervisorActivities.SelectedItems.Count > 0)
                {
                    // Get Listview item and activityId
                    ListViewItem item = listViewSupervisorActivities.SelectedItems[0];
                    int activityId = int.Parse(item.SubItems[0].Text);

                    // Fill the supervisor listview with supervisors from that activity
                    SuperviseService superviseService = new SuperviseService();
                    List<Supervise> supervisors = superviseService.GetSupervisors(activityId);

                    // Clear the listview before adding items
                    listViewActivitySupervisors.Items.Clear();

                    // Add the supervisors to the list
                    foreach (Supervise supervisor in supervisors)
                    {
                        ListViewItem li = new ListViewItem(supervisor.EmployeeId.ToString());
                        li.SubItems.Add($"{supervisor.FirstName} {supervisor.LastName}");
                        listViewActivitySupervisors.Items.Add(li);
                    }

                    // Fill the non supervisor listview with teachers who are not supervising the activity
                    List<Supervise> nonSupervisors = superviseService.GetNonSupervisors(activityId);

                    // Clear the listview before adding items
                    listViewActivitiesNonSupervisors.Items.Clear();
                    
                    // Delete all existing supervisors with the same from nonsupervisors
                    for (int i = 0; i < supervisors.Count; i++)
                    {
                        if (nonSupervisors.Any(nonSupervisor => nonSupervisor.EmployeeId == supervisors[i].EmployeeId))
                        {
                            nonSupervisors.RemoveAll(nonSupervisor => nonSupervisor.EmployeeId == supervisors[i].EmployeeId);
                        }
                    }                  
                    
                    // Remove all duplicates and refresh list
                    var distinctTeachers = nonSupervisors.GroupBy(x => x.EmployeeId).Select(x => x.First());
                    List<Supervise> distinctNonSupervisors = new List<Supervise>();

                    // Add distinct non supervisors to the new list
                    foreach(var teacher in distinctTeachers)
                    {
                        distinctNonSupervisors.Add(teacher);
                    }

                    // Add all non supervisors to the listview
                    foreach (Supervise nonSupervisor in distinctNonSupervisors)
                    {
                        ListViewItem li = new ListViewItem(nonSupervisor.EmployeeId.ToString());
                        li.SubItems.Add($"{nonSupervisor.FirstName} {nonSupervisor.LastName}");
                        listViewActivitiesNonSupervisors.Items.Add(li);
                    }
                }
                else
                {
                    // Disable buttons
                    btn_AddSupervisor.Enabled = false;
                    btn_RemoveSupervisor.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while removing the activity: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void ListViewActivitySupervisors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable or disable button depending on if an item is selected
            if (listViewActivitySupervisors.SelectedItems.Count > 0)
            {
                btn_RemoveSupervisor.Enabled = true;
            }
            else
            {
                btn_RemoveSupervisor.Enabled = false;
            }
        }

        private void ListViewActivitiesNonSupervisors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable or disable button depending on if an item is selected
            if (listViewActivitiesNonSupervisors.SelectedItems.Count > 0)
            {
                btn_AddSupervisor.Enabled = true;
            }
            else
            {
                btn_AddSupervisor.Enabled = false;
            }
        }

        private void ListViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item !!SelectedIndex is not a thing in winforms.
            if (listViewActivities.SelectedItems.Count > 0)
            {
                // Get index 
                ListViewItem item = listViewActivities.SelectedItems[0];

                //Set values to boxes
                txtBox_ActivityName.Text = item.SubItems[1].Text;
                txtBox_ActivityDescription.Text = item.SubItems[2].Text;
                dateTimePickerStart.Value = DateTime.ParseExact(item.SubItems[3].Text, "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
                dateTimePickerEnd.Value = DateTime.ParseExact(item.SubItems[4].Text, "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
            }
        }

        /* BUTTON BEHAVIOURS */
        private void Btn_Checkout_Click(object sender, EventArgs e)
        {
            try
            {
                // If both lists have a value 
                if (listViewRegisterStudents.SelectedItems.Count > 0 && listViewRegisterDrinks.SelectedItems.Count > 0)
                {
                    // Get the index of both lists
                    ListViewItem itemStudent = listViewRegisterStudents.SelectedItems[0];
                    ListViewItem itemDrink = listViewRegisterDrinks.SelectedItems[0];

                    // Create new CashRegister object
                    CashRegister cashRegister = new CashRegister
                    {
                        StudentNumber = int.Parse(itemStudent.SubItems[0].Text),
                        DrinkNumber = int.Parse(itemDrink.SubItems[0].Text),
                        PaidAmount = decimal.Parse(lbl_RegisterPrice.Text.Substring(2)),
                        PurchaseDate = DateTime.Now,
                        DrinksAmount = int.Parse(lbl_DrinksAmount.Text)
                    };

                    // If there is stock, continue with checkout
                    if (int.Parse(itemDrink.SubItems[4].Text) != 0)
                    {
                        // Create new CashRegisterSerivce
                        CashRegisterService cashRegisterService = new CashRegisterService();

                        // If purchase exists
                        if (cashRegisterService.CheckPurchases(cashRegister.StudentNumber, cashRegister.DrinkNumber))
                        {
                            // Edit purchase
                            cashRegisterService.UpdatePurchase(cashRegister);
                        }
                        else
                        {
                            // Add purchase
                            cashRegisterService.AddPurchase(cashRegister);
                        }

                        // Edit Stock
                        DrinkService drinkService = new DrinkService();
                        drinkService.UpdateStock(cashRegister.DrinkNumber, cashRegister.DrinksAmount);

                        // Refresh panel
                        HideAllPanels();
                        ShowPanel("CashRegister");

                        // Clear text boxes (It doesn't clear with the panel refreshes)
                        ResetAllInput();
                    }
                    else
                    {
                        // Display message
                        MessageBox.Show("Sorry, there is no stock. Please select a different drink.");
                    }
                }
                else
                {
                    // Display message
                    MessageBox.Show("Please select a student and a drink.");
                }
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

        private void Btn_StockMinus_Click(object sender, EventArgs e)
        {
            // Get number from label
            int counter = int.Parse(lbl_DrinksAmount.Text);

            // If both lists have a value 
            if (listViewRegisterStudents.SelectedItems.Count > 0 && listViewRegisterDrinks.SelectedItems.Count > 0)
            {
                // Get the index of drink list
                ListViewItem itemDrink = listViewRegisterDrinks.SelectedItems[0];

                // Get Price
                decimal drinkPrice = decimal.Parse(itemDrink.SubItems[2].Text.Substring(2));

                // Adjust the counter but never allow less than 1
                if (counter <= 1) { counter = 1; }
                else { counter--; }

                // Add new number to label
                lbl_RegisterPrice.Text = $"€ {(drinkPrice * counter)}";
                lbl_DrinksAmount.Text = counter.ToString();
            }
        }

        private void Btn_StockPlus_Click(object sender, EventArgs e)
        {
            // Get number from label
            int counter = int.Parse(lbl_DrinksAmount.Text);

            // If both lists have a value 
            if (listViewRegisterStudents.SelectedItems.Count > 0 && listViewRegisterDrinks.SelectedItems.Count > 0)
            {
                // Get the index of drink list
                ListViewItem itemDrink = listViewRegisterDrinks.SelectedItems[0];

                // Get Stock Amount and Price
                int stockAmount = int.Parse(itemDrink.SubItems[4].Text);
                decimal drinkPrice = decimal.Parse(itemDrink.SubItems[2].Text.Substring(2));

                // Adjust the counter but only up to and equal to the stock amount
                if (counter >= stockAmount) { counter = stockAmount; }
                else { counter++; }

                // Update text labels
                lbl_RegisterPrice.Text = $"€ {(drinkPrice * counter)}";
                lbl_DrinksAmount.Text = counter.ToString();
            }
        }

        private void Btn_AddActivity_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new ActivityService object
                ActivityService activityService = new ActivityService();

                // Create list of all existing activities
                List<Activity> activities = activityService.GetActivities();

                // Bool for if activity exists
                bool activityExists = false;

                // If all fields have values...
                if (txtBox_ActivityName.Text != "" && txtBox_ActivityDescription.Text != "" &&
                    dateTimePickerStart.Value != null && dateTimePickerEnd.Value != null && (dateTimePickerStart.Value < dateTimePickerEnd.Value))
                {
                    // Get values from the textboxes
                    string activityName = txtBox_ActivityName.Text;
                    string description = txtBox_ActivityDescription.Text;
                    DateTime startDate = DateTime.ParseExact(dateTimePickerStart.Value.ToString("dd/MM/yyyy hh:mm"), "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
                    DateTime endDate = DateTime.ParseExact(dateTimePickerEnd.Value.ToString("dd/MM/yyyy hh:mm"), "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);

                    //MessageBox.Show(dateTimePickerStart.Value.ToString("dd/MM/yyyy hh:mm"));

                    // Check if activity already exists
                    foreach (Activity activity in activities)
                    {
                        if (activity.Name == activityName && activity.StartDate == startDate && activity.EndDate == endDate)
                        {
                            // Set bool to true
                            activityExists = true;

                            // Stop the loop
                            break;
                        }
                    }

                    // If activity does not exist
                    if (!activityExists)
                    {
                        // Add activity
                        activityService.AddActivity(activityName, description, startDate, endDate);

                        // Refresh panel
                        HideAllPanels();
                        ShowPanel("Activities");

                        // Clear text boxes (It doesn't clear with the panel refreshes)
                        ResetAllInput();
                    }
                    else
                    {
                        // Display message about existing activity
                        MessageBox.Show("This activity already exists at the time and date.");
                    }
                }
                else
                {
                    // Display message about incorrect values
                    MessageBox.Show("Please enter appropiate values.");
                }

            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while adding the activity: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_ChangeActivity_Click(object sender, EventArgs e)
        {
            try
            {
                // Get selected item
                if (listViewActivities.SelectedItems.Count > 0)
                {
                    // Create a new ActivityService object
                    ActivityService activityService = new ActivityService();

                    // Get index 
                    ListViewItem item = listViewActivities.SelectedItems[0];

                    // Get values from selected item
                    int activityId = int.Parse(item.SubItems[0].Text);
                    string activityName = txtBox_ActivityName.Text;
                    string description = txtBox_ActivityDescription.Text;
                    DateTime startDate = DateTime.ParseExact(dateTimePickerStart.Value.ToString("dd/MM/yyyy hh:mm"), "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
                    DateTime endDate = DateTime.ParseExact(dateTimePickerEnd.Value.ToString("dd/MM/yyyy hh:mm"), "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);

                    // Change activity values
                    activityService.ChangeActivity(activityId, activityName, description, startDate, endDate);

                    // Refresh panel
                    HideAllPanels();
                    ShowPanel("Activities");

                    // Clear text boxes (It doesn't clear with the panel refreshes)
                    ResetAllInput();
                }
                else
                {
                    MessageBox.Show("Please select an item to change.");
                }
            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while changing the activity: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_RemoveActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you wish to remove this activity?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Get selected item
                    if (listViewActivities.SelectedItems.Count > 0)
                    {
                        // Create a new ActivityService object
                        ActivityService activityService = new ActivityService();

                        // Get index 
                        ListViewItem item = listViewActivities.SelectedItems[0];

                        // Get values from selected item
                        int activityId = int.Parse(item.SubItems[0].Text);

                        // Remove activity
                        activityService.RemoveActivity(activityId);

                        // Refresh panel
                        HideAllPanels();
                        ShowPanel("Activities");

                        // Clear text boxes (It doesn't clear with the panel refreshes)
                        ResetAllInput();
                        
                    }
                    else
                    {
                        MessageBox.Show("Please select an item to remove.");
                    }
                }

            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while removing the activity: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_RemoveSupervisor_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure that you wish to remove this supervisor?", "Confirmation required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Create new SuperviseService
                    SuperviseService supervisedb = new SuperviseService();

                    // Get selected index from listviewActivities and the activity id
                    int activityIndex = listViewSupervisorActivities.SelectedItems[0].Index;
                    ListViewItem activityItem = listViewSupervisorActivities.SelectedItems[0];
                    int activityId = int.Parse(activityItem.SubItems[0].Text);

                    // Get selected index from listViewSupervisors and the employee id
                    ListViewItem supervisorItem = listViewActivitySupervisors.SelectedItems[0];
                    int employeeId = int.Parse(supervisorItem.SubItems[0].Text);

                    // Delete supervisor from activity
                    supervisedb.RemoveSupervisor(activityId, employeeId);

                    // Refresh listviews
                    ResetAllInput();
                    if (listViewSupervisorActivities.SelectedItems.Count > 0)
                    {
                        listViewSupervisorActivities.Items[activityIndex].Selected = false;
                        listViewSupervisorActivities.Select();
                        listViewSupervisorActivities.Items[activityIndex].Selected = true;
                        listViewSupervisorActivities.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while removing the supervisor: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_AddSupervisor_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure that you wish to add this supervisor?", "Confirmation required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Create new SuperviseService
                    SuperviseService supervisedb = new SuperviseService();

                    // Get selected index from listviewActivities and the activity id
                    int activityIndex = listViewSupervisorActivities.SelectedItems[0].Index;
                    ListViewItem activityItem = listViewSupervisorActivities.SelectedItems[0];
                    int activityId = int.Parse(activityItem.SubItems[0].Text);

                    // Get selected index from listViewSupervisors and the employee id
                    ListViewItem supervisorItem = listViewActivitiesNonSupervisors.SelectedItems[0];
                    int employeeId = int.Parse(supervisorItem.SubItems[0].Text);

                    // Add supervisor to activity
                    supervisedb.AddSupervisor(activityId, employeeId);

                    // Refresh listviews
                    ResetAllInput();
                    if (listViewSupervisorActivities.SelectedItems.Count > 0)
                    {
                        listViewSupervisorActivities.Items[activityIndex].Selected = false;
                        listViewSupervisorActivities.Select();
                        listViewSupervisorActivities.Items[activityIndex].Selected = true;
                        listViewSupervisorActivities.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while adding the supervisor: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_DirectToLogin_Click(object sender, EventArgs e)
        {
            // Clear boxes (In case of user swapping)
            ResetAllInput();

            // Show Login panel
            ShowPanel("Login");
        }

        private void Btn_DirectToRegister_Click(object sender, EventArgs e)
        {
            // Clear boxes (In case of user swapping)
            ResetAllInput();

            // Show Register panel
            ShowPanel("Register");
        }

        /* RESET ALL INPUT METHOD */
        private void ResetAllInput()
        {
            // Clear text boxes -- Drink Inventory
            txtBox_DrinkName.Clear();
            txtBox_DrinkPrice.Clear();
            cBox_DrinkType.SelectedValue = -1;
            txtBox_DrinkStock.Clear();

            // Clear text and reset buttons to default -- Cash Register
            btn_StockMinus.Enabled = false;
            btn_StockPlus.Enabled = false;
            btn_Checkout.Enabled = false;
            lbl_RegisterPrice.Text = "€0.00";
            lbl_DrinksAmount.Text = "0";

            // Clear text boxes -- Activity
            txtBox_ActivityName.Clear();
            txtBox_ActivityDescription.Clear();

            // Disable all buttons - Supervisors
            btn_AddSupervisor.Enabled = false; 
            btn_RemoveSupervisor.Enabled = false;

            // Clear text boxes -- Login
            txtBox_LoginEmail.Clear();
            txtBox_LoginPassword.Clear();

            // Clear text boxes -- Register
            txtBox_RegisterEmail.Clear();
            txtBox_RegisterPassword.Clear();
            txtBox_RegisterPasswordRetype.Clear();
        }

        /* DECIDE FUNCTIONS BY USER TYPE METHOD */
        private void FunctionsByUserType(Account user)
        {
            if (user.IsAdmin)
            {
                // Enable all buttons to adjust values
                //-- Activities
                btn_AddActivity.Visible = true;
                btn_RemoveActivity.Visible = true;
                btn_ChangeActivity.Visible = true;
                txtBox_ActivityName.Visible = true;
                txtBox_ActivityDescription.Visible = true;
                dateTimePickerStart.Visible = true;
                dateTimePickerEnd.Visible = true;
                lbl_ActivityName.Visible = true;
                lbl_ActivityDescription.Visible = true;
                lbl_ActivityStartDate.Visible = true;
                lbl_ActivityEndDate.Visible = true;

                //-- Supervisors
                btn_AddSupervisor.Visible = true;
                btn_RemoveSupervisor.Visible = true;

                //-- Drinks
                btn_AddDrink.Visible = true;
                btn_RemoveDrink.Visible = true;
                btn_EditDrink.Visible = true;
                txtBox_DrinkName.Visible = true;
                txtBox_DrinkPrice.Visible = true;
                txtBox_DrinkStock.Visible = true;
                cBox_DrinkType.Visible = true;
                lbl_DrinkName.Visible = true;
                lbl_DrinkPrice.Visible = true;
                lbl_DrinkType.Visible = true;
                lbl_DrinkStock.Visible = true;

                //-- Stock
                btn_StockPlus.Visible = true;
                btn_StockMinus.Visible = true;
                btn_Checkout.Visible = true;
            }
            else
            {
                // Disable all buttons to adjust values
                //-- Activities
                btn_AddActivity.Visible = false;
                btn_RemoveActivity.Visible = false;
                btn_ChangeActivity.Visible = false;
                txtBox_ActivityName.Visible = false;
                txtBox_ActivityDescription.Visible = false;
                dateTimePickerStart.Visible = false;
                dateTimePickerEnd.Visible = false;
                lbl_ActivityName.Visible = false;
                lbl_ActivityDescription.Visible = false;
                lbl_ActivityStartDate.Visible = false;
                lbl_ActivityEndDate.Visible = false;

                //-- Supervisors
                btn_AddSupervisor.Visible = false;
                btn_RemoveSupervisor.Visible = false;

                //-- Drinks
                btn_AddDrink.Visible = false;
                btn_RemoveDrink.Visible = false;
                btn_EditDrink.Visible = false;
                txtBox_DrinkName.Visible = false;
                txtBox_DrinkPrice.Visible = false;
                txtBox_DrinkStock.Visible = false;
                cBox_DrinkType.Visible = false;
                lbl_DrinkName.Visible = false;
                lbl_DrinkPrice.Visible = false;
                lbl_DrinkType.Visible = false;
                lbl_DrinkStock.Visible = false;

                //-- Stock
                btn_StockPlus.Visible = true;
                btn_StockMinus.Visible = true;
                btn_Checkout.Visible = false;
            }

            // Enable all navigation buttons
            menuStrip1.Visible = true;

            // Open dashboard
            ShowPanel("Dashboard");
        }

        private void Btn_LogIn_Click(object sender, EventArgs e)
        {
            try
            {   
                // Get txtBox info
                string email = txtBox_LoginEmail.Text;
                string password = txtBox_LoginPassword.Text;

                // If values have been entered
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    // Create new AccountService
                    AccountService accountService = new AccountService();

                    // Get user information from database
                    Account user = accountService.GetUserInfo(email);

                    // If user has been found
                    if (user != null)
                    {
                        // Convert password
                        PasswordWithSaltHasher hasher = new PasswordWithSaltHasher();
                        HashWithSaltResult convertedHashResult = hasher.ConvertedHashWithSalt(password, user.Salt);
                        string convertedPassword = convertedHashResult.Salt + convertedHashResult.Digest;

                        // Test Messagebox to compare hashed+salted passwords from user input and database password
                        //MessageBox.Show(user.Password + Environment.NewLine + Environment.NewLine + convertedPassword);

                        // Validate password
                        if (convertedPassword == user.Password)
                        {
                            // Display success message
                            MessageBox.Show("Sucessfully logged in.");

                            // Open all functionalities
                            FunctionsByUserType(user);
                        }
                        else
                        {
                            // Display user error
                            MessageBox.Show("Incorrect email / password combination. Please try again.");
                        }
                    }
                    else
                    {
                        // Display email not found error
                        MessageBox.Show("Email not found. Please try again.");
                    }
                }
                else
                {
                    // Display blank fields error
                    MessageBox.Show("Please fill in all fields.");
                }
            }
            catch (Exception ex)
            {
                // Write error to log and get file path
                string filePath = ErrorLogger.LogError(ex);

                // Display message box when an error occured with the appropiate error
                MessageBox.Show("Something went wrong while trying to log in: " + ex.Message + Environment.NewLine
                    + Environment.NewLine + "Error log location: " + filePath);
            }
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {

        }
    }
}
