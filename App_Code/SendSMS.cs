using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
/// Summary description for SendSMS
/// </summary>
public class SendSMS
{
    public SendSMS()
    {
        //
        // TODO: Add constructor logic here 
        //
    }
    /// <summary>
    /// Summary description for SOLSMSAPI
    /// </summary>
    /// 
    /// 


    //public static string sendsmsapi(string msgtype, string mobileNumber, string msgtext)
    //{
    //    int unicode=0;
    //    if (msgtype == "Hindi")
    //        unicode = 1;
    //    //unicode 1 hindi and 0 eng
    //    string Msg = "http://bulksms.msghouse.in/api/sendhttp.php?authkey=903A2zBMEBhC89Q55f548a1&mobiles=91"+mobileNumber+"&message="+msgtext+"&sender=JABBAR&route=4&unicode="+unicode;
    //    return "";
    //}//http://203.129.225.68/API/WebSMS/Http/v1.0a/index.php?username=vipsjbp&password=vips&sender=VISION&to=9752195753&message=hello&reqid=1&format={json|text}&route_id=113

    public static string sendsmsapi(string mobileNumber, string msgtext, string msgtype,string MsgApi)
    {
       
        string ucode = "text";
        if (msgtype == "Hindi")
            ucode = "unicode";
          //school
            //MSG = "http://203.129.225.68/API/WebSMS/Http/v1.0a/index.php?username=GCA-Jabalpur&password=NetrawGCA&sender=GCAjbp&to=addmobile&message=addmsg&reqid=1&format={json|text}&route_id=113&msgtype=adducode
        //college
        //MSG = "http://203.129.225.68/API/WebSMS/Http/v1.0a/index.php?username=metc&password=metc1990&sender=METCmp&to=addmobile&message=addmsg&reqid=1&format={json|text}&route_id=113&msgtype=adducode
            //MSG = "http://203.129.225.68/API/WebSMS/Http/v1.0a/index.php?username=metc&password=metc1990&sender=METCmp&to=" + mobileNumber + "&message=" + msgtext + "&reqid=1&format={json|text}&route_id=113&msgtype=" + ucode + "";

            string api = MsgApi;
            string api1 = (api.Replace("addmobile", mobileNumber));
            string api2 = (api1.Replace("addmsg", msgtext));
            string api3 = (api2.Replace("adducode", ucode));
            try
            {
               WebClient client = new WebClient();
                string baseURL = api3;
                client.OpenRead(baseURL);
            }
            catch (Exception ex)
            { }
        return null;
    }
    
    //public static string sendsmsapi(string mobileNumber, string msgtext, string msgtype)
    //{
    
    //    int ucode = 0;
    //    if (msgtype == "Hindi")
    //        ucode = 1;
    //    string status = "SEND";
    //    //Your authentication key
    //    string authKey = "6672AKVKIdekB5b929007";
    //    //Multiple mobiles numbers separated by comma
    //    // string mobileNumber = txtMobile.Text;
    //    //Sender ID,While using route4 sender id should be 6 characters long.

    //    string senderId = "VISION";
    //    //Your message to send, Add URL encoding here.
    //    string message = HttpUtility.UrlEncode(msgtext);

    //    //Prepare you post parameters
    //    StringBuilder sbPostData = new StringBuilder();
    //    sbPostData.AppendFormat("authkey={0}", authKey);
    //    sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
    //    sbPostData.AppendFormat("&message={0}", message);
    //    sbPostData.AppendFormat("&sender={0}", senderId);
    //    sbPostData.AppendFormat("&route={0}", 4);
    //    sbPostData.AppendFormat("&unicode={0}",ucode);

    //    try
    //    {
    //        //Call Send SMS API
    //        string sendSMSUri = "http://bulksms.msghouse.in/api/sendhttp.php?";
    //        //Create HTTPWebrequest
    //        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
    //        //Prepare and Add URL Encoded data
    //        UTF8Encoding encoding = new UTF8Encoding();
    //        byte[] data = encoding.GetBytes(sbPostData.ToString());
    //        //Specify post method
    //        httpWReq.Method = "POST";
    //        httpWReq.ContentType = "application/x-www-form-urlencoded";
    //        httpWReq.ContentLength = data.Length;
    //        using (Stream stream = httpWReq.GetRequestStream())
    //        {
    //            stream.Write(data, 0, data.Length);
    //        }
    //        //Get the response
    //        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
    //        StreamReader reader = new StreamReader(response.GetResponseStream());
    //        string responseString = reader.ReadToEnd();

    //        //Close the response
    //        reader.Close();
    //        response.Close();





    //    }
    //    catch (SystemException ex)
    //    {

    //        string s = ex.ToString();
    //        status = s;

    //    }
    //    return status;
    //}
}