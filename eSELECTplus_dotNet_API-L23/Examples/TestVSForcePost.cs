using System;

namespace Moneris
{
	/// <summary>
	/// 
	/// </summary>
	public class TestVSForcePost
	{
		public static void Main(string[] args)
		{
			string host = "esqa.moneris.com";
			string store_id = "moneris";
			string api_token = "hurgle";
			string order_id = "ZZZ_008";
			string amount = "222.00";
			string pan="4716019111111115";
			string expDate="0912";
			string authCode="44565";
			string crypt = "7";
			string cust_id = "GSP_001";
			string orderLevelGst = "0.0";
			if ( args.Length > 10 )
			{
			  orderLevelGst = args[10];
			}
			string merchantGstNo = "";
			if ( args.Length > 11 )
			{
			  merchantGstNo = args[11];
			}
			string orderLevelPst = "0.0";
			if ( args.Length > 12 )
			{
				orderLevelPst = args[12];
			}
			string merchantPstNo = "";
			if ( args.Length > 13 )
			{
				merchantPstNo = args[13];
			}
			string cri = "";
			if ( args.Length > 14 )
			{
			  cri = args[14];
			}
			try
			{
				L23HttpsPostRequest request=new L23HttpsPostRequest(host, store_id, api_token, 
					new VSForcePost(order_id, cust_id, amount, pan, expDate, authCode, crypt, orderLevelGst, 
					                merchantGstNo, cri, orderLevelPst, merchantPstNo));
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
