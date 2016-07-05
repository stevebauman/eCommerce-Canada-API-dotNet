using System;

namespace Moneris
{
	/// <summary>
	/// 
	/// </summary>
	public class TestVSCompletion
	{
		public static void Main(string[] args)
		{
			string host = "esqa.moneris.com";
			string store_id = "moneris";
			string api_token = "hurgle";

			string order_id = "statustest1";
            string txn_number = "96028-0_7";
			string amount = "0.01";			
			string crypt = "7";			

			//Console.Write ("Please enter an order ID: ");
			//order_id = Console.ReadLine();		

			//Console.Write ("Please enter a txn number: ");
			//txn_number = Console.ReadLine();		
			
		    string orderLevelGst = "0.00";		
		  	string merchantGstNo = "";			
			string orderLevelPst = "0.00";	
			string merchantPstNo = "";	
			string cri = "CUST-REF-001";
			
			try
			{
				L23HttpsPostRequest request=new L23HttpsPostRequest(host, store_id, api_token, 
					new VSCompletion(order_id, amount, txn_number, crypt, orderLevelGst, merchantGstNo, cri, 
					                 orderLevelPst, merchantPstNo),"true");

                Console.WriteLine("request = " + request.ToString());
				
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
                Console.WriteLine("StatusCode = " + myReceipt.GetStatusCode());
                Console.WriteLine("StatusMessage = " + myReceipt.GetStatusMessage());
			}
			catch ( Exception e )
			{
				Console.WriteLine(e);
			}
		}
	}
}
