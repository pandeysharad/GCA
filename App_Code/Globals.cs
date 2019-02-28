using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;


public class Globals
{
    static DataClassesDataContext obj = new DataClassesDataContext();
    public static string connectionString = ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ConnectionString.Trim();

	public Globals()
	{
		
	}
   
    public static string Encryptdata(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);
        strmsg = Convert.ToBase64String(encode);
        return strmsg;
    }

    public static string Decryptdata(string encryptpwd)
    {
        string decryptpwd = string.Empty;
        UTF8Encoding encodepwd = new UTF8Encoding();
        Decoder Decode = encodepwd.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encryptpwd);


        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        decryptpwd = new String(decoded_char);
        return decryptpwd;
    }
    public static void Message(Page objpage, string Message)
    {
        ScriptManager.RegisterClientScriptBlock(objpage, objpage.GetType(), "HMS:Message ", "alert('" + Message + "');", true);
    }


        public static string GetMoneyString(double money)
    {
        string moneyString = money.ToString();

        string[] moneyStringArray = moneyString.Split('.');

        if (moneyStringArray.Length == 1)
        {
            return money.ToString() + ".00";
        }
        else
        {
            return money.ToString();
        }
    }

    // ..................................................................

        public static string GetMoneyFigure(string amount)
    {
        string[] amountArray = amount.Split('.');

        string figure = string.Empty;

        string amountBeforeDecimal = amountArray[0].ToString();

        int lengthAmount = amountBeforeDecimal.Length;

        if (lengthAmount == 1)
        {
            figure = GetNumString(amountBeforeDecimal);
        }

        if (lengthAmount == 2)
        {
            figure = GetNumTenthPlace(amountBeforeDecimal);
        }

        if (lengthAmount == 3)
        {
            figure = GetNumHundredPlace(amountBeforeDecimal);
        }

        if (lengthAmount == 4)
        {
            figure = GetNumThousandPlace(amountBeforeDecimal);
        }

        if (lengthAmount == 5)
        {
            figure = GetNumTenThousandPlace(amountBeforeDecimal);
        }

        if (lengthAmount == 6)
        {
            figure = GetNumLakhPlace(amountBeforeDecimal);
        }

        if (lengthAmount == 7)
        {
            figure = GetNumTenthLakhPlace(amountBeforeDecimal);
        }

        if (lengthAmount == 8)
        {

        }

        return figure;
    }

        protected static string GetNumString(string number)
    {
        string figure = string.Empty;

        //if (number == "0")
        //{
        //    figure = "Zero";
        //}

        if (number == "1")
        {
            figure = "One";
        }

        if (number == "2")
        {
            figure = "Two";
        }

        if (number == "3")
        {
            figure = "Three";
        }

        if (number == "4")
        {
            figure = "Four";
        }

        if (number == "5")
        {
            figure = "Five";
        }

        if (number == "6")
        {
            figure = "Six";
        }

        if (number == "7")
        {
            figure = "Seven";
        }

        if (number == "8")
        {
            figure = "Eight";
        }

        if (number == "9")
        {
            figure = "Nine";
        }

        return figure;
    }

        protected static string GetNumTenthPlace(string number)
    {
        string tenthPlace = number[0].ToString();
        string unitPalce = number[1].ToString();
        string figure = string.Empty;

        if (tenthPlace == "1")
        {
            if (unitPalce == "0")
            {
                figure = "Ten";
            }

            if (unitPalce == "1")
            {
                figure = "Eleven";
            }

            if (unitPalce == "2")
            {
                figure = "Twelve";
            }

            if (unitPalce == "3")
            {
                figure = "Thirteen";
            }

            if (unitPalce == "4")
            {
                figure = "Fourteen";
            }

            if (unitPalce == "5")
            {
                figure = "Fifteen";
            }

            if (unitPalce == "6")
            {
                figure = "Sixteen";
            }

            if (unitPalce == "7")
            {
                figure = "Seventeen";
            }

            if (unitPalce == "8")
            {
                figure = "Eighteen";
            }

            if (unitPalce == "9")
            {
                figure = "Nineteen";
            }

        }

        if (tenthPlace == "2")
        {
            if (unitPalce == "0")
            {
                figure = "Twenty";
            }
            else
            {
                figure = "Twenty " + GetNumString(unitPalce);
            }
        }

        if (tenthPlace == "3")
        {
            if (unitPalce == "0")
            {
                figure = "Thirty";
            }
            else
            {
                figure = "Thirty " + GetNumString(unitPalce);
            }
        }

        if (tenthPlace == "4")
        {
            if (unitPalce == "0")
            {
                figure = "Forty";
            }
            else
            {
                figure = "Forty " + GetNumString(unitPalce);
            }
        }

        if (tenthPlace == "5")
        {
            if (unitPalce == "0")
            {
                figure = "Fifty";
            }
            else
            {
                figure = "Fifty " + GetNumString(unitPalce);
            }
        }

        if (tenthPlace == "6")
        {
            if (unitPalce == "0")
            {
                figure = "Sixty";
            }
            else
            {
                figure = "Sixty " + GetNumString(unitPalce);
            }
        }

        if (tenthPlace == "7")
        {
            if (unitPalce == "0")
            {
                figure = "Seventy";
            }
            else
            {
                figure = "Seventy " + GetNumString(unitPalce);
            }
        }

        if (tenthPlace == "8")
        {
            if (unitPalce == "0")
            {
                figure = "Eighty";
            }
            else
            {
                figure = "Eighty " + GetNumString(unitPalce);
            }
        }

        if (tenthPlace == "9")
        {
            if (unitPalce == "0")
            {
                figure = "Ninty";
            }
            else
            {
                figure = "Ninty " + GetNumString(unitPalce);
            }
        }

        return figure;
    }

        protected static string GetNumHundredPlace(string number)
    {
        string hundredPalce = number[0].ToString();
        string tenthPlace = number[1].ToString();
        string unitPlace = number[2].ToString();

        string figure = string.Empty;

        if (tenthPlace == "0" && unitPlace == "0")
        {
            figure += GetNumString(hundredPalce) + " Hundred";
        }
        else
        {
            if (tenthPlace == "0")
            {
                figure += GetNumString(hundredPalce) + " Hundred And " + GetNumString(unitPlace);
            }
            else
            {
                figure += GetNumString(hundredPalce) + " Hundred And " + GetNumTenthPlace(tenthPlace + unitPlace);
            }
        }

        return figure;
    }

        protected static string GetNumThousandPlace(string number)
    {
        string thousandPlace = number[0].ToString();
        string hundredPlace = number[1].ToString();
        string tenthPlace = number[2].ToString();
        string unitPlace = number[3].ToString();

        string figure = string.Empty;

        if (hundredPlace == "0" && tenthPlace == "0" && unitPlace == "0")
        {
            figure += GetNumString(thousandPlace) + " Thousand ";
        }
        else
        {
            if (hundredPlace == "0" && tenthPlace == "0")
            {
                figure += GetNumString(thousandPlace) + " Thousand And " + GetNumString(unitPlace);
            }
            else
            {
                if (hundredPlace == "0")
                {
                    figure += GetNumString(thousandPlace) + " Thousand And " + GetNumTenthPlace(tenthPlace + unitPlace);
                }
                else
                {
                    figure += GetNumString(thousandPlace) + " Thousand " + GetNumHundredPlace(hundredPlace + tenthPlace + unitPlace);
                }
            }
        }

        return figure;
    }

        protected static string GetNumTenThousandPlace(string number)
    {
        string tenThousandPlace = number[0].ToString();
        string thousandPlace = number[1].ToString();
        string hundredPlace = number[2].ToString();
        string tenthPlace = number[3].ToString();
        string unitPlace = number[4].ToString();

        string figure = string.Empty;

        if (hundredPlace == "0" && tenthPlace == "0" && unitPlace == "0")
        {
            figure += GetNumTenthPlace(tenThousandPlace + thousandPlace) + " Thousand ";
        }
        else
        {
            if (hundredPlace == "0" && tenthPlace == "0")
            {
                figure += GetNumTenthPlace(tenThousandPlace + thousandPlace) + " Thousand And " + GetNumString(unitPlace);
            }
            else
            {
                if (hundredPlace == "0")
                {
                    figure += GetNumTenthPlace(tenThousandPlace + thousandPlace) + " Thousand And " + GetNumTenthPlace(tenthPlace + unitPlace);
                }
                else
                {
                    figure += GetNumTenthPlace(tenThousandPlace + thousandPlace) + " Thousand " + GetNumHundredPlace(hundredPlace + tenthPlace + unitPlace);
                }
            }
        }

        return figure;
    }

        protected static string GetNumLakhPlace(string number)
    {
        string lakhPlace = number[0].ToString();
        string tenThousandPlace = number[1].ToString();
        string thousandPlace = number[2].ToString();
        string hundredPlace = number[3].ToString();
        string tenthPlace = number[4].ToString();
        string unitPlace = number[5].ToString();

        string figure = string.Empty;

        if (tenThousandPlace == "0" && thousandPlace == "0" && hundredPlace == "0" && tenthPlace == "0" && unitPlace == "0")
        {
            figure += GetNumString(lakhPlace) + " Lakh ";
        }
        else
        {
            if (tenThousandPlace == "0" && thousandPlace == "0" && hundredPlace == "0" && tenthPlace == "0")
            {
                figure += GetNumString(lakhPlace) + " Lakh And " + GetNumString(unitPlace);
            }
            else
            {
                if (tenThousandPlace == "0" && thousandPlace == "0" && hundredPlace == "0")
                {
                    figure += GetNumString(lakhPlace) + " Lakh And " + GetNumTenthPlace(tenthPlace + unitPlace);
                }
                else
                {
                    if (tenThousandPlace == "0" && thousandPlace == "0")
                    {
                        figure += GetNumString(lakhPlace) + " Lakh " + GetNumHundredPlace(hundredPlace + tenthPlace + unitPlace);
                    }
                    else
                    {
                        if (tenThousandPlace == "0")
                        {
                            figure += GetNumString(lakhPlace) + " Lakh " + GetNumThousandPlace(thousandPlace + hundredPlace + tenthPlace + unitPlace);
                        }
                        else
                        {
                            figure += GetNumString(lakhPlace) + " Lakh " + GetNumTenThousandPlace(tenThousandPlace + thousandPlace + hundredPlace + tenthPlace + unitPlace);
                        }
                    }
                }
            }
        }

        return figure;
    }

        protected static string GetNumTenthLakhPlace(string number)
    {
        string tenLakhPlace = number[0].ToString();
        string lakhPlace = number[1].ToString();
        string tenThousandPlace = number[2].ToString();
        string thousandPlace = number[3].ToString();
        string hundredPlace = number[4].ToString();
        string tenthPlace = number[5].ToString();
        string unitPlace = number[6].ToString();

        string figure = string.Empty;

        if (tenThousandPlace == "0" && thousandPlace == "0" && hundredPlace == "0" && tenthPlace == "0" && unitPlace == "0")
        {
            figure += GetNumTenthPlace(tenLakhPlace + lakhPlace) + " Lakhs ";
        }
        else
        {
            if (tenThousandPlace == "0" && thousandPlace == "0" && hundredPlace == "0" && tenthPlace == "0")
            {
                figure += GetNumTenthPlace(tenLakhPlace + lakhPlace) + " Lakhs And " + GetNumString(unitPlace);
            }
            else
            {
                if (tenThousandPlace == "0" && thousandPlace == "0" && hundredPlace == "0")
                {
                    figure += GetNumTenthPlace(tenLakhPlace + lakhPlace) + " Lakhs And " + GetNumTenthPlace(tenthPlace + unitPlace);
                }
                else
                {
                    if (tenThousandPlace == "0" && thousandPlace == "0")
                    {
                        figure += GetNumTenthPlace(tenLakhPlace + lakhPlace) + " Lakhs " + GetNumHundredPlace(hundredPlace + tenthPlace + unitPlace);
                    }
                    else
                    {
                        if (tenThousandPlace == "0")
                        {
                            figure += GetNumTenthPlace(tenLakhPlace + lakhPlace) + " Lakhs " + GetNumThousandPlace(thousandPlace + hundredPlace + tenthPlace + unitPlace);
                        }
                        else
                        {
                            figure += GetNumTenthPlace(tenLakhPlace + lakhPlace) + " Lakhs " + GetNumTenThousandPlace(tenThousandPlace + thousandPlace + hundredPlace + tenthPlace + unitPlace);
                        }
                    }
                }
            }
        }

        return figure;
    }
}

