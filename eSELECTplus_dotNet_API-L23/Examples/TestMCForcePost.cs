using System;

namespace Moneris
{
	/// <summary>
	/// 
	/// </summary>
	public class TestMCForcePost
	{
		public static void Main(string[] args)
		{
			string host = "esqa.moneris.com";
			string cust_id= "Chuck_Liddell_07";
			string store_id = "moneris";
			string api_token = "hurgle";
			string order_id = "ZZZ_0077";
			string amount = "59.00";
			string pan = "4242424242424242";
			string expDate = "0910";
			string authCode = "88864";
			string crypt = "7";
			try
			{
				L23HttpsPostRequest request=new L23HttpsPostRequest(host, store_id, api_token, 
					new MCForcePost(order_id, cust_id, amount, pan, expDate, authCode, crypt));
				Receipt myReceipt=request.GetReceipt();
				Console.WriteLine("CardType = " + myReceipt.GetCardType());
				Console.WriteLine("TransAmount = " + myReceipt.GetTransAmount());
				Console.WriteLine("TxnNumber = " + myReceipt.GetTxnNumber());
				Console.WriteLine("ReceiptId = " + myReceipt.GetReceiptId());
				Console.WriteLine("TransType = " + myReceipt.GetTransType());
				Console.WriteLine("ReferenceNum = " + myReceipt.GetReferenceNum());
				Console.WriteLine("ResponseCode = " + myReceipt.GetResponseCode());
				Console.WriteLine("ISO = " + myReceipt.GetISO());
				Console.WriteLine("BankTotals = " + myReceipt.GetBankTotals());
				Console.WriteLine("Message = " + myReceipt.GetMessage());
				Console.WriteLine("AuthCode = " + myReceipt.GetAuthCode());
				Console.WriteLine("Complete = " + myReceipt.GetComplete());
				Console.WriteLine("TransDate = " + myReceipt.GetTransDate());
				Console.WriteLine("TransTime = " + myReceipt.GetTransTime());
				Console.WriteLine("Ticket = " + myReceipt.GetTicket());
				Console.WriteLine("TimedOut = " + myReceipt.GetTimedOut());
				Console.WriteLine("CorporateCard = " + myReceipt.GetCorporateCard());
				Console.WriteLine("MessageId = " + myReceipt.GetMessageId());
			}
			catch ( Exception e )
			{
				Console.WriteLine(e);
			}
		}
	}
}
