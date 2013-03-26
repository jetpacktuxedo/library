using System;


public class clsBookHandler
{
    private string mBookID;
    private string mBookISBN;
    private string mBookTitle;
    private string mBookReleaseYear;
    private string mBookGenre;
    private string mBookAuthor;

    public clsBookHandler()
    {

    }

    public clsBookHandler(string id, string isbn, string title, string year, string genre, string author)
    {
        mcontactID = p;
        mFirstName = p2;
        mLastName = p3;
        mPhone1 = p4;
        mPhone2 = p5;
        mBirthdate = p6;
    }

    public int contactID
    {
        get
        {
            return mcontactID;
        }
        set
        {
            mcontactID = value;
        }

    }

    public string firstName
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

    public string lastName
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

    public string phone1
    {
        get
        {
            return mPhone1;
        }
        set
        {
            mPhone1 = value;
        }

    }

    public string phone2
    {
        get
        {
            return mPhone2;
        }
        set
        {
            mPhone2 = value;
        }

    }

    public DateTime birthdate
    {
        get
        {
            return mBirthdate;
        }
        set
        {
            mBirthdate = value;
        }

    }

    public string serialize()
    {
        return mcontactID.ToString().PadRight(10) + "    " +
               mFirstName.PadRight(10) + "    " +
               mLastName.PadRight(15) + "     " +
               mPhone1.PadRight(12) + "     " +
               mPhone2.PadRight(8) + "     " +
               mBirthdate.ToShortDateString().ToString().PadRight(10);

    }

}

