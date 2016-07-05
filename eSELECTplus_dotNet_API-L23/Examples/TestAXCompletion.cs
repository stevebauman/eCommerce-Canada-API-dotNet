using System;
using System.Collections;

namespace Moneris
{
	public class TestAXCompletion
	{
		public static void Main(string[] args)
		{
			string host = "esqa.moneris.com";
			string store_id = "moneris";
			string api_token = "hurgle";
			string order_id;		//will prompt for user input
			string txn_number;		//will prompt for user input
			string amount = "0.01";			
			
			Console.Write ("Please enter an order ID: ");
			order_id = Console.ReadLine();
			
			Console.Write ("Please enter a txn number: ");
			txn_number = Console.ReadLine();				

			/******************** Table 1 - HEADING *********************/
			
			string n101 = "R6";	//Entity ID Code
			string n102 = "Retailing Inc. International";	//Name
			string n301 = "919 Oriole Rd.";		//Address Line 1
			string n401 = "Toronto";		//City 
			string n402 = "On";			//State or Province
			string n403 = "H1T6W3";			//Postal Code
			
			string big04 = "";	//Purchase Order Number
			string big05 = "";	//Release Number
			string big10 = "";      //Invoice Number
			
			string[] ref01 = new string[]{"4C", "CR"};	//Reference ID Qualifier
			string[] ref02 = new string[]{"M5T3A5", "16802309004"}; //Reference ID 

			RefAx[] refID = new RefAx[2]; 
			refID[0] = new RefAx (ref01[0], ref02[0]); 	
			refID[1] = new RefAx (ref01[1], ref02[1]); 
			
			N1_loop[] n1 = new N1_loop[1];
			n1[0] = new N1_loop (n101, n102, n301, "",
					     n401, n402, n403, refID);	
						  
			Table1 tbl1 = new Table1 (big04, big05, big10, n1);  			
			
			
			/********************* Table 2 - DETAIL *********************/
			
			//the sum of the extended amount field (i.e. paramater #7 of It1_Loop
			//must equal the level 1 amount field)	
			
			string[] it102 = new string[]{"1", "1", "1", "1", "1"};	//Line item quantity invoiced
			string[] it103 = new string[]{"EA", "EA", "EA", "EA", "EA"};  //Line item unit or basis of measurement code
			string[] it104 = new string[]{"10.00", "25.00", "8.62", "10.00", "-10.00"};   //Line item unit price
			string[] it105 = new string[]{"", "", "", "", ""};	//Line item basis of unit price code	
			
			string[] it10618 = new string[]{"MG", "MG", "MG", "MG", "MG"};   //Product/Service ID qualifier
			string[] it10719 = new string[]{"DJFR4", "JFJ49", "FEF33", "FEE43", "DISCOUNT"};   //Product/Service ID (corresponds to it10618)
			
			string[] txi01_GST = new string[]{"GS", "GS", "GS", "GS", "GS"};	//Tax type code
			string[] txi02_GST = new string[]{"0.70", "1.75", "1.00", "0.80","0.00"};	//Monetary amount
			string[] txi03_GST = new string[]{"", "", "", "",""};		//Percent
			string[] txi06_GST = new string[]{"", "", "", "",""};		//Tax exempt code
			
			string[] txi01_PST = new string[]{"PG", "PG", "PG","PG","PG"};	//Tax type code
			string[] txi02_PST = new string[]{"0.80", "2.00", "1.00", "0.80","0.00"};	//Monetary amount
			string[] txi03_PST = new string[]{"", "", "", "",""};		//Percent
			string[] txi06_PST = new string[]{"", "", "", "",""};		//Tax exempt code
						
			Txi[] taxGST = new Txi[5]{new Txi(txi01_GST[0], txi02_GST[0], txi03_GST[0], txi06_GST[0]), 
						  new Txi(txi01_GST[1], txi02_GST[1], txi03_GST[1], txi06_GST[1]),
				      		  new Txi(txi01_GST[2], txi02_GST[2], txi03_GST[2], txi06_GST[2]), 
							 new Txi(txi01_GST[3], txi02_GST[3], txi03_GST[3], txi06_GST[3]), 
				      		  new Txi(txi01_GST[4], txi02_GST[4], txi03_GST[4], txi06_GST[4])};
						  
			Txi[] taxPST = new Txi[5]{new Txi(txi01_PST[0], txi02_PST[0], txi03_PST[0], txi06_PST[0]), 
						  new Txi(txi01_PST[1], txi02_PST[1], txi03_PST[1], txi06_PST[1]),
				      		  new Txi(txi01_PST[2], txi02_PST[2], txi03_PST[2], txi06_PST[2]),
							new Txi(txi01_PST[3], txi02_PST[3], txi03_PST[3], txi06_PST[3]),
				      		  new Txi(txi01_PST[4], txi02_PST[4], txi03_PST[4], txi06_PST[4])};
						  
			string[] pam05 = new string[]{"11.50", "28.75", "10.62", "11.50", "-10.00"};	//Extended line-item amount
			string[] pid05 = new string[]{"Stapler", "Lamp", "Bottled Water", "Fountain Pen", "DISCOUNT"};	//Line item description

			ArrayList itQual = new ArrayList();	//array list to hold product IDs and Descriptions
			ArrayList level3Taxes = new ArrayList();    //list to hold GST and PST objects for each item
					
			int numOfItems = pid05.Length;
						
			It1_loop[] itemLoop = new It1_loop[numOfItems]; //instantiate array of items object 
			
			//for (int item = 0; item < pid05.Length; item++)
			for (int item = 0; item < 5; item++)
			{
				itQual.Add(new It106s[]{new It106s(it10618[item], it10719[item])});
				itQual.Add(new It106s[]{new It106s(it10618[item], it10719[item])});
				itQual.Add(new It106s[]{new It106s(it10618[item], it10719[item])});
				itQual.Add(new It106s[]{new It106s(it10618[item], it10719[item])});	

				level3Taxes.Add(new Txi[]{taxGST[0], taxPST[0]}); //create tax object for item 1 
				level3Taxes.Add(new Txi[]{taxGST[1], taxPST[1]}); //create tax object for item 2 
				level3Taxes.Add(new Txi[]{taxGST[2], taxPST[2]}); //create tax object for item 3 
				level3Taxes.Add(new Txi[]{taxGST[3], taxPST[3]}); //create tax object for item 4
							
				itemLoop[item] = new It1_loop(it102[item], it103[item], it104[item], 
							      it105[item], (It106s[])(itQual[item]), 
							      (Txi[])(level3Taxes[item]), pam05[item], pid05[item]);
			}		

			Table2 tbl2 = new Table2 (itemLoop); //element of AXLevel23
			
			
			/********************* Table 3 - SUMMARY ********************/		
			
			Txi[] taxTbl3 = new Txi[3];	
			taxTbl3[0] = new Txi("GS", "4.25","","");	//sum of GST taxes
			taxTbl3[1] = new Txi("PG", "4.60","","");	//sum of PST taxes
			taxTbl3[2] = new Txi("TX", "8.85","","");
			
			Table3 tbl3 = new Table3(taxTbl3);
			
			/**********************   REQUEST  ************************/
			
			AXLevel23 level23 = new AXLevel23(tbl1, tbl2, tbl3);		
			
			try
			{
				L23HttpsPostRequest request=new L23HttpsPostRequest(host, store_id, api_token, 
					new AXCompletion(order_id, amount, txn_number, level23),"false");
					
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
                Console.WriteLine("Status Message = " + myReceipt.GetStatusMessage());
                Console.WriteLine("Status Code = " + myReceipt.GetStatusCode());


			}
				
				catch ( Exception e )
			{
					Console.WriteLine(e);
			}
			
		}
	}
	
}
			