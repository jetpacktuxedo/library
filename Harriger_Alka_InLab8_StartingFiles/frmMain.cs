using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;

// Name:   frmMain.cs has the C# code for the program created during the 2/19/13 help session
// Author: Alka Harriger
// Date:   2/20/13
//
// This application gets student grade data from a text file and then displays the results in a list box.

public partial class frmMain : Form
{
    [STAThread]

    public static void Main()
    {
        frmMain main = new frmMain();
        Application.Run(main);
    }

    public frmMain()
    {
        InitializeComponent();
    }

    // Define frmMain class-scope variables and arrays so all methods can access the data.
    private string mUserFile;
    private ArrayList mStudentGrades = new ArrayList();

    // The overloaded validateInput helper methods handle the existence check, type check, and range check for a given 
    // input form object and assigns the equivalent value to its corresponding variable. (This one handles int data.)
    private bool validateInput(TextBox txtInput, int min, int max, out int userInput)
    {
        string fieldName;
        fieldName = txtInput.Name.Substring(3);
        userInput = 0;
        if (txtInput.Text == "")
        {
            ShowMessage("Please enter a value for " + fieldName);
            txtInput.Focus();
            return false;
        }
        if (int.TryParse(txtInput.Text, out userInput) == false)
        {
            ShowMessage("Only numbers are allowed for " + fieldName + ". Please re-enter:");
            txtInput.Focus();
            return false;
        }
        if (userInput < min || userInput > max)
        {
            ShowMessage(fieldName + " must be between " + min.ToString() + " and " + max.ToString());
            txtInput.Focus();
            return false;
        }
        return true;
    }

    // The overloaded validateInput helper methods handle the existence check, type check, and range check for a given 
    // input form object and assigns the equivalent value to its corresponding variable. (This one handles double data.)
    private bool validateInput(TextBox txtInput, double min, double max, out double userInput)
    {
        string fieldName;
        fieldName = txtInput.Name.Substring(3);
        userInput = 0D;
        if (txtInput.Text == "")
        {
            ShowMessage("Please enter a value for " + fieldName);
            txtInput.Focus();
            return false;
        }
        if (double.TryParse(txtInput.Text, out userInput) == false)
        {
            ShowMessage("Only numbers are allowed for " + fieldName + ". Please re-enter:");
            txtInput.Focus();
            return false;
        }
        if (userInput < min || userInput > max)
        {
            ShowMessage(fieldName + " must be between " + min.ToString() + " and " + max.ToString());
            txtInput.Focus();
            return false;
        }
        return true;
    }

    // The overloaded validateInput helper methods handle the existence check, type check, and range check for a given 
    // input form object and assigns the equivalent value to its corresponding variable. (This one handles decimal data.)
    private bool validateInput(TextBox txtInput, decimal min, decimal max, out decimal userInput)
    {
        string fieldName;
        fieldName = txtInput.Name.Substring(3);
        userInput = 0M;
        if (txtInput.Text == "")
        {
            ShowMessage("Please enter a value for " + fieldName);
            txtInput.Focus();
            return false;
        }
        if (decimal.TryParse(txtInput.Text, out userInput) == false)
        {
            ShowMessage("Only numbers are allowed for " + fieldName + ". Please re-enter:");
            txtInput.Focus();
            return false;
        }
        if (userInput < min || userInput > max)
        {
            ShowMessage(fieldName + " must be between " + min.ToString() + " and " + max.ToString());
            txtInput.Focus();
            return false;
        }
        return true;
    }

    // The ShowMessage helper method displays an error message with a standard title and an OK button.
    private void ShowMessage(string msg)
    {
        MessageBox.Show(msg, "Problem found", MessageBoxButtons.OK);
    }

    // When File-Exit is clicked, the program terminates.
    private void mnuFileExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    // When File-Open is clicked, the Open File dialog appears to allow the user to browse and locate
    // the desired data file from which the data will be retrieved and copied to the arrays.
    private void mnuFileOpen_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofd;
        try
        {
            ofd = new OpenFileDialog();
            ofd.Title = "Select the Student Grades file to open";
            ofd.Filter = "Grades (*.dat)|*.dat|All files (*.*)|*.*";
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"\Data\");
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mUserFile = ofd.FileName;
            }
        }
        catch (Exception ex)
        {
            ShowMessage("There was an unexpected problem with the open file dialogue" +
                ex.Message);
        }

        // Load data from file into arrays
        LoadFileIntoArray();

        // Display data in array in listbox
        ShowArrayInList();
    }

    // This helper method loads the data from the file specifed by the user and
    // populates the student grades array.
    private void LoadFileIntoArray()
    {
        string inputLine;
        clsGradeFile tempStudent;
        StreamReader sr = null;
        try
        {
            if (File.Exists(mUserFile) == true)
            {
                mStudentGrades.Clear();
                sr = new StreamReader(mUserFile);
                inputLine = sr.ReadLine();
                while (inputLine != null)
                {
                    tempStudent = new clsGradeFile();
                    tempStudent.Deserialize(inputLine);
                    mStudentGrades.Add(tempStudent);
                    inputLine = sr.ReadLine();
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage("There was an unexpected problem loading the data from the file " +
                mUserFile + ":" + ex.Message);
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
            }
        }
    }

    // This helper method will display the data in the arrays in the listbox.
    private void ShowArrayInList()
    {
        string outputLine;
        float classTotal = 0F;

        lstStudents.Items.Clear();

        // Build the table headers for diaply.

        outputLine = "      STUDENT NAME      " + " " + "TEST1" + " " + "TEST2" + " " +
            "TEST3" + " " + "TEST4" + " " + "TOTAL" + " " + "AVERAGE";
        lstStudents.Items.Add(outputLine);
        outputLine = "========================" + " " + "=====" + " " + "=====" + " " +
            "=====" + " " + "=====" + " " + "=====" + " " + "=======";
        lstStudents.Items.Add(outputLine);

        // Build each student record for display.
        foreach (clsGradeFile tempStudent in mStudentGrades)
        {
            float studentTotal = 0;
            outputLine = tempStudent.MyFirstName + " " + tempStudent.MyLastName;
            outputLine = outputLine.PadRight(24) + " ";
            
            // Cycle thru all the grade values for this student.
            for (int grIndex = 0; grIndex < 4; grIndex++)
            {
                outputLine += tempStudent.MyGrades[grIndex].ToString("##0.0").PadLeft(5) + " ";
                studentTotal += tempStudent.MyGrades[grIndex];
            }
            outputLine += studentTotal.ToString("##0.0").PadLeft(5) + " ";
            float average = studentTotal / 4F;
            outputLine += average.ToString("##0.0").PadLeft(5);
            lstStudents.Items.Add(outputLine);

            classTotal += studentTotal;
        }
        float classAverage = classTotal / (float) mStudentGrades.Count;
        lstStudents.Items.Add("                    ***** Class Average: " + classAverage.ToString() +
            " *****");
    }

    // When File-Save is clicked, the Save File dialog appears to allow the user to browse and locate
    // the desired data file to which the current array data will be saved.
    private void mnuFileSave_Click(object sender, EventArgs e)
    {
        SaveFileDialog sfd;
        try
        {
            sfd = new SaveFileDialog();
            sfd.Title = "Select the Student Grades file to save";
            sfd.Filter = "Grades (*.dat)|*.dat|All files (*.*)|*.*";
            sfd.InitialDirectory = Path.Combine(Application.StartupPath, @"\Data\");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                mUserFile = sfd.FileName;
            }
        }
        catch (Exception ex)
        {
            ShowMessage("There was an unexpected problem with the save file dialogue" +
                ex.Message);
        }

        // Save array data to file
        SaveArrayToFile();
    }

    // This helper method will write the array data to the user's specified file
    private void SaveArrayToFile()
    {
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter(mUserFile, false);
            foreach (clsGradeFile tempStudent in mStudentGrades)
            {
                sw.WriteLine(tempStudent.Serialize());
            }
            ShowMessage("The data was written to " + mUserFile);
        }
        catch (Exception ex)
        {
            ShowMessage("There was an unexpected problem writing the file " + mUserFile + ": " +
                ex.Message);
        }
        finally
        {
            if (sw != null)
            {
                sw.Close();
            }
        }
    }

    // When Search Name is clicked, the data in the ArrayList is searched for a match on first or last name.
    private void btnSearchName_Click(object sender, EventArgs e)
    {
        string outputLine = "";

        // Make sure something is entered for the name.
        if (txtSearchName.Text == "")
        {
            ShowMessage("Please enter a name to be searched.");
            txtSearchName.Focus();
            return;
        }
        foreach (clsGradeFile student in mStudentGrades)
        {
            if (string.Compare(student.MyFirstName, txtSearchName.Text) == 0 ||
                string.Compare(student.MyLastName, txtSearchName.Text) == 0)
            {
                outputLine += student.DisplayRecord() + "\r\n";
            }
        }
        if (outputLine == "")
        {
            ShowMessage("There are no students named " + txtSearchName.Text);
        }
        else
        {
            ShowMessage("The following matching student records were found:\r\n" + outputLine);
        }
    }

    // When search score is clicked, the data in the ArrayList is searched for a match on grade.
    private void btnSearchScore_Click(object sender, EventArgs e)
    {
        string outputLine = "";
        double searchGrade;

        // Make sure a valid grade has been entered.
        if (validateInput(txtSearchScore, 0D, 100D, out searchGrade) == false)
        {
            return;
        }
        foreach (clsGradeFile student in mStudentGrades)
        {
            for (int indx = 0; indx < student.MyGrades.Length; indx++)
            {
                if (student.MyGrades[indx] == searchGrade)
                {
                    outputLine += student.DisplayRecord() + "\r\n";
                    break;
                }
            }
        }
        if (outputLine == "")
        {
            ShowMessage("There are no students with a grade of " + txtSearchScore.Text);
        }
        else
        {
            ShowMessage("The following matching student records were found:\r\n" + outputLine);
        }

    }

    private void sortStudentGrades(int sortType)
    {
        bool swapped = true;
        while (swapped == true)
        {
            swapped = false;

            for (int nxtLoc = 1; nxtLoc < mStudentGrades.Count; nxtLoc++)
            {
                clsGradeFile compareOne = (clsGradeFile)mStudentGrades[nxtLoc - 1];
                clsGradeFile compareTwo = (clsGradeFile)mStudentGrades[nxtLoc];
                bool doSwap = false;

                switch (sortType)
                { 
                    case 1:
                        if (string.Compare(compareOne.MyFirstName, compareTwo.MyFirstName) > 0)
                        {
                            doSwap = true;
                        }
                        break;
                    case 2:
                        if (string.Compare(compareOne.MyLastName, compareTwo.MyLastName) > 0)
                        {
                            doSwap = true;
                        }
                        break;
                    case 3:
                        if (compareOne.MyGrades[3] > compareTwo.MyGrades[3])
                        {
                            doSwap = true;
                        }
                        break;
                    case 4:
                        if (compareOne.MyGrades[3] < compareTwo.MyGrades[3])
                        {
                            doSwap = true;
                        }
                        break;
                }

                if (doSwap == true)
                {
                    clsGradeFile temp = new clsGradeFile();
                    temp = (clsGradeFile)mStudentGrades[nxtLoc - 1];
                    mStudentGrades[nxtLoc - 1] = mStudentGrades[nxtLoc];
                    mStudentGrades[nxtLoc] = temp;
                    swapped = true;

                }
            }
        }
    }

    private void btnSortFirst_Click(object sender, EventArgs e)
    {
        sortStudentGrades(1);
        ShowArrayInList();
    }

    private void btnSortLast_Click(object sender, EventArgs e)
    {
        sortStudentGrades(2);
        ShowArrayInList();
    }

    private void btnGradeUp_Click(object sender, EventArgs e)
    {
        sortStudentGrades(3);
        ShowArrayInList();
    }

    private void btnGradeDown_Click(object sender, EventArgs e)
    {
        sortStudentGrades(4);
        ShowArrayInList();
    }

}