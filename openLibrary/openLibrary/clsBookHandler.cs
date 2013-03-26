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
        mBookID = id;
        mBookISBN = isbn;
        mBookTitle = title;
        mBookReleaseYear = year;
        mBookGenre = genre;
        mBookAuthor = author;

    }

    public string bookID
    {
        get
        {
            return mBookID;
        }
        set
        {
            mBookID = value;
        }

    }

    public string bookISBN
    {
        get
        {
            return mBookISBN;
        }
        set
        {
            mBookISBN = value;
        }

    }

    public string bookTitle
    {
        get
        {
            return mBookTitle;
        }
        set
        {
            mBookTitle = value;
        }

    }

    public string releaseYear
    {
        get
        {
            return mBookReleaseYear;
        }
        set
        {
            mBookReleaseYear = value;
        }

    }

    public string bookGenre
    {
        get
        {
            return mBookGenre;
        }
        set
        {
            mBookGenre = value;
        }

    }

    public string bookauthor
    {
        get
        {
            return mBookAuthor;
        }
        set
        {
            mBookAuthor = value;
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

