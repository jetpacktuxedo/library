using System;

public class clsGradeFile
{
    // List of the class data members.

    private string mFirstName;
    private string mLastName;
    private float[] mGrades;

    // ----------- Class constructors ----------------

    public clsGradeFile()
    {
        mFirstName = "";
        mLastName = "";
        mGrades = new float[4];
        for (int indx = 0; indx < 4; indx++)
        {
            mGrades[indx] = 0F;
        }
    }

    public clsGradeFile(string myFirstName, string myLastName, float[] myGrades)
    {
        mFirstName = myFirstName;
        mLastName = myLastName;
        mGrades= myGrades;
    }

    // ----------- Accessor methods for data members ----------------

    // Purpose: Reads or writes the mFirstName data member.
    public string MyFirstName
    {
        get
        {
            return mFirstName;
        }

        set
        {
            mFirstName = value;
        }
    }

    public string MyLastName
    {
        get
        {
            return mLastName;
        }

        set
        {
            mLastName = value;
        }
    }

    public float[] MyGrades
    {
        get
        {
            return mGrades;
        }

        set
        {
            mGrades = value;
        }
    }

    // ----------- End Accessor methods for data members ------------

    // Purpose:  Returns a string containing the object's state.
    public string Serialize()
    {
        string outputLine;
        outputLine = mFirstName + "\t"
            + mLastName;
        for (int indx = 0; indx < 4; indx++)
        {
            outputLine += "\t" + mGrades[indx].ToString();
        }
        return outputLine;
    }

    // Purpose: Populates the object's state from a serialized string.
    public void Deserialize(string serializedRecord)
    {
        int arrayIndex = 0;  // cycle thru the mGrades data member
        string[] values = serializedRecord.Split('\t');

        mFirstName = values[1];
        mLastName = values[0];

        for (int indx = 2; indx < 6; indx++)
        {
            mGrades[arrayIndex] = float.Parse(values[indx]);
            arrayIndex++;
        }
    }

    // Purpose:  Returns a string for display containing the object's state.
    public string DisplayRecord()
    {
        string outputLine;
        double total = 0D;
        outputLine = mFirstName + " " + mLastName + " Grades: ";
        for (int indx = 0; indx < 4; indx++)
        {
            total += mGrades[indx];
            outputLine += mGrades[indx].ToString() + ", ";
        }
        outputLine += "TOTAL: " + total.ToString();
        return outputLine;
    }

}